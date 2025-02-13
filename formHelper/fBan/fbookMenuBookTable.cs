using QuanLyQuanBia.ClassHelper.fLogin;
using QuanLyQuanBia.ClassHelper;
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
using System.IO;
using QuanLyQuanBia.formHelper.fBan;
using System.Data.SqlClient;
using BUS.ClassHelper;
using System.Collections;
using System.Security.Cryptography;

namespace QuanLyQuanBia.formHelper
{
    public partial class fbookMenuBookTable : Form
    {
        DatabaseHelper db;

        private DateTime? StartTimeHour = null;
        private decimal GiaTien1Hour = 0;

        public decimal giatheogio = 0;
        public fbookMenuBookTable()
        {
            InitializeComponent();
            db = new DatabaseHelper(fLogin.connectionStringSQL);
        }

        void CbbTypeLoaiBan()
        {
            DataTable DATA = db.ExecuteQuery("SELECT * FROM LoaiBan");
            DataRow newRow = DATA.NewRow();
            newRow["TenLoaiBan"] = "All"; 
            DATA.Rows.InsertAt(newRow, 0);

            cbbTypeBan.DataSource = DATA;   
            cbbTypeBan.DisplayMember = "TenLoaiBan"; 
            cbbTypeBan.ValueMember = "MaLoaiBan"; 

        }
            
        void CbbTypeSTT()
        {
            DataTable DATA = db.ExecuteQuery("SELECT DISTINCT TinhTrang FROM Ban");
            DataRow newRow = DATA.NewRow();
            newRow["TinhTrang"] = "All"; // Đặt giá trị cho cột "ColumnName1"
            DATA.Rows.InsertAt(newRow, 0);
            cbbStatusBan.DataSource = DATA; // Gán nguồn dữ liệu cho ComboBox
            cbbStatusBan.DisplayMember = "TinhTrang"; // Hiển thị tình trạng
        }

        void CbbInfoKhachHang()
        {
            DataTable DATA = db.ExecuteQuery("SELECT * FROM KhachHang");
            //DataRow newRow = DATA.NewRow();
            //newRow["HoTen"] = "Khách Văng Lai"; // Đặt giá trị cho cột "ColumnName1"
            //newRow["MaKhachHang"] = 0; // Đặt giá trị cho cột "ColumnName1"
            //DATA.Rows.InsertAt(newRow, 0);
            cbbInfoKhachHang.DataSource = DATA; // Gán nguồn dữ liệu cho ComboBox
            cbbInfoKhachHang.DisplayMember = "HoTen";
            cbbInfoKhachHang.ValueMember = "MaKhachHang";
            cbbInfoKhachHang.SelectedIndex = 0;
        }

        public List<ItemBilliards> itemBan;
        public List<ItemBilliards> itemBansFilter;
        public List<ItemSanPham> itemSP;
        public List<ItemSanPham> itemSPsFilter;

        public DataTable Data;
        public int MaHD=0;
        private void Form_itemValueChanged(object sender, ItemBilliards.ItemValueChangedEventArgs e)
        {
            dtgvBill.Rows.Clear();

            if (e.TinhTrang != "Trống")
            {
                GiaTien1Hour = e.GiaTheoGio;
                StartTimeHour = e.GioBatDauChoi;
                lblSoBan.Text = e.TenBan;
                lbl_IdBill.Text = $"ID Bill : {e.MaHoaDon}";
                lblTimeStart.Text = e.GioBatDauChoi.ToString();
                timerTotalHour.Start();


                panel5.Visible=true;
                MaHD = e.MaHoaDon;
                load_dgr();


            }
            else
            {
                timerTotalHour.Stop();

                lblSoBan.Text = "";
                lbl_IdBill.Text = "";
                lblTimeStart.Text = "00:00:00";
                lblTotalHour.Text = "00:00:00";
                ldl_giaBanTien.Text = "0 VNĐ";
                panel5.Visible = false;
            }

            doDataView();

        }
      private void load_dgr()
        {
            dtgvBill.Rows.Clear();
            Data = LayChiTietHoaDon(MaHD);
            foreach (DataRow item in Data.Rows)
            {


                //string tenSanPham = item["MaChiTietHoaDon"].ToString();
                //string MaHoaDon = item["MaHoaDon"].ToString();
                string MaSanPham = item["MaSanPham"].ToString();
                int SoLuong = Convert.ToInt32(item["SoLuong"]);
                decimal GiaBan = Convert.ToDecimal(item["GiaBan"]);
                string TenSanPham = item["TenSanPham"].ToString();




                int rowIndex = -1;
                if (dtgvBill.RowCount != 0)
                {
                    foreach (DataGridViewRow row in dtgvBill.Rows)
                    {
                        if (row.Cells["cMaSanPham"].Value.ToString() == MaSanPham)
                        {
                            rowIndex = row.Index;

                            int soluongTrenBill = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgvBill, rowIndex, "cSoluong"));
                            DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cSoluong", soluongTrenBill + SoLuong);

                            decimal thanhtienTrenBill = Convert.ToDecimal(DatagridviewHelper.GetStatusDataGridView(dtgvBill, rowIndex, "cThanhtien"));
                            DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cThanhtien", thanhtienTrenBill + GiaBan);
                            break;
                        }
                    }
                }
                else
                {
                    rowIndex = dtgvBill.Rows.Add();
                    DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cSoluong", SoLuong);
                    DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cThanhtien", GiaBan);
                }


                if (rowIndex == -1)
                {
                    rowIndex = dtgvBill.Rows.Add();
                    DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cSoluong", SoLuong);
                    DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cThanhtien", GiaBan);
                }

                //DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cImgDelete", Image.FromFile(@"img\trash_25px.png"));
                DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cTenmon", TenSanPham);
                DatagridviewHelper.SetStatusDataGridView(dtgvBill, rowIndex, "cMaSanPham", MaSanPham);
            }

        }
        public DataTable SearchBanByTrangThai(string keyword)
        {
            string query = "SELECT Ban.MaBan, Ban.TenBan, LoaiBan.TenLoaiBan, LoaiBan.GiaTheoGio, LoaiBan.MieuTa, Ban.TinhTrang,Ban.MaHoaDon, Ban.GioBatDauChoi, Ban.GioKetThuc, LoaiBan.DuongDanHinhAnh  " +
                " FROM Ban INNER JOIN LoaiBan ON Ban.MaLoaiBan = LoaiBan.MaLoaiBan  " +
                " WHERE Ban.TinhTrang=@Keyword ";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Keyword",keyword)
            };

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable SearchBanByTenLoaiBan(string keyword)
        {
            string query = "SELECT Ban.MaBan, Ban.TenBan, LoaiBan.TenLoaiBan, LoaiBan.GiaTheoGio, LoaiBan.MieuTa, Ban.TinhTrang,Ban.MaHoaDon, Ban.GioBatDauChoi, Ban.GioKetThuc, LoaiBan.DuongDanHinhAnh  " +
                " FROM Ban INNER JOIN LoaiBan ON Ban.MaLoaiBan = LoaiBan.MaLoaiBan  " +
                " WHERE LoaiBan.TenLoaiBan=@Keyword ";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Keyword", keyword)
            };

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable SearchBanByall(string keyword,string key)
        {
            string query = "SELECT Ban.MaBan, Ban.TenBan, LoaiBan.TenLoaiBan, LoaiBan.GiaTheoGio, LoaiBan.MieuTa, Ban.TinhTrang,Ban.MaHoaDon, Ban.GioBatDauChoi, Ban.GioKetThuc, LoaiBan.DuongDanHinhAnh  " +
                " FROM Ban INNER JOIN LoaiBan ON Ban.MaLoaiBan = LoaiBan.MaLoaiBan  " +
                " WHERE LoaiBan.TenLoaiBan=@Keyword AND Ban.TinhTrang=@Key ";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Keyword", keyword),
            new SqlParameter("@Key", key)
            };

            return db.ExecuteQuery(query, parameters);
        }

        void doDataView(string trangthai = "All", string tenloaiban = "All")
        {
            flowLayoutPanel.Controls.Clear(); // Xóa tất cả các mục trong flowLayoutPanel


            DataTable dataTable = new DataTable();
            if (trangthai != "All"&&tenloaiban=="All")
            {
                // tìm kiếm theo từ khóa
                dataTable = SearchBanByTrangThai(trangthai);
            }
            else if (tenloaiban != "All"   && trangthai == "All")
            {
                // loc theo loai San Pham
                dataTable = SearchBanByTenLoaiBan(tenloaiban);
            }
            else if (trangthai != "All"&& tenloaiban != "All")
            {
                dataTable = SearchBanByall(tenloaiban,trangthai);            }
            else
            {
                // mặc định
                dataTable = db.ExecuteQuery("SELECT Ban.MaBan, Ban.TenBan, LoaiBan.TenLoaiBan, LoaiBan.GiaTheoGio, LoaiBan.MieuTa," +
                    " Ban.TinhTrang,Ban.MaHoaDon, Ban.GioBatDauChoi, Ban.GioKetThuc, LoaiBan.DuongDanHinhAnh" +
                    " FROM Ban INNER JOIN LoaiBan ON Ban.MaLoaiBan = LoaiBan.MaLoaiBan");
            }

          
            var data = ItemBan.GetListBan(dataTable);
            var list = new ItemBilliards[data.Count];
            int i = 0;
            itemBan = new List<ItemBilliards>();
            itemBansFilter = new List<ItemBilliards>();
            foreach (var item in data)
            {
                list[i] = new ItemBilliards();
               list[i].itemValueChanged += Form_itemValueChanged;
                list[i].DuongDanHinhAnh = Path.GetDirectoryName(Application.ExecutablePath) + item.DuongDanHinhAnh;
              
                list[i].LoadImageAsync();

                list[i].MaBan = item.MaBan;
                list[i].TenBan = item.TenBan;
                list[i].TenLoaiBan = item.TenLoaiBan;
                list[i].GiaTheoGio = item.GiaTheoGio;
                list[i].TinhTrang = item.TinhTrang;
                list[i].MaHoaDon = item.MaHoaDon;
                list[i].MieuTa = item.MieuTa;
                list[i].GioBatDauChoi = item.GioBatDauChoi;
                itemBan.Add(list[i]);
                itemBansFilter.Add(list[i]);
                i++;
            }
            flowLayoutPanel.Controls.AddRange(list);
        }



        private void fbookMenuBookTable_Load(object sender, EventArgs e)
        {
            CbbTypeLoaiBan();
            CbbTypeSTT();
            doDataView();
            CbbInfoKhachHang();
            switch (fLogin.PhanQuyen)
            {

                case "admin":
                    btnChuyenBan.Visible = true;
                    bntAddBan.Visible = true;
               

                    break;
                case "quản lý":


                    break;
                case "nhân viên":
                    btnChuyenBan.Visible = false;
                    bntAddBan.Visible = false;
               
                    break;
                default:
                    MessageBoxHelper.ShowMessageBox("Vui lòng báo Admin cung cấp quyền hạn sự dụng phần mềm!"); this.Close();
                    break;
            }
        }


        void ConvertTotalHour(DateTime? GioBatDauChoi)
        {
            try
            {
                TimeSpan timeDifference;
                if (GioBatDauChoi != null)
                {
                    timeDifference = DateTime.Now - GioBatDauChoi.Value;
                    int hours = timeDifference.Hours;
                    int minutes = timeDifference.Minutes;
                    int seconds = timeDifference.Seconds;
                    lblTotalHour.Text = $"{hours:00}:{minutes:00}:{seconds:00}"; // Định dạng thời gian thành chuỗi
                }
                else
                {
                    lblTotalHour.Text = "00:00:00"; // Xử lý khi GioBatDauChoi là null (hoặc giá trị mặc định khác theo yêu cầu của bạn)
                }
            }
            catch (Exception)
            {  
            }
            
        }

        public decimal TinhToanTienBan(DateTime? GioBatDauChoi, decimal GiaTheoGio)
        {
            decimal totalPrice = 0;
            decimal tongTien = 0;
            try
            {
               
                if (GioBatDauChoi != null)
                {
                    TimeSpan timeDifference = DateTime.Now - GioBatDauChoi.Value;
                    decimal totalHours = (decimal)timeDifference.TotalHours;
                    if (totalHours < 0.5m)
                    {
                        totalHours = 0.5m;
                    }
                    totalPrice = totalHours * GiaTheoGio;
                    giatheogio = GiaTheoGio;
                    foreach (DataGridViewRow row in dtgvBill.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["cThanhtien"].Value != null)
                        {
                            // Lấy giá trị từ cột "cTongTien" của hàng và cộng vào tổng tiền
                            decimal giaTri = Convert.ToDecimal(row.Cells["cThanhtien"].Value);
                            tongTien += giaTri;
                        }
                    }
                    tongTien = Math.Round((tongTien + totalPrice)/1000, 0)*1000;

                }
                ldl_TonggiaTien.Text = $"{tongTien.ToString("N0")} VNĐ";
                ldl_giaBanTien.Text = $"{totalPrice.ToString("N0")} VNĐ";
            }
            catch (Exception)
            {
            }
            return decimal.Round((decimal)tongTien, 2, MidpointRounding.AwayFromZero);


        }
        public decimal TinhToanSoGioChoi(DateTime? GioBatDauChoi)
        {
            decimal decimalValue = 0;
            try
            {
                TimeSpan timeDifference = DateTime.Now - GioBatDauChoi.Value;
                decimal totalHours = (decimal)timeDifference.TotalHours;
                // Chuyển đổi roundedTotalHours thành decimal(18, 2)
                 decimalValue = Math.Round(totalHours, 2);// Làm tròn số giờ với 2 chữ số thập phân
                // giá trị dưới dạng decimal(18, 2)
            }
            catch (Exception)
            {
            }
            return decimal.Round((decimal)decimalValue, 2, MidpointRounding.AwayFromZero);


        }


        private void timerTotalHour_Tick(object sender, EventArgs e)
        {
            ConvertTotalHour(StartTimeHour);
            TinhToanTienBan(StartTimeHour, GiaTien1Hour);
        }


        public DataTable LayChiTietHoaDon(int maHoaDon)
        {
            string query = "SELECT CTHD.*, SP.TenSanPham,SP.Gia  " +
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
       
        public bool CapNhatHoaDon(int maHoaDon, decimal SoGioChoi, decimal thanhTien, int maKhachHang, string tenKhachHang, string hinhThucThanhToan, int TaiKhoanThanhToan)
        {
            string query = "UPDATE HoaDon SET SoGioChoi = @SoGioChoi,ThanhTien = @ThanhTien, MaKhachHang = @MaKhachHang, TenKhachHang = @TenKhachHang, HinhThucThanhToan = @HinhThucThanhToan, TaiKhoanThanhToan = @TaiKhoanThanhToan WHERE MaHoaDon = @MaHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
   {
    new SqlParameter("@SoGioChoi", SoGioChoi),
    new SqlParameter("@ThanhTien", thanhTien),
    new SqlParameter("@MaKhachHang", maKhachHang),
    new SqlParameter("@TenKhachHang", tenKhachHang),
    new SqlParameter("@HinhThucThanhToan", hinhThucThanhToan),
    new SqlParameter("@TaiKhoanThanhToan", TaiKhoanThanhToan),
    new SqlParameter("@MaHoaDon", maHoaDon)
   };

            return db.ExecuteNonQuery(query, parameters) > 0;


        }




        public int CapNhatBan(int maBan, string tinhTrang, int maHoaDon)
        {

            string query = "UPDATE Ban " +
                "SET TinhTrang = @TinhTrang, GioBatDauChoi = NULL, MaHoaDon = @MaHoaDon " +
                "WHERE MaBan = @MaBan";

            SqlParameter[]  parameters = new SqlParameter[]
            {
            new SqlParameter("@MaBan", maBan),
            new SqlParameter("@TinhTrang", tinhTrang),
            new SqlParameter("@MaHoaDon", maHoaDon)
            };
            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected;
        }

        public DataTable TimThongTinBanByIdBill (int maHoaDon)
        {
            string query = "SELECT * FROM Ban WHERE MaHoaDon = @MaHoaDon";

            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@MaHoaDon", maHoaDon)
            };

            DataTable dataTable = db.ExecuteQuery(query, parameters);

            return dataTable;
        }




        private void fbookMenuBookTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerTotalHour.Stop();
        }


        public List<string> thongtin(int MaChamCong)
        {
            string query = " SELECT SoTienBanDau,SoTienDuTinh " +
                         " FROM dbo.ChamCong " +
                         "  WHERE MaChamCong=" + MaChamCong + "";
            DataTable data = db.ExecuteQuery(query);

            List<string> chamcong = new List<string>();

            foreach (DataColumn column in data.Columns)
            {
                chamcong.Add(data.Rows[0][column].ToString());
            }

            return chamcong;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lbl_IdBill.Text == "")
            {
                return;
            }

            int idbill =Convert.ToInt32(lbl_IdBill.Text.Trim().Split(':')[1]);
            // giải quyết vấn đề hóa đơn đã , xong all => giải quyết vấn đề tình trạng bàn và số bàn trả về 0 trong bản bàn :D
            string hinhthucthanhtoan = cbbHinhThucThanhToan.Text;
            if (hinhthucthanhtoan == "")
            {
                MessageBoxHelper.ShowMessageBox("Vui lòng chọn hình thức thanh toán!");return;
            }
            string thongTinkhachHang = cbbInfoKhachHang.Text;
            int makhachhang = 0;
            //if (thongTinkhachHang.Contains("Khách Văng Lai"))
            //{
            //    makhachhang = 1;
            //    thongTinkhachHang = "Khách Văng Lai";
            //}
            //else
            //{

            //}
            makhachhang = (int)cbbInfoKhachHang.SelectedValue;
            thongTinkhachHang = cbbInfoKhachHang.Text;

            //timerTotalHour.Stop(); //stop time

            decimal tienban = TinhToanTienBan(StartTimeHour, GiaTien1Hour);

            if (MessageBoxHelper.Show("Bạn có muốn In Hóa Đơn ?") == DialogResult.Yes)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                if (CapNhatHoaDon(idbill, TinhToanSoGioChoi(StartTimeHour), tienban, makhachhang, thongTinkhachHang, hinhthucthanhtoan, fLogin.MaNhanVien))
                {
                    DataTable data = TimThongTinBanByIdBill(idbill);

                    // Kiểm tra nếu bảng dữ liệu có ít nhất một dòng
                    if (data.Rows.Count > 0)
                    {
                        DataRow row = data.Rows[0];
                        int MaBan = (int)row["MaBan"];
                        string TenBan = row["TenBan"].ToString();
                        int MaLoaiBan = (int)row["MaLoaiBan"];

                        string MaHoaDon = row["MaHoaDon"].ToString();

                        CapNhatBan(MaBan, "Trống", 0);
                        doDataView();
                    }


                    }
                }
            decimal newMoney = decimal.Parse(thongtin(fMain.MaChamCong)[1])+ tienban;
            UpdateTien(fMain.MaChamCong,newMoney);
                btnThanhToan.Visible = false;
        }
        public bool UpdateTien(int MaChamCong,decimal tien)
        {
            string query = "UPDATE ChamCong SET SoTienDuTinh = @SoTienDuTinh WHERE MaChamCong = @MaChamCong";
            SqlParameter[] parameters = new SqlParameter[]
   {
    new SqlParameter("@MaChamCong", MaChamCong),
    new SqlParameter("@SoTienDuTinh", tien)
  
   };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
        private void btnImgfKhachHang_Click(object sender, EventArgs e)
        {
            Common.ShowForm(new fQLKhachHang("Đây Là Form Thanh Toán"));
            
        }

        private void dtgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotalHour_Click(object sender, EventArgs e)
        {

        }

        private void bntAddBan_Click(object sender, EventArgs e)
        {
            Common.ShowForm(new fThemBanMoi(true));
            doDataView();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (lbl_IdBill.Text == "")
            {
                return;
            }
            timerTotalHour.Stop();
            btnThanhToan.Visible = true;
           
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            Common.ShowForm(new fThemBanMoi(false));
            doDataView();
        }

        private void cbbTypeBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            doDataView( cbbStatusBan.Text.Trim(), cbbTypeBan.Text.Trim());
        }

        private void cbbStatusBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            doDataView( cbbStatusBan.Text.Trim(), cbbTypeBan.Text.Trim());
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var tieude = "Hóa Đon Bán Hàng ";
            var Store = "Demo Store ok bro";
            var Addess = "Số 1 VN";
            var Phone = 0398461674;
            var w = printDocument1.DefaultPageSettings.PaperSize.Width;
            var h = printDocument1.DefaultPageSettings.PaperSize.Height;

            e.Graphics.DrawString("Thời Gian In:" + DateTime.Now, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(490, 170));
            e.Graphics.DrawString(Store.ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(330, 30));
            e.Graphics.DrawString(Addess.ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(380, 60));
            e.Graphics.DrawString("DT" + Phone, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(362, 90));

            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, 120), new Point(w - 10, 120));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, 130), new Point(w - 10, 130));
            e.Graphics.DrawString(tieude, new Font("Courier New", 16, FontStyle.Bold), Brushes.Red, new Point(300, 135));
            e.Graphics.DrawString(lbl_IdBill.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(280, 170));
            e.Graphics.DrawString("Người Bán Hàng:"+ fLogin.HoTenNV.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, 170));
            e.Graphics.DrawString("Tên Khách Hàng:"+cbbInfoKhachHang.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, 215));
            //e.Graphics.DrawString("Địa Chỉ:"+, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, 240));
            e.Graphics.DrawString("Điện Thoại:", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, 240));

            e.Graphics.DrawString("STT", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, 280));
            e.Graphics.DrawString("Tên Dịch Vụ", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(60, 280));
            //e.Graphics.DrawString("Dơn VT", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(350, 280));
            e.Graphics.DrawString("SL", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(400, 280));
            e.Graphics.DrawString("Đơn Giá ", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(530, 280));
            e.Graphics.DrawString("Thành Tiền ", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(650, 280));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, 305), new Point(w - 10, 305));
            var a = 2;
            var y = 315;
            e.Graphics.DrawString("1", new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(20, y));
            e.Graphics.DrawString(lblSoBan.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(60, y));
            //e.Graphics.DrawString(Rows[].ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(350, y));
            e.Graphics.DrawString(lblTotalHour.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(400, y));
            e.Graphics.DrawString(giatheogio.ToString()+"/h", new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(530, y));
            e.Graphics.DrawString(ldl_giaBanTien.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(650, y));
            y += 20;
            foreach (DataRow Rows  in Data.Rows)
            {
                //decimal tien = decimal.Parse(Rows[4].ToString()) * int.Parse(Rows[3].ToString());
                
                e.Graphics.DrawString(a.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(20, y));
                e.Graphics.DrawString(Rows[5].ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(60, y));
                //e.Graphics.DrawString(Rows[].ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(350, y));
                e.Graphics.DrawString(Rows[3].ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(400, y));
                e.Graphics.DrawString(Rows[6].ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(530, y));
                e.Graphics.DrawString(Rows[4].ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Green, new Point(650, y));
                y += 20;
                a++;
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, y + 30), new Point(w - 10, y + 30));

            e.Graphics.DrawString("Tổng Tiền : " +ldl_TonggiaTien.Text+ "VND", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(500, y + 100));
            e.Graphics.DrawString("Hình Thức Thanh Toán: "+cbbHinhThucThanhToan.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(400, y + 50));
            e.Graphics.DrawString("Thank's kiu baby da mua hàng  ", new Font("Courier New", 12, FontStyle.Bold), Brushes.Red, new Point(280, y + 250));

        }

        private void btnThemon_Click(object sender, EventArgs e)
        {
            View_dv();
        }
        private void View_dv()
        {

            flowLayoutPanel.Controls.Clear();
            DataTable dataTable = new DataTable();
            dataTable = db.ExecuteQuery("SELECT * FROM SanPham AS S JOIN ChiTietSanPham AS CS ON S.MaSanPham = CS.MaSanPham");
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

        public bool CapNhatKho(int maSanPham)
        {
            string query = "UPDATE ChiTietSanPham SET SoLuongTon = SoLuongTon - 1 WHERE MaSanPham = @MaSanPham";
            //if (Down)
            //{
            //    query = "UPDATE ChiTietSanPham SET SoLuongTon = SoLuongTon + 1 WHERE MaSanPham = @MaSanPham";
            //}
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaSanPham", maSanPham) };
            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool CapNhatSoLuongVaGiaBanByChiTietHoaDon(int maHoaDon, int maSanPham, decimal gia)
        {
            // Tạo câu truy vấn để cập nhật SoLuong và GiaBan
            string query = "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + 1, GiaBan = GiaBan + @AdditionalPrice " +
                           "WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";
            //if (donw)
            //{
            //    query = "UPDATE ChiTietHoaDon SET SoLuong = SoLuong - 1, GiaBan = GiaBan - @AdditionalPrice " +
            //               "WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";
            //}

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
        private void Form1_itemValueChanged(object sender, ItemSanPham.ItemValueChangedEventArgs e)
        {
            if (sender.ToString().Contains("Thêm vào Rỏ Hàng") && e.NameSP != "" && e.sLvalue != 0)
            {

                if (CapNhatKho(e.MASP)) // trừ đi 1 san pham trong databas
                {
                    int maHoaDon = MaHD;
                    bool INSERTChiTietHoaDon = CapNhatSoLuongVaGiaBanByChiTietHoaDon(maHoaDon, e.MASP, e.Value); 
                    // Update thêm số lượng + 1 cho bảng ChiTietHoaDon hiện có ( điều kiện MaHoaDon và MASP phải có trong bảng ChiTietHoaDon)
                   if (!INSERTChiTietHoaDon)
                    {
                        INSERTChiTietHoaDon = ThemChiTietHoaDon(maHoaDon, e.MASP, 1, e.Value) > 0; // INSERT 1 ChiTietHoaDon mới

                    }
                    e.IsAdd = true; // Add Thành Công - Sản Phẩm trên View





                    load_dgr();
                    View_dv();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            doDataView();
            panel5.Visible = false;
        }
    }
}
