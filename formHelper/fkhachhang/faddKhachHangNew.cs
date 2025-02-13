using BUS.ClassHelper;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyQuanBia.formHelper
{
    public partial class faddKhachHangNew : Form
    {
        public faddKhachHangNew()
        {
            InitializeComponent();
            db = new DatabaseHelper(fLogin.connectionStringSQL);
        }
        DatabaseHelper db;
        public static bool isKhachHang = false;
        private void faddKhachHangNew_Load(object sender, EventArgs e)
        {

        }

        private void btnAddKhachHang_Click(object sender, EventArgs e)
        {
            if (txbNameKhachHang.Text == "" || txbSdt.Text == "" || txbEmail.Text == "")
            {
                MessageBoxHelper.ShowMessageBox("vui lòng điền đẩy đủ thông tin!"); return;
            }
            string kq = "Thất bại";
            if (ThemKhachHang(txbNameKhachHang.Text.Trim(), txbSdt.Text.Trim(), txbEmail.Text.Trim(), 0) > 0)
            {
                isKhachHang = true;
                kq = "Thành công";
            }
            MessageBoxHelper.ShowMessageBox($"Thêm khác hàng : {kq}");
        }

        public int ThemKhachHang(string hoTen, string soDienThoai, string email, int soDiemTichLuy)
        {
            
                string query = "INSERT INTO KhachHang (HoTen, SoDienThoai, Email, SoDiemTichLuy) " +
                               "VALUES (@HoTen, @SoDienThoai, @Email, @SoDiemTichLuy)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@SoDienThoai", soDienThoai),
                new SqlParameter("@Email", email),
                new SqlParameter("@SoDiemTichLuy", soDiemTichLuy)
                };

           return db.ExecuteNonQuery(query, parameters);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
