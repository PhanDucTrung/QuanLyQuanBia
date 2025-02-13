using BUS.ClassHelper;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.formHelper.nhanvien
{
    public partial class fNhanVien : Form
    {
        DatabaseHelper databaseHelper;
        private string pathImg = "";
        public int MaQuyen=1;
        public int newNhanvien;

        public fNhanVien()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewRow dataGridViewRow = dtgv.SelectedRows[0];

                    txbName.Text = dataGridViewRow.Cells["cHoTen"].Value.ToString();
                    txbDiaChi.Text = dataGridViewRow.Cells["cDiaChi"].Value.ToString();
                    txbSodienthoai.Text = dataGridViewRow.Cells["cSDT"].Value.ToString();
                    DateTimeNgaySinh.Value = Convert.ToDateTime(dataGridViewRow.Cells["cNgaySinh"].Value);
                    DateTimeNgayVaolam.Value = Convert.ToDateTime(dataGridViewRow.Cells["cNgayVaoLam"].Value);
                    txbTaiKhoan.Text = dataGridViewRow.Cells["cTaiKhoan"].Value.ToString();
                    txbMatKhau.Text = dataGridViewRow.Cells["cMatKhau"].Value.ToString();

                    cbbLoaiNhanVien.SelectedItem = dataGridViewRow.Cells["cLoaiNhanVien"].Value.ToString();

                    cbbChucVu.Text = dataGridViewRow.Cells["cChucVu"].Value.ToString();
                    txbMaNhanVien.Text = dataGridViewRow.Cells["cMaTaiKhoan"].Value.ToString();


                    pathImg = dataGridViewRow.Cells["cPathImg"].Value.ToString();
                    if (Common.FileTonTai(Common.PathExE() + pathImg))
                    {
                        pictureBox.Image = Image.FromFile(Common.PathExE() + pathImg);
                    }
                    else
                    {
                        pictureBox.Image = null;
                    }

                }
            }
            catch (Exception)
            {

              
            }
        
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            
            databaseHelper = new DatabaseHelper(fLogin.connectionStringSQL);
            loadCbb();
            loadNhanVien();
            cbbChucVu.SelectedIndex = 0;
            
        }


        void loadNhanVien(string nameNhanVien = "")
        {

            string query = "select * from TaiKhoan";
            SqlParameter[] parameters = null;

            if (nameNhanVien != "")
            {
                query = "SELECT * FROM TaiKhoan WHERE HoTen LIKE @TenNhanVien";
                parameters = new SqlParameter[]{ new SqlParameter("@TenNhanVien", "%" + nameNhanVien + "%")};
            }
           
            DataTable DATA = databaseHelper.ExecuteQuery(query, parameters);
            DATA.Columns.Add("STT", typeof(string));
            DATA.Columns.Add("ImgAvatar", typeof(Image));
            int Y = 0;
            for (int i = 0; i < DATA.Rows.Count; i++)
            {
                DataRow row = DATA.Rows[i];
                string pathIMG = Common.PathExE()+ row["PathImg"].ToString();
                if (Common.FileTonTai(pathIMG))
                {
                    DATA.Rows[i]["ImgAvatar"] = Image.FromFile(pathIMG);
                }
               
                Y++;
                DATA.Rows[i]["STT"] = Y;
            }
            dtgv.DataSource = DATA;
        }


        void loadCbb()
        {
           
            DataTable DATA2 = databaseHelper.ExecuteQuery("SELECT * FROM Quyen");
            cbbChucVu.DataSource = DATA2; // Gán nguồn dữ liệu cho ComboBox
            cbbChucVu.DisplayMember = "TenQuyen"; // Hiển thị tên quyền
            cbbChucVu.ValueMember = "MaQuyen"; // Gán giá trị MaQuyen cho ComboBox
          
            DataTable DATA1 = databaseHelper.ExecuteQuery("SELECT DISTINCT LoaiNhanVien FROM TaiKhoan");
            foreach (DataRow row in DATA1.Rows)
            {
                cbbLoaiNhanVien.Items.Add(row["LoaiNhanVien"].ToString());
            }
        }



        private void btnAddNhanVienNew_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("Bạn thực sự muốn tạo tài khoản mới!") == DialogResult.Yes)
            {
                btnDangKyTaiKhoan.Visible = true;
                btnSuaThongTin.Visible = false;
                pictureBox.Image = null;
                txbMaNhanVien.Text = "";
                txbName.Text = "";
                txbDiaChi.Text = "";
                txbTaiKhoan.Text = "";
                txbMatKhau.Text = "";
                //cbbChucVu.SelectedIndex = -1;
                //cbbLoaiNhanVien.SelectedIndex = -1;
                //btnThoat.Visible = true;
            }
            else
            {
                btnDangKyTaiKhoan.Visible = false;
                btnSuaThongTin.Visible=true;
                //btnThoat.Visible = false;
            }

        }



        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            InsertNhanVien(txbName.Text, cbbChucVu.Text, cbbLoaiNhanVien.Text, txbDiaChi.Text, txbSodienthoai.Text, DateTimeNgaySinh.Value, DateTimeNgayVaolam.Value, txbTaiKhoan.Text, txbMatKhau.Text);
            btnDangKyTaiKhoan.Visible = false;
            btnSuaThongTin.Visible = true;
            //btnThoat.Visible = false;


        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            UpdateNhanVien(Convert.ToInt32(txbMaNhanVien.Text), txbName.Text, cbbChucVu.Text, cbbLoaiNhanVien.Text, txbDiaChi.Text, txbSodienthoai.Text, DateTimeNgaySinh.Value, DateTimeNgayVaolam.Value, txbTaiKhoan.Text, txbMatKhau.Text, pathImg);
            
        }

        // kieetr tra xem user có tồn tại hay k :D
        public bool IsTaiKhoanExisted(string taiKhoan)
        {  
            SqlParameter[] parameters = new SqlParameter[]
           {
            new SqlParameter("@TaiKhoan", taiKhoan),
           };
            return databaseHelper.ExecuteNonQuery("SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan.TaiKhoan = @TaiKhoan", parameters) > 0;
        }
        // Thêm nhân viên
        public void InsertNhanVien(string hoTen, string chucVu, string loaiNhanVien, string diaChi, string soDienThoai, DateTime ngaySinh, DateTime ngayVaoLam, string taiKhoan, string matKhau)
        {

            if (IsTaiKhoanExisted(taiKhoan))
            {
                MessageBoxHelper.ShowMessageBox("Tên người dùng đã tồn tại, vui lòng thay đổi tên đăng nhập! ");return;
            }
            string query = @"INSERT INTO TaiKhoan (HoTen, ChucVu, LoaiNhanVien, DiaChi, SoDienThoai, NgaySinh, NgayVaoLam, TaiKhoan, MatKhau)
                        VALUES (@HoTen, @ChucVu, @LoaiNhanVien, @DiaChi, @SoDienThoai, @NgaySinh, @NgayVaoLam, @TaiKhoan, @MatKhau)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@HoTen", hoTen),
            new SqlParameter("@ChucVu", chucVu),
            new SqlParameter("@LoaiNhanVien", loaiNhanVien),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@SoDienThoai", soDienThoai),
            new SqlParameter("@NgaySinh", ngaySinh),
            new SqlParameter("@NgayVaoLam", ngayVaoLam),
            new SqlParameter("@TaiKhoan", taiKhoan),
            new SqlParameter("@MatKhau", matKhau)
            };
            newNhanvien = databaseHelper.ExecuteInsertAndGetIdentity(query, parameters);
            ThemQuyenNhanvien(newNhanvien,MaQuyen);

            MessageBoxHelper.ShowMessageBox($"Thêm người dùng {(newNhanvien >0 ? "Thành Công": "Thất bại")}");

            loadNhanVien();
        }

        public void ThemQuyenNhanvien(int Manhanvien,int Maquyen) 
        {
            string query = @"INSERT INTO dbo.TaiKhoanQuyen (MaTaiKhoan,MaQuyen)
                                VALUES (@MaNhanVien,@MaQuyen)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaNhanVien", Manhanvien),
            new SqlParameter("@MaQuyen", Maquyen)
            };
            databaseHelper.ExecuteNonQuery(query, parameters);
          

        }

        // Sửa thông tin nhân viên
        public void UpdateNhanVien(int maNhanVien, string hoTen, string chucVu, string loaiNhanVien, string diaChi, string soDienThoai, DateTime ngaySinh, DateTime ngayVaoLam, string taiKhoan, string matKhau,string PathImg)
        {
            string query = @"UPDATE TaiKhoan
                        SET HoTen = @HoTen, ChucVu = @ChucVu, LoaiNhanVien = @LoaiNhanVien, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai,
                            NgaySinh = @NgaySinh, NgayVaoLam = @NgayVaoLam, TaiKhoan = @TaiKhoan, MatKhau = @MatKhau, PathImg = @PathImg
                        WHERE MaTaiKhoan = @MaTaiKhoan";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaTaiKhoan", maNhanVien),
            new SqlParameter("@HoTen", hoTen),
            new SqlParameter("@ChucVu", chucVu),
            new SqlParameter("@LoaiNhanVien", loaiNhanVien),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@SoDienThoai", soDienThoai),
            new SqlParameter("@NgaySinh", ngaySinh),
            new SqlParameter("@NgayVaoLam", ngayVaoLam),
            new SqlParameter("@TaiKhoan", taiKhoan),
            new SqlParameter("@MatKhau", matKhau),
            new SqlParameter("@pathIMG", PathImg)
            };
            MessageBoxHelper.ShowMessageBox($"Update người dùng {(databaseHelper.ExecuteNonQuery(query, parameters) > 0 ? "Thành Công" : "Thất bại")}");
            loadNhanVien();
        }

        // Xóa nhân viên
        public void DeleteNhanVien(int maNhanVien)
        {
            string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaNhanVien", maNhanVien)
            };
            MessageBoxHelper.ShowMessageBox($"Delete người dùng {(databaseHelper.ExecuteNonQuery(query, parameters) > 0 ? "Thành Công" : "Thất bại")}");
            loadNhanVien();
        }

        



        private void txbSearchNhanVienByName_OnValueChanged(object sender, EventArgs e)
        {
             loadNhanVien(txbSearchNhanVienByName.Text);
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show($"Bạn thực sự muốn Xóa tạo tài khoản {txbTaiKhoan.Text}?") == DialogResult.Yes)
            {
                DeleteNhanVien(Convert.ToInt32(txbMaNhanVien.Text));
                loadNhanVien();
            }
            
               
        }

        private void txbSodienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {  // Kiểm tra nếu ký tự vừa nhập không phải là số và không phải ký tự điều hướng (ví dụ: backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txbSodienthoai_OnValueChanged(object sender, EventArgs e)
        {
            if (Common.IsNumber(txbSodienthoai.Text) || txbSodienthoai.Text == "")
            {
                int counttxtNumberPhone = txbSodienthoai.Text.Length;

                if (counttxtNumberPhone > 10)
                {
                    MessageBoxHelper.ShowMessageBox("Không được nhập quá 10 số", 1);
                    txbSodienthoai.Text = txbSodienthoai.Text.Substring(0, 10); // Giới hạn số lượng số 10 so :D
                }
                else
                {
                    if (counttxtNumberPhone != 0)
                    {
                        lbGhiChuSDT.Visible = true;
                    }
                    lbGhiChuSDT.Text = $"{counttxtNumberPhone}/10";
                }
            }
            else
            {
                MessageBoxHelper.ShowMessageBox("Chỉ nhập số", 1);
                txbSodienthoai.Text = "";
            }
        }


        private void pictureBoxSelect_Click(object sender, EventArgs e)
        {
            pathImg = Common.SelectImage(); // Gọi hàm để chọn hình ảnh
            if (!string.IsNullOrEmpty(pathImg))
            {
                pictureBox.Image = Image.FromFile(pathImg);
                string NameFile = Common.Path_NameFile(pathImg);
                if (Common.CopyFile(pathImg, Common.PathExE() + $"\\img\\Account\\{NameFile}"))
                {
                    pathImg = $"\\img\\Account\\{NameFile}";
                }
            }
        }
        private void cbbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbbChucVu.SelectedValue.ToString(), out int amount))
            {   if (amount > 0) {
                    MaQuyen = int.Parse(cbbChucVu.SelectedValue.ToString());
                    //MessageBox.Show(MaQuyen.ToString());
                  
                }
               
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            btnAddNhanVienNew.Visible=true;
        }

        private void cbbLoaiNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
