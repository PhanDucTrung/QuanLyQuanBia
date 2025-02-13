using Bunifu.Framework.UI;
using BUS.ClassHelper;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using QuanLyQuanBia.formHelper.ItemSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.formHelper
{
    public partial class fPhieuNhapMoi : Form
    {
        DatabaseHelper db;
        string imagePath;
        //private ComboBoxAutoComplete combo;
        public static bool  isAddSuccess = false;
        public fPhieuNhapMoi()
        {
            InitializeComponent();
            this.BackColor = Color.DodgerBlue;
            this.Padding = new Padding(1, 1, 1, 1);
            db = new DatabaseHelper(fLogin.connectionStringSQL);

            // Gọi hàm để lấy danh sách đơn vị tính
            List<string> donViTinhList = LayDanhSachDonViTinh();
            cbbDonVi.DataSource = donViTinhList;
            //// Đổ danh sách đơn vị tính vào ComboBox
            //foreach (string donViTinh in donViTinhList)
            //{
            //    cbbDonVi.Items.Add(donViTinh);
            //}
            List<string> danhSachLoaiSanPham = LayDanhSachLoaiSanPham();
            cbbLoai.DataSource = danhSachLoaiSanPham;
           
        }
        public fPhieuNhapMoi(string TileName , string MachiTietSP,string MaSP, string tenSP , DateTime dateNhap , string donvi , string Loai , DateTime DtTimeHSD , decimal gianhap , decimal giabanle , string soluongCu , string nguonNhap , string lienlac , string pathIMG)
        {
            InitializeComponent();
            this.BackColor = Color.DodgerBlue;
            this.Padding = new Padding(1, 1, 1, 1);
            db = new DatabaseHelper(fLogin.connectionStringSQL);

            // Gọi hàm để lấy danh sách đơn vị tính
            List<string> donViTinhList = LayDanhSachDonViTinh();
            cbbDonVi.DataSource = donViTinhList;
            //// Đổ danh sách đơn vị tính vào ComboBox
            //foreach (string donViTinh in donViTinhList)
            //{
            //    cbbDonVi.Items.Add(donViTinh);
            //}
            List<string> danhSachLoaiSanPham = LayDanhSachLoaiSanPham();
            cbbLoai.DataSource = danhSachLoaiSanPham;

            lbTileName.Text = TileName;
            txbMaChiTietSanPham.Text = MachiTietSP;
            txbMaSP.Text = MaSP;
            txbTenSP.Text = tenSP;
            DateTimeNhap.Value = dateNhap;
            cbbDonVi.SelectedItem = donvi;
            cbbLoai.SelectedItem = Loai;
            DateTimeHSD.Value = DtTimeHSD;

            string GiaNhap = gianhap.ToString().Trim();//.Substring(0, gianhap.ToString().IndexOf(','));
            string GiaBanLe = giabanle.ToString().Trim();//.Substring(0, giabanle.ToString().IndexOf(','));

            txbGiaNhap.Text = GiaNhap.ToString();
            txbGiaBanLe.Text = GiaBanLe.ToString();

            txbSlCu.Text = soluongCu;
           
            txbNguonNhap.Text = nguonNhap;
            txbLienLac.Text = lienlac;
            imagePath = pathIMG;

            if (Common.FileTonTai(Common.PathExE()+ imagePath))
            {
                pictureBox.Image = Image.FromFile(Common.PathExE() + imagePath);
            }
            btnAdd.ButtonText = "Update";
            btnAddIMG.ButtonText = "Sửa ảnh Sản Phẩm";
            txbGiaBanLe_OnValueChanged(null, null);
            txbGiaNhap_OnValueChanged(null, null);
        }
        
        private void btnAddIMG_Click(object sender, EventArgs e)
        {
             imagePath = Common.SelectImage(); // Gọi hàm để chọn hình ảnh
            if (!string.IsNullOrEmpty(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
                string NameFile = Common.Path_NameFile(imagePath);
                if (Common.CopyFile(imagePath, Common.PathExE() + $"\\img\\SanPham\\{NameFile}"))
                {
                    imagePath = $"\\img\\SanPham\\{NameFile}";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (imagePath == "" || txbTenSP.Text == ""|| txbSlMoi.Text == ""|| txbGiaNhap.Text == "" || txbGiaBanLe .Text.Trim() == ""|| txbNguonNhap.Text == "" || txbLienLac.Text == ""|| cbbDonVi.Text == "" || cbbLoai.Text == "")
            {
                MessageBoxHelper.ShowMessageBox("Vui lòng điền đầy đủ thông tin, Thử lại sau!");return;
            }







            if (DateTimeNhap.Value > DateTime.Now || DateTimeHSD.Value <= DateTime.Now)
            {
                MessageBoxHelper.ShowMessageBox("Ngày Nhập Hàng, không thể lớn hơn thời gian hiện tại! Vui lòng nhập lại"); return;
            }

            switch (btnAdd.ButtonText)
            {
                case "Update": { update(); break; }

                case "Nhập": { ThemMoi(); break; }

                case "Buy": { NhapHang() ;  break; }

                default: MessageBoxHelper.ShowMessageBox("có lỗi ");
                    break;
            }
            //if (btnAdd.ButtonText != "Update")
            //{
            //    ThemMoi();
            //}
            //else 
            //{
            //    update();

            //}

          
            
        }



        void ThemMoi ()
        {

            int newIdSP = ThemSanPham(txbTenSP.Text.Trim(), Convert.ToInt32(txbGiaBanLe.Text.Trim()), cbbLoai.Text.Trim(), txbTenSP.Text, imagePath);
            int newNhaphang = NhapHang(newIdSP, Convert.ToInt32(txbSlMoi.Text.Trim()), DateTimeNhap.Value, Convert.ToDecimal(txbGiaNhap.Text.Trim()));
            int newIdCTHD = ThemChiTietSanPham(newIdSP, cbbDonVi.Text.Trim(),txbTenSP.Text, Convert.ToInt32(txbSlMoi.Text.Trim()), DateTimeHSD.Value, Convert.ToDecimal(txbGiaNhap.Text.Trim()), txbNguonNhap.Text.Trim(), txbLienLac.Text.Trim(), DateTimeNhap.Value);
            if (newIdCTHD > 0)
            {
                isAddSuccess = true;
                if (MessageBoxHelper.Show($"Thêm thành công Sản Phẩm: {txbTenSP.Text.Trim()}\nĐóng của sổ ?") == DialogResult.Yes)
                {
                    this.Close();
                }
            }    
             
        }
        void NhapHang()
        {
            int newNhaphang = NhapHang(int.Parse(txbMaSP.Text.Trim()), Convert.ToInt32(txbSlMoi.Text.Trim()), DateTimeNhap.Value, Convert.ToDecimal(txbGiaNhap.Text.Trim()));
            int soluongNew = Common.ConverINT(txbSlCu.Text.Trim())+ Common.ConverINT(txbSlMoi.Text.Trim());
            UpdateChiTietSanPham(Common.ConverINT(txbMaChiTietSanPham.Text.Trim()), cbbDonVi.Text.Trim(),txbTenSP.Text, soluongNew, DateTimeHSD.Value, Convert.ToDecimal(txbGiaNhap.Text.Trim()), txbNguonNhap.Text.Trim(), txbLienLac.Text.Trim());

            if (newNhaphang > 0)
            {
                isAddSuccess = true;
                if (MessageBoxHelper.Show($"Nhập Sản Phẩm: {txbTenSP.Text.Trim()}\n  thành công. Đóng của sổ ?") == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }

        void update ()
        {
            if (UpdateSanPham(Convert.ToInt32(txbMaSP.Text.Trim()), txbTenSP.Text.Trim(),Convert.ToDecimal(txbGiaBanLe.Text.Trim()), cbbLoai.Text.Trim(), $" {txbTenSP.Text.Trim()}",imagePath))
            {
                int soluongNew = Common.ConverINT(txbSlCu.Text.Trim());//+ Common.ConverINT(txbSlMoi.Text.Trim());
                if (UpdateChiTietSanPham(Common.ConverINT(txbMaChiTietSanPham.Text.Trim()),cbbDonVi.Text.Trim(), $"{txbTenSP.Text}", soluongNew,DateTimeHSD.Value,Convert.ToDecimal(txbGiaNhap.Text.Trim()), txbNguonNhap.Text.Trim(), txbLienLac.Text.Trim()))
                {
                    isAddSuccess = true;
                    if (MessageBoxHelper.Show($"Update thành công Sản Phẩm: {txbTenSP.Text.Trim()}\nĐóng của sổ ?") == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBoxHelper.ShowMessageBox("Update chi tiet san pham that bai"); return;
                }
            }
            else
            {
                MessageBoxHelper.ShowMessageBox("Update san pham that bai"); return;
            }
        }

       


        public List<string> LayDanhSachDonViTinh()
        {
            string query = "SELECT DISTINCT DonViTinh FROM ChiTietSanPham";
            DataTable data = db.ExecuteQuery(query);

            List<string> danhSachDonViTinh = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                danhSachDonViTinh.Add(row["DonViTinh"].ToString());
            }

            return danhSachDonViTinh;
        }
        public List<string> LayDanhSachLoaiSanPham()
        {
            string query = "SELECT DISTINCT LoaiSanPham FROM SanPham";
            DataTable data = db.ExecuteQuery(query);

            List<string> danhSachLoaiSanPham = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                danhSachLoaiSanPham.Add(row["LoaiSanPham"].ToString());
            }

            return danhSachLoaiSanPham;
        }
        public List<string> LayDanhSachtenSanPham()
        {
            string query = "SELECT DISTINCT TenSanPham FROM SanPham";
            DataTable data = db.ExecuteQuery(query);

            List<string> danhSachTenSanPham = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                danhSachTenSanPham.Add(row["TenSanPham"].ToString());
            }

            return danhSachTenSanPham;
        }
        public List<string> LaySanPham(string TenSanPham)
        {
            string query = "SELECT SanPham.*, ChiTietSanPham.* " +
                         "FROM SanPham " +
                         "LEFT JOIN ChiTietSanPham ON SanPham.MaSanPham = ChiTietSanPham.MaSanPham" +
                         "  WHERE TenSanPham=N'"+TenSanPham+"'";
            DataTable data = db.ExecuteQuery(query);

            List<string> SanPham = new List<string>();
            
            foreach (DataColumn column  in data.Columns)
            {
                SanPham.Add(data.Rows[0][column].ToString());
            }

            return SanPham;
        }


        private void fPhieuNhapMoi_Load(object sender, EventArgs e)
        {
            if (btnAdd.ButtonText == "Update")
            {
                txbSlMoi.Visible = false;
                bunifuCustomLabel5.Visible = false;
            }
            else
            {
                txbSlCu.Enabled = false;
            }
           
        }



        // Cập nhật thông tin ChiTietSanPham
        public bool UpdateChiTietSanPham(int maChiTietSanPham, string donViTinh, string ghiChu, int soLuongTon, DateTime hanSuDung, decimal giaNhap, string nguonNhap, string chiTietLienLac)
        {
            string query = "UPDATE ChiTietSanPham " +
                           "SET DonViTinh = @DonViTinh, GhiChu = @GhiChu, SoLuongTon = @SoLuongTon, HanSuDung = @HanSuDung, GiaNhap = @GiaNhap, NguonNhap = @NguonNhap, ChiTietLienLac = @ChiTietLienLac " +
                           "WHERE MaChiTietSanPham = @MaChiTietSanPham";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@DonViTinh", donViTinh),
        new SqlParameter("@GhiChu", ghiChu),
        new SqlParameter("@SoLuongTon", soLuongTon),
        new SqlParameter("@HanSuDung", hanSuDung),
        new SqlParameter("@GiaNhap", giaNhap),
        new SqlParameter("@NguonNhap", nguonNhap),
        new SqlParameter("@ChiTietLienLac", chiTietLienLac),
        new SqlParameter("@MaChiTietSanPham", maChiTietSanPham)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }


        // Cập nhật thông tin SanPham
        public bool UpdateSanPham(int maSanPham, string tenSanPham, decimal gia, string loaiSanPham, string ghiChu, string pathImg)
        {
            string query = "UPDATE SanPham " +
                           "SET TenSanPham = @TenSanPham, Gia = @Gia, LoaiSanPham = @LoaiSanPham, GhiChu = @GhiChu, pathImg = @pathImg " +
                           "WHERE MaSanPham = @MaSanPham";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TenSanPham", tenSanPham),
        new SqlParameter("@Gia", gia),
        new SqlParameter("@LoaiSanPham", loaiSanPham),
        new SqlParameter("@GhiChu", ghiChu),
        new SqlParameter("@pathImg", pathImg),
        new SqlParameter("@MaSanPham", maSanPham)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }




        public int ThemSanPham(string tenSanPham, decimal giaBanLe, string loaiSanPham, string ghiChu, string pathImg)
        {
            try
            {
                
               
                // Query để chèn dữ liệu mới vào bảng SanPham
                string query = "INSERT INTO SanPham (TenSanPham, Gia, LoaiSanPham, GhiChu, pathImg) " +
                               "VALUES (@TenSanPham, @Gia, @LoaiSanPham, @GhiChu, @pathImg); SELECT SCOPE_IDENTITY();";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TenSanPham", tenSanPham),
            new SqlParameter("@Gia", giaBanLe),
            new SqlParameter("@LoaiSanPham", loaiSanPham),
            new SqlParameter("@GhiChu", ghiChu),
            new SqlParameter("@pathImg", pathImg)
                };

                // Thực hiện truy vấn thêm sản phẩm và lấy ID của sản phẩm vừa thêm
                int newProductId = db.ExecuteInsertAndGetIdentity(query, parameters);

                return newProductId;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
        public int NhapHang(int MaSanPham , int SoLuongNhap, DateTime NgayNhapHang,decimal GiaNhap)
        {
            try
            {
                // Query để chèn dữ liệu mới vào bảng SanPham
                string query = "INSERT INTO dbo.NhapHang (MaSanPham,SoLuongNhap,NgayNhapHang,GiaNhap) " +
                               "VALUES(@MaSanPham,@SoLuongNhap,@NgayNhapHang,@GiaNhap); SELECT SCOPE_IDENTITY();";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
            
            new SqlParameter("@MaSanPham", MaSanPham),
            new SqlParameter("@SoLuongNhap", SoLuongNhap),
            new SqlParameter("@NgayNhapHang", NgayNhapHang),
            new SqlParameter("@GiaNhap", GiaNhap),

                };

                // Thực hiện truy vấn thêm sản phẩm và lấy ID của sản phẩm vừa thêm
                int newProductId = db.ExecuteInsertAndGetIdentity(query, parameters);

                return newProductId;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
        public int ThemChiTietSanPham(int maSanPham, string donViTinh, string ghiChu, int soLuongTon, DateTime hanSuDung, decimal giaNhap, string nguonNhap, string chiTietLienLac, DateTime ngayNhap)
        {
            try
            {
                // Chuyển đổi giá trị số thực thành kiểu decimal(18, 3) trong SQL

                // Query để chèn dữ liệu mới vào bảng ChiTietSanPham
                string query = "INSERT INTO ChiTietSanPham (MaSanPham, DonViTinh, GhiChu, SoLuongTon, HanSuDung, GiaNhap, NguonNhap, ChiTietLienLac, NgayNhap) " +
                               "VALUES (@MaSanPham, @DonViTinh, @GhiChu, @SoLuongTon, @HanSuDung, @GiaNhap, @NguonNhap, @ChiTietLienLac, @NgayNhap); SELECT SCOPE_IDENTITY();";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
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

                // Thực hiện truy vấn thêm chi tiết sản phẩm và lấy ID của chi tiết sản phẩm vừa thêm
                int newChiTietSanPhamId = db.ExecuteInsertAndGetIdentity(query, parameters);

                return newChiTietSanPhamId;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }



        private void txbGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txbGiaNhap_OnValueChanged(object sender, EventArgs e)
        {
         
            if (txbGiaNhap.Text != "")
            {
                if (int.TryParse(txbGiaNhap.Text.Trim(), out int amount))
                {
                    if (amount > 0)
                    {
                        labelResult.Text = amount.ToString("N0") + " VNĐ"; // Định dạng số tiền và thêm đơn vị
                    }
                    else
                    {
                        MessageBox.Show("giá tiền ko dc âm ");
                        txbGiaNhap.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("giá tiền ko hợp lệ  ");
                    txbGiaNhap.Text = "";
                }
            }
        }

        private void txbSlCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txbSlMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txbGiaBanLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txbGiaBanLe_OnValueChanged(object sender, EventArgs e)
        {

            if (txbGiaBanLe.Text != "")
            {
                if (int.TryParse(txbGiaBanLe.Text.Trim(), out int amount))
                {
                    if (amount > 0)
                    {
                        labelResult2.Text = amount.ToString("N0") + " VNĐ"; // Định dạng số tiền và thêm đơn vị
                    }
                    else
                    {
                        MessageBox.Show("giá tiền ko dc âm ");
                        txbGiaBanLe.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("giá tiền ko hợp lệ  ");
                    txbGiaBanLe.Text = "";
                }
            }
        }

        private void lsbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSanPham.SelectedIndex != -1)
            {
                // Hiển thị nội dung của mục được chọn lên TextBox
                txbTenSP.Text = lsbSanPham.SelectedItem.ToString();
                lsbSanPham.Visible = false;
                
                List<string> SanPham = LaySanPham(txbTenSP.Text);
                txbMaSP.Text = SanPham[0].ToString();
                txbMaChiTietSanPham.Text = SanPham[6].ToString();
                DateTimeNhap.Value = Convert.ToDateTime(SanPham[15]);
                cbbDonVi.SelectedItem= SanPham[8];
                cbbLoai.SelectedItem = SanPham[3];
                DateTimeHSD.Value = Convert.ToDateTime(SanPham[11]);
                txbGiaNhap.Text = SanPham[12].ToString();
                txbGiaBanLe.Text = SanPham[2].ToString();

                txbSlCu.Text = SanPham[10].ToString();

                txbNguonNhap.Text = SanPham[13];
                txbLienLac.Text = SanPham[14];
                imagePath = SanPham[5];

                if (Common.FileTonTai(Common.PathExE() + imagePath))
                {
                    pictureBox.Image = Image.FromFile(Common.PathExE() + imagePath);
                }

                btnAdd.ButtonText= "Buy";
            }
        }
        // Hàm loại bỏ dấu
        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        private void txbTenSP_OnValueChanged(object sender, EventArgs e)
        {
            if (txbTenSP.Text.Trim()!="")
            {
                List<string> tensp = LayDanhSachtenSanPham().Where(item => RemoveDiacritics(item.ToLower()).Contains(txbTenSP.Text)).ToList();
                lsbSanPham.Items.Clear(); // Xóa danh sách trước khi hiển thị kết quả mới
                lsbSanPham.Visible = true; // Xóa danh sách trước khi hiển thị kết quả mới
                foreach (string item in tensp)
                {
                    lsbSanPham.Items.Add(item);
                }
                  if (tensp.Count > 0)
            {
                lsbSanPham.Visible = true;
            }
            else
            {
                lsbSanPham.Visible = false;
            }
            }
          
        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
