using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
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

namespace QuanLyQuanBia.formHelper.fLichSu
{
    public partial class fChiTietHoaDon : Form
    {
        DatabaseHelper db;
        private int ID;
        public fChiTietHoaDon(int idBill, string gia)
        {
            InitializeComponent();
            lbTileName.Text = $"Chi Tiết Hóa Đơn : {idBill}";
            lblGia.Text = $"Tổng cộng: {gia} vnđ";
            ID = idBill;
            this.BackColor = Color.DodgerBlue;
            this.Padding = new Padding(1, 1, 1, 1);
        }
        public DataTable GetInvoiceDetailByMaHoaDon(int maHoaDon)
        {
         
                string query = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaHoaDon", maHoaDon) };
            DataTable invoiceDetailTable = db.ExecuteQuery(query, parameters);


            invoiceDetailTable.Columns.Add("STT", typeof(string));
            invoiceDetailTable.Columns.Add("TenSanPham", typeof(string));
            invoiceDetailTable.Columns.Add("Gia", typeof(string)); // đơn giá
            int Y = 0;
            for (int i = 0; i < invoiceDetailTable.Rows.Count; i++)
            {
                DataRow row = invoiceDetailTable.Rows[i];
                DataTable dataTable = GetProductsByMaSanPham((int)row["MaSanPham"]);
                invoiceDetailTable.Rows[i]["TenSanPham"] = dataTable.Rows[0]["TenSanPham"];
                invoiceDetailTable.Rows[i]["Gia"] = dataTable.Rows[0]["Gia"]; // đơn giá
                Y++;
                invoiceDetailTable.Rows[i]["STT"] = Y;
            }

            return invoiceDetailTable;
        }

        public DataTable GetProductsByMaSanPham(int MaSanPham)
        {
             string query = "SELECT * FROM SanPham WHERE MaSanPham = @MaSanPham";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaSanPham", MaSanPham) };
            return db.ExecuteQuery(query, parameters);

        }

        private void fChiTietHoaDon_Load(object sender, EventArgs e)
        {
            db = new DatabaseHelper(fLogin.connectionStringSQL);

            dtgv.DataSource =  GetInvoiceDetailByMaHoaDon(ID);



            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
