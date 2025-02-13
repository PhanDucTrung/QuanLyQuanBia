using BUS.ClassHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.ClassHelper.fLogin
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        DatabaseHelper databaseHelper;
        public static string PhanQuyen = "";
        public static int MaNhanVien = -1;
        public static string HoTenNV = "";

        public static string connectionStringSQL = "Data Source=TRUNG;Initial Catalog=quanly_quan_bi_a1;Integrated Security=True";
        private void fLogin_Load(object sender, EventArgs e)
        {
            databaseHelper = new DatabaseHelper(connectionStringSQL);
        }

        private void txbUser_OnValueChanged(object sender, EventArgs e)
        {
            // Làm sạch chuỗi: xóa dấu và khoảng trắng
            txbUser.Text = txbUser.Text.Replace(" ","");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);
                Application.Exit();
            }
            catch
            {
                Close();
            }
        }

        private void txbPassword_OnValueChanged(object sender, EventArgs e)
        {
            // Làm sạch chuỗi: xóa dấu và khoảng trắng
            txbPassword.Text = txbPassword.Text.Replace(" ", "");
        }



        ////Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text;
            string password = txbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBoxHelper.ShowMessageBox("Vui lòng nhập đủ dữ liệu !");
                return;
            }


            //Chọn ra mã số nhân viên, tên và quyền của nhân viên dựa trên tên tài khoản và mật khẩu đăng nhập
            //-- Bảng NhanVien được đặt tên tạm thời là NV
            //--đặt tên tạm thời là NQ , điều kiện MaNhanVien = MaNhanVien
            //--đặt tên tạm thời là Q , điều kiện MaQuyen = MaQuyen
            //-- Điều kiện đăng nhập
            string query = @"SELECT NV.MaTaiKhoan, NV.HoTen, Q.TenQuyen
                     FROM TaiKhoan AS NV
                     JOIN TaiKhoanQuyen AS NQ ON NV.MaTaiKhoan = NQ.MaTaiKhoan
                       JOIN Quyen AS Q ON NQ.MaQuyen = Q.MaQuyen
                       WHERE NV.TaiKhoan = @TaiKhoan AND NV.MatKhau = @MatKhau";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TaiKhoan", username),
        new SqlParameter("@MatKhau", password)
            };



            DataTable result = databaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                PhanQuyen = result.Rows[0]["TenQuyen"].ToString();
                MaNhanVien =(int)result.Rows[0]["MaTaiKhoan"];
                HoTenNV = result.Rows[0]["HoTen"].ToString();
                // Đăng nhập thành công
                MessageBoxHelper.ShowMessageBox($"Đăng nhập thành công! \nXin chào {PhanQuyen} : {HoTenNV}");

                this.Hide();
               
                fMain f = new fMain();
                f.ShowInTaskbar = true;
                f.ShowDialog();
            }
            else
                MessageBoxHelper.ShowMessageBox("Tài khoản hoặc mật khẩu không đúng!"); // Đăng nhập thất bại


        }

    
        private void txbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null,null);
        }
    }
}
