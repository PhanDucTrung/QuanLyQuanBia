using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.formHelper.fkho
{
    public partial class fLichSuNhap : Form
    {
        DatabaseHelper db;
        string imagePath;
        public static bool isAddSuccess = false;
        public fLichSuNhap()
        {
            InitializeComponent();
            db = new DatabaseHelper(fLogin.connectionStringSQL);


        }

        public List<string> LayDanhSachtenSanPham()
        {
            string query = "SELECT TenSanPham FROM NhapHang LEFT JOIN dbo.SanPham ON SanPham.MaSanPham = NhapHang.MaSanPham";
            DataTable data = db.ExecuteQuery(query);

            List<string> danhSachTenSanPham = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                danhSachTenSanPham.Add(row["TenSanPham"].ToString());
            }

            return danhSachTenSanPham;
        }
        public void LichSuNhap()
        {
            DataTable dataTable = new DataTable();

          
                string query = "SELECT TenSanPham,SoLuongNhap,NhapHang.GiaNhap,NgayNhapHang,pathImg " +
                         "FROM dbo.NhapHang  " +
                         "LEFT JOIN dbo.SanPham ON SanPham.MaSanPham = NhapHang.MaSanPham";
                dataTable = db.ExecuteQuery(query);
          


            dataTable.Columns.Add("STT", typeof(string));
            dataTable.Columns.Add("PathImgg", typeof(Image));

            int Y = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Y++;
                dataTable.Rows[i]["STT"] = Y;
                DataRow row = dataTable.Rows[i];
                string pathIMG = row["pathImg"].ToString();
                dataTable.Rows[i]["PathImgg"] = Image.FromFile(Common.PathExE() + pathIMG);

            }


            dtgv.DataSource = dataTable;
        }

        private void fLichSuNhap_Load(object sender, EventArgs e)
        {
          
          
            LichSuNhap();
            dtgv.Columns["pathImg"].Visible = false;
           
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
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

            if (txbTenSP.Text.Trim() != "")
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
        public DataTable LaySanPham(string TenSanPham)
        {
            string query = "SELECT TenSanPham,SoLuongNhap,NhapHang.GiaNhap,NgayNhapHang,pathImg " +
                          "FROM dbo.NhapHang  " +
                          "LEFT JOIN dbo.SanPham ON SanPham.MaSanPham = NhapHang.MaSanPham"+
                           "  WHERE TenSanPham=N'" + TenSanPham + "'";
            DataTable data = db.ExecuteQuery(query);

            //List<string> SanPham = new List<string>();

            //foreach (DataColumn column in data.Columns)
            //{
            //    SanPham.Add(data.Rows[0][column].ToString());
            //}

            return data;
        }
        public DataTable LaySanPham2()
        {
            string query = "SELECT TenSanPham,SoLuongNhap,NhapHang.GiaNhap,NgayNhapHang,pathImg " +
                          "FROM dbo.NhapHang  " +
                          "LEFT JOIN dbo.SanPham ON SanPham.MaSanPham = NhapHang.MaSanPham" +
                           "  WHERE  NgayNhapHang BETWEEN '" + DateTimeNhap.Value + "' AND '" + metroDateTime1.Value + "'";
            DataTable data = db.ExecuteQuery(query);

            //List<string> SanPham = new List<string>();

            //foreach (DataColumn column in data.Columns)
            //{
            //    SanPham.Add(data.Rows[0][column].ToString());
            //}

            return data;
        }
        private void lsbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSanPham.SelectedIndex != -1)
            {
                // Hiển thị nội dung của mục được chọn lên TextBox
                txbTenSP.Text = lsbSanPham.SelectedItem.ToString();
                lsbSanPham.Visible = false;
                DataTable dataTable = LaySanPham(txbTenSP.Text);

                dataTable.Columns.Add("STT", typeof(string));
                dataTable.Columns.Add("PathImgg", typeof(Image));

                int Y = 0;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Y++;
                    dataTable.Rows[i]["STT"] = Y;
                    DataRow row = dataTable.Rows[i];
                    string pathIMG = row["pathImg"].ToString();
                    dataTable.Rows[i]["PathImgg"] = Image.FromFile(Common.PathExE() + pathIMG);

                }
                dtgv.DataSource = dataTable;


            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dataTable = LaySanPham2();

            dataTable.Columns.Add("STT", typeof(string));
            dataTable.Columns.Add("PathImgg", typeof(Image));

            int Y = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Y++;
                dataTable.Rows[i]["STT"] = Y;
                DataRow row = dataTable.Rows[i];
                string pathIMG = row["pathImg"].ToString();
                dataTable.Rows[i]["PathImgg"] = Image.FromFile(Common.PathExE() + pathIMG);

            }
            dtgv.DataSource = dataTable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
