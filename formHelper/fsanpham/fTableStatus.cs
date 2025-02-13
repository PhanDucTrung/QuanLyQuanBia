using BUS.ClassHelper;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanBia.formHelper.ItemSP;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using QuanLyQuanBia.formHelper.fBan;
using System.Collections;

namespace QuanLyQuanBia.formHelper
{
    public partial class fTableStatus : Form
    {
        public fTableStatus()
        {
            InitializeComponent();
            btnThemMon.Visible = fLogin.PhanQuyen == "admin";
        }

      
        public int total = 0;
        public int totalNumOrder = 0;

        DatabaseHelper db;
        public List<ItemSanPham> itemSP;
        public List<ItemSanPham> itemSPsFilter;

        private void fTableStatus_Load(object sender, EventArgs e)
        {
            db = new DatabaseHelper(fLogin.connectionStringSQL);

          //  ViewFlowLayoutPanel();
           load_Cbb_Ban();

            cbbTypeSP.DataSource = LayDanhSachLoaiSanPham();


        }

        void ViewFlowLayoutPanel(string Searchkeywords = "",int SapXepHSD = -1,string LocTheoloaiSanPham ="")
        {
            // Xóa tất cả các điều khiển trong FlowLayoutPanel
            flowLayoutPanel.Controls.Clear();

            DataTable dataTable = new DataTable();
            if (SapXepHSD >= 0) // sắp xếp theo HSD nếu SapXepHSD bé hơn 0
            {
                dataTable = SearchProductsByKeywordAndSort(Searchkeywords, SapXepHSD == 0 ? true : false); // == 1 thì true còn không thì false
            }
            else if (Searchkeywords != "") 
            {
                // tìm kiếm theo từ khóa
                dataTable = SearchSanPham_ByKeyword(Searchkeywords);
            }
            else if (LocTheoloaiSanPham != "")
            {
                // loc theo loai San Pham
                dataTable = GetProductsByCategory(LocTheoloaiSanPham);
            }    
            else
            {
                // mặc định
                dataTable = db.ExecuteQuery("SELECT * FROM SanPham AS S JOIN ChiTietSanPham AS CS ON S.MaSanPham = CS.MaSanPham");
            }
            

            var data = ListSanPhamHelper.GetListSP(dataTable);
            var list = new ItemSanPham[data.Count];
            int i = 0;
            itemSP = new List<ItemSanPham>();
            itemSPsFilter = new List<ItemSanPham>();
            foreach (var item in data)
            {
                list[i] = new ItemSanPham();
                list[i].itemValueChanged += Form1_itemValueChanged;
                list[i].uri_monan = Path.GetDirectoryName(Application.ExecutablePath) + item.pathImg;
                list[i].MaChiTietSanPham = item.MaChiTietSanPham;
                list[i].MaSP = item.MaSanPham;
                list[i].name = item.TenSanPham;
                list[i].price = item.Gia;
                list[i].soluongton = (int)item.SoLuongTon;
                list[i].LoadImageAsync();
                itemSP.Add(list[i]);
                itemSPsFilter.Add(list[i]);
                i++;
            }
            flowLayoutPanel.Controls.AddRange(list);
        }

        void load_Cbb_Ban()
        {
            DataTable DATA1 = db.ExecuteQuery("SELECT * FROM Ban");
            foreach (DataRow row in DATA1.Rows)
            {
                string item = $"{row["MaBan"]}. {row["TenBan"]}: {row["TinhTrang"]}";
                cbbAllBan.Items.Add(item);
            }
        }





        private void Form1_itemValueChanged(object sender, ItemSanPham.ItemValueChangedEventArgs e)
        {
            if (sender.ToString().Contains("Thêm vào Rỏ Hàng") && e.NameSP !="" && e.sLvalue != 0)
            {
               
                if (cbbAllBan.Text == ""|| (cbbAllBan.Text.ToString().Contains("Trống")))
                {
                    MessageBoxHelper.ShowMessageBox("Vui lòng book bàn trước, rồi thử lại sau!"); return;
                }
                int rowIndex = -1;

                if (dtgv.RowCount != 0)
                {
                    foreach (DataGridViewRow row in dtgv.Rows)
                    {
                        if (row.Cells["cTenSanPham"].Value.ToString() == e.NameSP)
                        {
                            rowIndex = row.Index;

                            int soluongTrenBill = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, rowIndex, "cSoluong"));


                            DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cSoluong", soluongTrenBill + 1);
                            break;
                        }
                    }
                }
                else
                {
                    rowIndex = dtgv.Rows.Add();
                    DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cSoluong", e.sLvalue);
                }

                
                if (rowIndex == -1)
                {
                    rowIndex = dtgv.Rows.Add();
                    DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cSoluong", e.sLvalue);
                }



                DatagridviewHelper.SetStatusDataGridView(dtgv,rowIndex, "cImgDelete", Image.FromFile(@"img\trash_25px.png"));
                DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cTenSanPham", e.NameSP);
                DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cMaSanPham", e.MASP);
                DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cMaChiTietSanPham", e.MaChiTietSanPham);

                int soluongDTGV = Convert.ToInt32( DatagridviewHelper.GetStatusDataGridView(dtgv, rowIndex, "cSoluong"));



                tinhtienRow(soluongDTGV, e.Value, rowIndex);

                SumRow();
                if (UpAndDownSoLuongTon(e.MASP, Down: false)) // trừ đi 1 san pham trong databas
                {
                    int maban = Convert.ToInt32(cbbAllBan.Text.Split('.')[0]);


                    // từ mã bàn lấy ra mãhoadon
                    int maHoaDon = GetMaHoaDonByMaBan(maban);

                    bool INSERTChiTietHoaDon = CapNhatSoLuongVaGiaBanByChiTietHoaDon(maHoaDon, e.MASP, e.Value); // Update thêm số lượng + 1 cho bảng ChiTietHoaDon hiện có ( điều kiện MaHoaDon và MASP phải có trong bảng ChiTietHoaDon)
                    //bool INSERTChiTietHoaDon = ThemChiTietHoaDon(maHoaDon, e.MASP, 1, e.Value) > 0;
                    if (!INSERTChiTietHoaDon)
                    {
                        INSERTChiTietHoaDon = ThemChiTietHoaDon(maHoaDon, e.MASP, 1, e.Value) > 0; // INSERT 1 ChiTietHoaDon mới

                    }
                    e.IsAdd = true; // Add Thành Công - Sản Phẩm trên View

                    ViewFlowLayoutPanel();
                } 
            }
        }

        void tinhtienRow(int soluong,decimal sotien,int rowIndex)
        { 
            decimal soTien = soluong * sotien;
            DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cThanhtien", soTien);
        }
        void SumRow()
        {
            decimal totalSum = 0; // Khởi tạo tổng ban đầu
            foreach (DataGridViewRow row in dtgv.Rows)
            {
                // Kiểm tra xem giá trị trong cột "cThanhtien" có null hoặc trống không
                if (row.Cells["cThanhtien"].Value != null && !string.IsNullOrEmpty(row.Cells["cThanhtien"].Value.ToString()))
                {
                    // Trích xuất giá trị từ cột "cThanhtien" và cộng vào tổng
                    decimal valueInColumn = Convert.ToDecimal(row.Cells["cThanhtien"].Value);
                    totalSum += valueInColumn;
                }
            }

            lblTongTien.Text = totalSum.ToString() + "VNĐ";
        }




    
        public bool CapNhatSoLuongVaGiaBanByChiTietHoaDon(int maHoaDon, int maSanPham,decimal gia,bool donw = false)
        {
            // Tạo câu truy vấn để cập nhật SoLuong và GiaBan
            string query = "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + 1, GiaBan = GiaBan + @AdditionalPrice " +
                           "WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";
            if (donw)
            {
                query = "UPDATE ChiTietHoaDon SET SoLuong = SoLuong - 1, GiaBan = GiaBan - @AdditionalPrice " +
                           "WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";
            }

            // Tạo danh sách tham số cho câu truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaHoaDon", maHoaDon),
        new SqlParameter("@MaSanPham", maSanPham),
        new SqlParameter("@AdditionalPrice", gia)
            };

            // Thực hiện truy vấn cập nhật
            return db.ExecuteNonQuery(query, parameters) > 0;
        }


        public int GetMaHoaDonByMaBan(int maBan) // get Ban.MaHoaDon Bảng Ban :D
        {
            int maHoaDon = -1;  // Giá trị mặc định nếu không tìm thấy
            
                string query = "SELECT MaHoaDon FROM Ban WHERE MaBan = @MaBan";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaBan", maBan) };

            DataTable data  = db.ExecuteQuery(query, parameters);
            maHoaDon = (int)data.Rows[0]["MaHoaDon"];


            return maHoaDon;
        }



        public bool UpAndDownSoLuongTon(int maSanPham,bool Down = false)
        {
            string query = "UPDATE ChiTietSanPham SET SoLuongTon = SoLuongTon - 1 WHERE MaSanPham = @MaSanPham";
            if (Down)
            {
                query = "UPDATE ChiTietSanPham SET SoLuongTon = SoLuongTon + 1 WHERE MaSanPham = @MaSanPham";
            }
            SqlParameter[] parameters = new SqlParameter[]{new SqlParameter("@MaSanPham", maSanPham)};
            return db.ExecuteNonQuery(query, parameters) > 0;
        }
        


        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Common.ShowForm(new fAddFood());
        }

        private void pnlLeftTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgv.Columns["cImgDelete"].Index)
            {
                int masanpham = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaSanPham"));
                int maban = Convert.ToInt32(cbbAllBan.Text.Split('.')[0]);

                // từ mã bàn lấy ra mãhoadon
                int maHoaDon = GetMaHoaDonByMaBan(maban);

                int cSoluong = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cSoluong"));
                decimal cSoTien = Convert.ToDecimal(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cThanhtien"));
                if (cSoluong <= 1)
                {
                    // nếu số lượng == 0 thì xóa luôn chitiethoadon đó 
                    if (XoaChiTietHoaDon(maHoaDon, masanpham))
                    {
                        deleteRowAndSapXep(dtgv, e.RowIndex, true); // xoa all
                    }
                    
                }
                else
                {
                    // nếu lớn hơn 0 thì  xoa 1 đơn vị xóa luôn cả giá 
                    cSoluong = cSoluong - 1;

                    decimal giabanleSanPham = LayGiaBanSanPham(masanpham);
                    bool INSERTChiTietHoaDon = CapNhatSoLuongVaGiaBanByChiTietHoaDon(maHoaDon, masanpham, giabanleSanPham, donw:true); // Update thêm số lượng -1 cho bảng ChiTietHoaDon hiện có ( điều kiện MaHoaDon và MASP phải có trong bảng ChiTietHoaDon)
                    if (!INSERTChiTietHoaDon)
                    {
                        //INSERTChiTietHoaDon = ThemChiTietHoaDon(maHoaDon, e.MASP, 1, e.Value) > 0; // INSERT 1 ChiTietHoaDon mới

                    }
                    
                    DatagridviewHelper.SetStatusDataGridView(dtgv, e.RowIndex, "cSoluong", cSoluong);
                }

                



                if (UpAndDownSoLuongTon(masanpham, Down: true))
                {
                    

                    ViewFlowLayoutPanel();
                }
            }
        }


        public void deleteRowAndSapXep(DataGridView dtgv, int rowIndex, bool SapXep = false)
        {
            try
            {
                // tien hanh xoa
                dtgv.Rows.RemoveAt(rowIndex);
                //if (SapXep)
                //{
                //    // Cập nhật lại số thứ tự cho tất cả các dòng còn lại
                //    for (int i = 0; i < dtgv.Rows.Count; i++)
                //    {
                //        dtgv.Rows[i].Cells[0].Value = (i + 1).ToString();
                //    }
                //}
            }
            catch (Exception)
            {


            }
        }

        private void cbbAllBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAllBan.Text.ToString().Contains("Trống"))
            {
                lblTongTien.Text = "";
                dtgv.Rows.Clear();
                btnBook.Visible = true;
                btnBook.ButtonText = "Book Bàn";
            }
            else if (cbbAllBan.Text.ToString().Contains("Đang sử dụng"))
            {
                lblTongTien.Text = "";
                dtgv.Rows.Clear();
                int indexCbb = Convert.ToInt32(cbbAllBan.Text.Split('.')[0]);
                int maban = GetMaHoaDonByMaBan(indexCbb);

                // đổ dữ liệu và view dtgv
                ViewDtgv(maban);

                SumRow(); // tính tiền theo Row

                btnBook.Visible = false;
               // btnBook.ButtonText = "Thêm Vào Hóa Đơn";
            }
        }

        void ViewDtgv(int MaHoaDon)
        {
            DataTable Data = LayChiTietHoaDon(MaHoaDon);
            foreach (DataRow item in Data.Rows)
            {
                //string tenSanPham = item["MaChiTietHoaDon"].ToString();
                //string MaHoaDon = item["MaHoaDon"].ToString();
                string MaSanPham = item["MaSanPham"].ToString();
                int SoLuong = Convert.ToInt32(item["SoLuong"]);
                decimal GiaBan = Convert.ToDecimal(item["GiaBan"]);
                string TenSanPham = item["TenSanPham"].ToString();




                int rowIndex = -1;
                if (dtgv.RowCount != 0)
                {
                    foreach (DataGridViewRow row in dtgv.Rows)
                    {
                        if (row.Cells["cMaSanPham"].Value.ToString() == MaSanPham)
                        {
                            rowIndex = row.Index;

                            int soluongTrenBill = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, rowIndex, "cSoluong"));
                            DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cSoluong", soluongTrenBill + SoLuong);

                            decimal thanhtienTrenBill = Convert.ToDecimal(DatagridviewHelper.GetStatusDataGridView(dtgv, rowIndex, "cThanhtien"));
                            DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cThanhtien", thanhtienTrenBill + GiaBan);
                            break;
                        }
                    }
                }
                else
                {
                    rowIndex = dtgv.Rows.Add();
                    DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cSoluong", SoLuong);
                    DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cThanhtien", GiaBan);
                }


                if (rowIndex == -1)
                {
                    rowIndex = dtgv.Rows.Add();
                    DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cSoluong", SoLuong);
                    DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cThanhtien", GiaBan);
                }

                DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cImgDelete", Image.FromFile(@"img\trash_25px.png"));
                DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cTenSanPham", TenSanPham);
                DatagridviewHelper.SetStatusDataGridView(dtgv, rowIndex, "cMaSanPham", MaSanPham);
            }
        }





        public DataTable LayChiTietHoaDon(int maHoaDon)
        {
            string query = "SELECT CTHD.*, SP.TenSanPham " +
                           "FROM ChiTietHoaDon CTHD " +
                           "INNER JOIN SanPham SP ON CTHD.MaSanPham = SP.MaSanPham " +
                           "WHERE CTHD.MaHoaDon = @MaHoaDon";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaHoaDon", maHoaDon)
            };

            DataTable dataTable = db.ExecuteQuery(query, parameters);

            return dataTable;
        }

       public int ThemHoaDon(int maBan, DateTime ngayLap, int soBan, int soGioChoi, decimal thanhTien, int maKhachHang, string tenKhachHang, string hinhThucThanhToan, int nhanVienThanhToan)
        {

            string query = "INSERT INTO HoaDon (MaBan, NgayLap, SoBan, SoGioChoi, ThanhTien, MaKhachHang, TenKhachHang, HinhThucThanhToan, NhanVienThanhToan) " +
                           "VALUES (@MaBan, @NgayLap, @SoBan, @SoGioChoi, @ThanhTien, @MaKhachHang, @TenKhachHang, @HinhThucThanhToan, @NhanVienThanhToan)";

            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@MaBan", maBan),
             new SqlParameter("@NgayLap", ngayLap),
             new SqlParameter("@SoBan", soBan),
             new SqlParameter("@SoGioChoi", soGioChoi),
             new SqlParameter("@ThanhTien", thanhTien),
             new SqlParameter("@MaKhachHang", maKhachHang),
             new SqlParameter("@TenKhachHang", tenKhachHang),
             new SqlParameter("@HinhThucThanhToan", hinhThucThanhToan),
             new SqlParameter("@NhanVienThanhToan", nhanVienThanhToan)
            };

            int newMaHoaDon = db.ExecuteInsertAndGetIdentity(query, parameters);

            return newMaHoaDon;
        }
        public int ThemHoaDon(int maBan, DateTime ngayLap, string tenban)
        {

            string query = "INSERT INTO HoaDon (MaBan, NgayLap, TenBan) " +
                           "VALUES (@MaBan, @NgayLap, @TenBan)";

            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@MaBan", maBan),
             new SqlParameter("@NgayLap", ngayLap),
             new SqlParameter("@TenBan", tenban),
            };

            int newMaHoaDon = db.ExecuteInsertAndGetIdentity(query, parameters);

            return newMaHoaDon;
        }
        public int Search_MaHoaDonByMaBan_Or_TenBan_NotTrong(int maBan,string tenban)
        {
            string query = "SELECT MaHoaDon FROM Ban WHERE MaBan = @MaBan AND TenBan = @TenBan AND TinhTrang <> 'trống'";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaBan", maBan),
                new SqlParameter("@TenBan", tenban)
            };

            object result = db.ExecuteScalar(query, parameters);

            if (result != null && result != DBNull.Value)
            {
                return (int)result;
            }

            return 0; // Trả về 0 nếu không tìm thấy hoặc bàn có trạng thái "trống"
        }


        public int ThemChiTietHoaDon(int maHoaDon, int maSanPham, int soLuong, decimal giaBan)
        {
            string query = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, GiaBan) " +
                           "VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @GiaBan)";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaHoaDon", maHoaDon),
        new SqlParameter("@MaSanPham", maSanPham),
        new SqlParameter("@SoLuong", soLuong),
        new SqlParameter("@GiaBan", giaBan)
            };

            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected;
        }


        public int CapNhatBan(int maBan, string tenBan, int maLoaiBan, string tinhTrang, DateTime gioBatDauChoi,int maHoaDon)
        {
            string query = "UPDATE Ban " +
                           "SET TenBan = @TenBan, MaLoaiBan = @MaLoaiBan, TinhTrang = @TinhTrang, GioBatDauChoi = @GioBatDauChoi, MaHoaDon = @MaHoaDon " +
                           "WHERE MaBan = @MaBan";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaBan", maBan),
        new SqlParameter("@TenBan", tenBan),
        new SqlParameter("@MaLoaiBan", maLoaiBan),
        new SqlParameter("@TinhTrang", tinhTrang),
        new SqlParameter("@GioBatDauChoi", gioBatDauChoi),
        new SqlParameter("@MaHoaDon", maHoaDon)
            };

            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected;
        }

        public int CapNhatChiTietSanPham(int maChiTietSanPham, int maSanPham, string donViTinh, string ghiChu, int soLuongTon, DateTime hanSuDung, decimal giaNhap, string nguonNhap, string chiTietLienLac, DateTime ngayNhap)
        {
            string query = "UPDATE ChiTietSanPham " +
                           "SET MaSanPham = @MaSanPham, DonViTinh = @DonViTinh, GhiChu = @GhiChu, SoLuongTon = @SoLuongTon, HanSuDung = @HanSuDung, GiaNhap = @GiaNhap, NguonNhap = @NguonNhap, ChiTietLienLac = @ChiTietLienLac, NgayNhap = @NgayNhap " +
                           "WHERE MaChiTietSanPham = @MaChiTietSanPham";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaChiTietSanPham", maChiTietSanPham),
        new SqlParameter("@MaSanPham", maSanPham),
        new SqlParameter("@DonViTinh", donViTinh),
        new SqlParameter("@GhiChu", ghiChu),
        new SqlParameter("@SoLuongTon", soLuongTon),
        new SqlParameter("@HanSuDung", hanSuDung),
        new SqlParameter("@GiaNhap", giaNhap),
        new SqlParameter("@NguonNhap", nguonNhap),
        new SqlParameter("@ChiTietLienLac", chiTietLienLac),
        new SqlParameter("@NgayNhap", ngayNhap)
            };

            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected;
        }
        public int CapNhatChiTietSanPham(int maChiTietSanPham, int maSanPham,int soLuongTon)
        {
            string query = "UPDATE ChiTietSanPham " +
                           "SET MaSanPham = @MaSanPham,SoLuongTon = @SoLuongTon "+
                           "WHERE MaChiTietSanPham = @MaChiTietSanPham";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaChiTietSanPham", maChiTietSanPham),
        new SqlParameter("@MaSanPham", maSanPham),
        new SqlParameter("@SoLuongTon", soLuongTon),
            };

            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected;
        }

        public int TruSoLuongTon(int maChiTietSanPham, int soLuongTru)
        {
            // Truy xuất số lượng tồn hiện tại dựa trên MaChiTietSanPham
            string selectQuery = "SELECT SoLuongTon FROM ChiTietSanPham WHERE MaChiTietSanPham = @MaChiTietSanPham";

            SqlParameter[] selectParameters = new SqlParameter[]
            {
        new SqlParameter("@MaChiTietSanPham", maChiTietSanPham)
            };

            object result = db.ExecuteScalar(selectQuery, selectParameters);

            if (result != null && result != DBNull.Value)
            {
                int soLuongTonHienTai = (int)result;

                // Trừ đi số lượng muốn giảm
                int soLuongMoi = soLuongTonHienTai - soLuongTru;

                // Cập nhật số lượng tồn mới vào bảng ChiTietSanPham
                string updateQuery = "UPDATE ChiTietSanPham SET SoLuongTon = @SoLuongTonMoi WHERE MaChiTietSanPham = @MaChiTietSanPham";

                SqlParameter[] updateParameters = new SqlParameter[]
                {
            new SqlParameter("@MaChiTietSanPham", maChiTietSanPham),
            new SqlParameter("@SoLuongTonMoi", soLuongMoi)
                };

                int rowsAffected = db.ExecuteNonQuery(updateQuery, updateParameters);

                return rowsAffected;
            }

            return 0;
        }


        public int GetSoLuongByChiTietHoaDon(int maHoaDon, int maSanPham)
        {
            // Tạo câu truy vấn để lấy số lượng từ ChiTietHoaDon
            string query = "SELECT SoLuong FROM ChiTietHoaDon " +
                           "WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

            // Tạo danh sách tham số cho câu truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaHoaDon", maHoaDon),
        new SqlParameter("@MaSanPham", maSanPham)
            };

            // Thực hiện truy vấn SELECT để lấy số lượng
            DataTable result = db.ExecuteQuery(query, parameters);

            // Kiểm tra xem có kết quả từ truy vấn hay không
            if (result.Rows.Count > 0)
            {
                // Lấy giá trị số lượng từ kết quả truy vấn
                return Convert.ToInt32(result.Rows[0]["SoLuong"]);
            }
            else
            {
                // Trả về giá trị mặc định hoặc có thể là -1 nếu không tìm thấy
                return -1;
            }
        }
        public bool XoaChiTietHoaDon(int maHoaDon, int maSanPham)
        {
            // Tạo câu truy vấn để xóa chi tiết hóa đơn
            string query = "DELETE FROM ChiTietHoaDon " +
                           "WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

            // Tạo danh sách tham số cho câu truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaHoaDon", maHoaDon),
        new SqlParameter("@MaSanPham", maSanPham)
            };

            // Thực hiện truy vấn DELETE để xóa chi tiết hóa đơn
            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public decimal LayGiaBanSanPham(int maSanPham)
        {
            string query = "SELECT Gia FROM SanPham WHERE MaSanPham = @MaSanPham";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaSanPham", maSanPham)
            };

            // Thực hiện truy vấn để lấy giá bán từ bảng SanPham
            DataTable result = db.ExecuteQuery(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                // Lấy giá bán từ dòng đầu tiên của kết quả truy vấn
                decimal giaBan = (decimal)result.Rows[0]["Gia"];
                return giaBan;
            }

            return 0; // Hoặc trả về giá trị mặc định khác nếu cần
        }

        public void SelectCombobox(int maban , string tenban)
        {
            foreach (object item in cbbAllBan.Items)
            {
                if (item.ToString().Trim().Contains(maban.ToString()) && item.ToString().Trim().Contains(tenban))
                {
                    cbbAllBan.SelectedItem = item;return;
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            
            if (cbbAllBan.Text == "")
            {
                return;
            }
            int maban = Convert.ToInt32(cbbAllBan.Text.Split('.')[0]);

            string tenban = cbbAllBan.Text.Split('.')[1].Trim().Split(':')[0];

            string trangthaicuaban = cbbAllBan.Text.Split('.')[1].Trim().Split(':')[1];

            if (maban > 0 && tenban != "")
            {
                DateTime timeHienTai = DateTime.Now;


                //sẽ có 2 trạng thái là : Đang Sử dụng và Trống
                int maHoaDon = 0;
                if (trangthaicuaban.Contains("Trống"))
                {
                    // Thêm hóa đơn và lấy mã hóa đơn vừa thêm
                     maHoaDon = ThemHoaDon(maban, timeHienTai, tenban);
                    // thay đổi trạng thái của bàn  Và Thêm ID mã hóa đơn vào Bàn đó :D 
                    CapNhatBan(maban, tenban, 1, "Đang sử dụng", timeHienTai, maHoaDon);
                }
                else // trạng thái bàn != trống
                {
                    // dựa vào mã bàn + tên bàn đi tìm đúng cái bàn đó ? điều kiện là : bàn đó Có trạng thái != trống
                    maHoaDon = Search_MaHoaDonByMaBan_Or_TenBan_NotTrong(maban, tenban);

                }
                
                /// lấy từng sản phẩm mà khách đã chọn trên dtgv :)
                foreach (DataGridViewRow row in dtgv.Rows)
                {
                   // string cTenmon = DatagridviewHelper.GetStatusDataGridView(dtgv, row.Index, "cTenmon");
                    int cMaChiTietSanPham = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, row.Index, "cMaChiTietSanPham"));
                    int cMaSanPham = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, row.Index, "cMaSanPham"));
                    int cSoluong = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, row.Index, "cSoluong"));
                    decimal cThanhtien = Convert.ToDecimal(DatagridviewHelper.GetStatusDataGridView(dtgv, row.Index, "cThanhtien"));


                    
                    

                    // INSERT tất cả sản phẩm đã chọn vào chitiethoadon :D
                    bool INSERTChiTietHoaDon = ThemChiTietHoaDon(maHoaDon, cMaSanPham, cSoluong, cThanhtien) > 0;
                    if (INSERTChiTietHoaDon)
                    {
                        // Query vào bảng chitieSanPham => lấy ra Số Lượng hiện tại đang có trong kho - số lượng sản phẩm khách muốn gọi = số lượng còn lại trong kho
                        // => update ngược lại vào databas
                        int truSoLuongTon = TruSoLuongTon(cMaChiTietSanPham, cSoluong);
                        if (truSoLuongTon <= 0)
                        {
                            // lỗi cần xem lại :D



                        }

                    }

                    
                    
                }
                // Xóa tất cả các dòng trong DataGridView
                dtgv.Rows.Clear();

                // Xóa tất cả các mục trong ComboBox và đặt lại giá trị mặc định
                cbbAllBan.Items.Clear();
                fTableStatus_Load(null, null);

                SelectCombobox(maban, tenban);
            }
            
        }






        public DataTable SearchSanPham_ByKeyword(string keyword)
        {
            string query = "SELECT * FROM SanPham AS S " +
                           "JOIN ChiTietSanPham AS CS ON S.MaSanPham = CS.MaSanPham " +
                           "WHERE S.TenSanPham LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            return db.ExecuteQuery(query, parameters);
        }
        private void txbTimKiemSP_OnValueChanged(object sender, EventArgs e)
        {
            ViewFlowLayoutPanel(Searchkeywords:txbTimKiemSP.Text.Trim());
        }







        public DataTable SearchProductsByKeywordAndSort(string keyword, bool sortByHDSAsc)
        {
            //"ASC" (tăng dần) và "DESC" (giảm dần)
            string orderBy = sortByHDSAsc ? "ASC" : "DESC";

            string query = "SELECT * FROM SanPham AS S JOIN ChiTietSanPham AS CS ON S.MaSanPham = CS.MaSanPham ORDER BY CS.HanSuDung " + orderBy;
            if (keyword != "")
            {
                 query = "SELECT * FROM SanPham AS S JOIN ChiTietSanPham AS CS ON S.MaSanPham = CS.MaSanPham WHERE S.TenSanPham LIKE @Keyword " +
                          "ORDER BY CS.HanSuDung " + orderBy;
                SqlParameter[] parameters = new SqlParameter[]{new SqlParameter("@Keyword", "%" + keyword + "%")};
                return db.ExecuteQuery(query, parameters);
            }
            return db.ExecuteQuery(query);
        }
        private void cbbSapxepHSD_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewFlowLayoutPanel(Searchkeywords: txbTimKiemSP.Text.Trim(), SapXepHSD: cbbSapxepHSD.SelectedIndex);

        }






        public List<string> LayDanhSachLoaiSanPham()
        {
            string query = "SELECT DISTINCT LoaiSanPham FROM SanPham";
            DataTable data = db.ExecuteQuery(query);

            List<string> danhSachLoaiSanPham = new List<string>();

            DataRow newRow = data.NewRow();
            newRow["LoaiSanPham"] = "All"; // add them row cho DataTable
            data.Rows.InsertAt(newRow, 0);// Chèn hàng mới vào đầu DataTable ở vị trí 0

            foreach (DataRow row in data.Rows)
            {
                danhSachLoaiSanPham.Add(row["LoaiSanPham"].ToString());
            }

            return danhSachLoaiSanPham;
        }
        public DataTable GetProductsByCategory(string categoryName)
        {
            string query = "SELECT SanPham.*, ChiTietSanPham.* " +
                           "FROM SanPham " +
                           "INNER JOIN ChiTietSanPham ON SanPham.MaSanPham = ChiTietSanPham.MaSanPham " +
                           "WHERE SanPham.LoaiSanPham = @CategoryName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("CategoryName", categoryName)
            };
            return db.ExecuteQuery(query, parameters);
        }
        private void cbbTypeSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewFlowLayoutPanel(LocTheoloaiSanPham: cbbTypeSP.Text.Trim() == "All" ? "" : cbbTypeSP.Text.Trim());
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
