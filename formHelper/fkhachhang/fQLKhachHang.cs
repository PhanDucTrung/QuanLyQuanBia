using BUS.ClassHelper;
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

namespace QuanLyQuanBia.formHelper
{
    public partial class fQLKhachHang : Form
    {
        DatabaseHelper db;
        public fQLKhachHang()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            db = new DatabaseHelper(fLogin.connectionStringSQL);
        }
        public fQLKhachHang(string daylaFormThanhToan)
        {
            InitializeComponent();
            this.BackColor = Color.DodgerBlue;
            this.Padding = new Padding(1, 1, 1, 1);
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            db = new DatabaseHelper(fLogin.connectionStringSQL);
            pnlClose.Visible = true;
        }

        public bool SuaKhachHang(int maKhachHang, string hoTen, string soDienThoai, string email, int soDiemTichLuy)
        {
            string query = "UPDATE KhachHang SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, Email = @Email, SoDiemTichLuy = @SoDiemTichLuy " +
                           "WHERE MaKhachHang = @MaKhachHang";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaKhachHang", maKhachHang),
        new SqlParameter("@HoTen", hoTen),
        new SqlParameter("@SoDienThoai", soDienThoai),
        new SqlParameter("@Email", email),
        new SqlParameter("@SoDiemTichLuy", soDiemTichLuy)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool XoaKhachHang(int maKhachHang)
        {
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            SqlParameter[] parameters = new SqlParameter[]
           {
             new SqlParameter("@MaKhachHang", maKhachHang)
           };
            return db.ExecuteNonQuery(query, parameters) > 0;
        }








        private void fKhachHang_Load(object sender, EventArgs e)
        {
          DataTable data =   db.ExecuteQuery("Select * from KhachHang");

            LoadFmain(data);




        }

        void LoadFmain(DataTable data)
        {
            int Stt = 0;
            data.Columns.Add("STT", typeof(string));
            data.Columns.Add("ImgEdit", typeof(Image));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Stt++;
                data.Rows[i]["STT"] = Stt;
                data.Rows[i]["ImgEdit"] = Image.FromFile(@"img\edit_file_25px.png");
            }

            dtgv.DataSource = data;

        }





        private void btnAddKhachHang_Click_1(object sender, EventArgs e)
        {
            Common.ShowForm(new faddKhachHangNew());

            if (faddKhachHangNew.isKhachHang)
            {
                faddKhachHangNew.isKhachHang = false;
                fKhachHang_Load(null,null);
            }
        }

        private void btnDeleteKhachHang_Click(object sender, EventArgs e)
        {
            int countSelect = dtgv.SelectedRows.Count ,countDeleteSuccess = 0;
            if (MessageBoxHelper.Show($"Bạn có thực sự muốn xóa {countSelect} khách hàng ?") == DialogResult.No)
                return;

            foreach (DataGridViewRow row in dtgv.SelectedRows)
            {
                int col1Value = (int)row.Cells["cMaKhachHang"].Value;
                if (XoaKhachHang(col1Value))
                {
                    countDeleteSuccess++;
                } 
            }

            MessageBoxHelper.ShowMessageBox($"Xóa Thành Công {countDeleteSuccess}/{countSelect} khách hàng");
            fKhachHang_Load(null, null);
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == dtgv.Columns["cEdit"].Index)
            {
                string hoten = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cHoTen");

                if (MessageBoxHelper.Show($"Bạn có thực sự muốn sửa Khách hàng : {hoten} không?") == DialogResult.No)
                    return;


                int makh = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaKhachHang"));
             
             string sodienthoai =   DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cSoDienThoai");
               string email =  DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cEmail");
              int diemtichluy = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cSoDiemTichLuy"));

                if (SuaKhachHang(makh, hoten,sodienthoai,email,diemtichluy))
                {
                    MessageBoxHelper.ShowMessageBox($"Sửa Thành Công");
                    fKhachHang_Load(null, null);
                }



            }
        }

       
        public DataTable TimKiemKhachHang(string keyword)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
             new SqlParameter("@Keyword", keyword)
           };
            string query = "SELECT * FROM KhachHang WHERE HoTen LIKE '%' + @Keyword + '%' OR Email LIKE '%' + @Keyword + '%'";
            return db.ExecuteQuery(query, parameters);
        }

        private void txbTimKiemTheoTuKhoakH_OnValueChanged(object sender, EventArgs e)
        {
            LoadFmain(TimKiemKhachHang(txbTimKiemTheoTuKhoakH.Text));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
