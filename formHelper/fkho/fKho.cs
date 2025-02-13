using BUS.ClassHelper;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using QuanLyQuanBia.formHelper.fkho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace QuanLyQuanBia.formHelper
{
    public partial class fKho : Form
    {
        DatabaseHelper db;
        public fKho()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            db = new DatabaseHelper(fLogin.connectionStringSQL);
        }

        private void fKho_Load(object sender, EventArgs e)
        {
            LoadConfigDtgv();
            LoadConfig();
           
            List<string> danhSachLoaiSanPham = LayDanhSachLoaiSanPham();
            cbbTypeSP.DataSource = danhSachLoaiSanPham;

            LayDanhSachSanPhamVaChiTiet();
            switch (fLogin.PhanQuyen)
            {

                case "admin":
                    btnLinhSuNhap.Visible = true;
                    dtgv.Enabled = true;

                    break;
                case "quản lý":


                    break;
                case "nhân viên":
                    btnLinhSuNhap.Visible = false;
                    dtgv.Enabled = false;

                    break;
                default:
                    MessageBoxHelper.ShowMessageBox("Vui lòng báo Admin cung cấp quyền hạn sự dụng phần mềm!"); this.Close();
                    break;
            }
        }

        private void btnPhieuNhapMoi_Click(object sender, EventArgs e)
        {
            // Open forme phieu nhạp mới 
            Common.ShowForm(new fPhieuNhapMoi());
            if (fPhieuNhapMoi.isAddSuccess)
            {
                fPhieuNhapMoi.isAddSuccess = false;
                LayDanhSachSanPhamVaChiTiet();
            }
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

       
        public void LayDanhSachSanPhamVaChiTiet(string categoryName = "",string keyword = "")
        {
            DataTable dataTable = new DataTable();


            if (categoryName != "")
            {
                dataTable = GetProductsByCategory(categoryName);
              
            }
            else if (keyword != "")
            {
                dataTable = SearchProductsByKeyWord(keyword);
            }
            else
            {
                string query = "SELECT SanPham.*, ChiTietSanPham.* " +
                         "FROM SanPham " +
                         "LEFT JOIN ChiTietSanPham ON SanPham.MaSanPham = ChiTietSanPham.MaSanPham";
                dataTable = db.ExecuteQuery(query);
            }
  
            dataTable.Columns.Add("STT", typeof(string));
            dataTable.Columns.Add("ImgAdd", typeof(Image));
            dataTable.Columns.Add("ImgDelete", typeof(Image));
            dataTable.Columns.Add("PathImgg", typeof(Image));
         
            int Y = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Y++;
                dataTable.Rows[i]["STT"] = Y;
                DataRow row = dataTable.Rows[i];
                string pathIMG = row["pathImg"].ToString();
                dataTable.Rows[i]["ImgAdd"] = Image.FromFile(@"img\plus_25px.png");
                dataTable.Rows[i]["ImgDelete"] = Image.FromFile(@"img\cancel_25px.png");
                dataTable.Rows[i]["PathImgg"] = Image.FromFile(Common.PathExE()+pathIMG);

            }


            dtgv.DataSource = dataTable;
        }


        bool openpnView = true;
        private void btnOpenpnlView_Click(object sender, EventArgs e)
        {
            if (openpnView)
            {
                btnOpenpnlView.BackgroundImage = Image.FromFile(@"img\chevron_left_25px.png");
                openpnView = false;
                pnlView.Width = 1053;
            }
            else
            {
                btnOpenpnlView.BackgroundImage = Image.FromFile(@"img\chevron_right_25px.png");
                openpnView = true;
                pnlView.Width = 1;


            }
        }




        #region setting
        void LoadConfig()
        {
            ckbMaSanPham_CheckedChanged(null,null);
            ckbGia_CheckedChanged(null, null);
       
            ckbGhiChuSanPham_CheckedChanged(null, null);
            ckbMaChiTietSanPham_CheckedChanged(null, null);
            ckbDonViTinh_CheckedChanged(null, null);
            ckbGhiChuChiTietSP_CheckedChanged(null, null);
            ckbHanSuDung_CheckedChanged(null, null);
            ckbGiaNhap_CheckedChanged(null, null);
            ckbSoLuongTon_CheckedChanged(null, null);
            ckbNguonNhap_CheckedChanged(null, null);
            ckbLienHe_CheckedChanged(null, null);
            ckbNgayNhap_CheckedChanged(null, null);
        }
        void LoadConfigDtgv()
        {
            ckbMaSanPham.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbMaSanPham");
            ckbGia.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbGia");
            ckbGhiChuSanPham.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbGhiChuSanPham");
            ckbMaChiTietSanPham.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbMaChiTietSanPham");

            ckbDonViTinh.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbDonViTinh");
            ckbGhiChuChiTietSP.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbGhiChuChiTietSP");
            ckbHanSuDung.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbHanSuDung");
            ckbGiaNhap.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbGiaNhap");
            ckbSoLuongTon.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbSoLuongTon");
            ckbNguonNhap.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbNguonNhap");
            ckbLienHe.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbLienHe");
            ckbNgayNhap.Checked = SettingsTool.GetSettings("configDatagridviewKho").GetValueBool("ckbNgayNhap");
        }
        #endregion



        #region khong lien quan :)
        private void ckbMaSanPham_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cMaSanPham"].Visible = ckbMaSanPham.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbMaSanPham", ckbMaSanPham.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbGia_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cGia"].Visible = ckbGia.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbGia", ckbGia.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbGhiChuSanPham_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cGhiChu"].Visible = ckbGhiChuSanPham.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbGhiChuSanPham", ckbGhiChuSanPham.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbMaChiTietSanPham_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cMaChiTietSanPham"].Visible = ckbMaChiTietSanPham.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("cMaChiTietSanPham", ckbMaChiTietSanPham.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbDonViTinh_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cDonViTinh"].Visible = ckbDonViTinh.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbDonViTinh", ckbDonViTinh.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbGhiChuChiTietSP_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cGhiChuChiTietSP"].Visible = ckbGhiChuChiTietSP.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbGhiChuChiTietSP", ckbGhiChuChiTietSP.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbHanSuDung_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cHanSuDung"].Visible = ckbHanSuDung.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbHanSuDung", ckbHanSuDung.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbGiaNhap_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cGiaNhap"].Visible = ckbGiaNhap.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("cGiaNhap", ckbGiaNhap.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbSoLuongTon_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cSoLuongTon"].Visible = ckbSoLuongTon.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbSoLuongTon", ckbSoLuongTon.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbNguonNhap_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cNguonNhap"].Visible = ckbNguonNhap.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbNguonNhap", ckbNguonNhap.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbLienHe_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cChiTietLienLac"].Visible = ckbLienHe.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbLienHe", ckbLienHe.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }

        private void ckbNgayNhap_CheckedChanged(object sender, EventArgs e)
        {
            dtgv.Columns["cNgayNhap"].Visible = ckbNgayNhap.Checked;
            SettingsTool.GetSettings("configDatagridviewKho").Update("ckbNgayNhap", ckbNgayNhap.Checked);
            SettingsTool.SaveAndRefreshSettings("configDatagridviewKho");
        }
        #endregion

        public bool DeleteChiTietSanPham(int maChiTietSanPham)
        {
            string query = "DELETE FROM ChiTietSanPham WHERE MaChiTietSanPham = @MaChiTietSanPham";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaChiTietSanPham", maChiTietSanPham)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteSanPham(int maSanPham)
        {
            string query = "DELETE FROM SanPham WHERE MaSanPham = @MaSanPham";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaSanPham", maSanPham)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }


        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgv.Columns["cImgAdd"].Index)
            {

                string tenSP = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cTenSanPham");
                if (MessageBoxHelper.Show($"Bạn có thực sự muốn Update Sản Phẩm: {tenSP}?") == DialogResult.No)
                    return;

                string MachiTietSP = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaChiTietSanPham");
                string MaSP = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaSanPham");

                DateTime dateNhap = Convert.ToDateTime(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cNgayNhap"));
                string donvi = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cDonViTinh");
                string Loai = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cLoaiSanPham");
                DateTime DtTimeHSD = Convert.ToDateTime(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cHanSuDung"));
                decimal gianhap = Convert.ToDecimal(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cGiaNhap"));
                decimal giabanle = Convert.ToDecimal(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cGia"));
                string soluongCu = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cSoLuongTon");
                //  string soluongMoi = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cGia");
                string nguonNhap = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cNguonNhap");
                string lienlac = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cChiTietLienLac");
                string pathIMG = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cpathImg");

                Common.ShowForm(new fPhieuNhapMoi($"Update Sản Phẩm: {tenSP}", MachiTietSP, MaSP, tenSP, dateNhap, donvi, Loai, DtTimeHSD, gianhap, giabanle, soluongCu, nguonNhap, lienlac, pathIMG));



            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dtgv.Columns["cImgDelete"].Index)
            {
                string name = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cTenSanPham");
                if (MessageBoxHelper.Show($"Bạn có thực sự muốn Xóa Sản Phẩm: {name} ra khỏi hệ thống ?") == DialogResult.No)
                    return;

                int cMaSanPham = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaSanPham"));
                int cMaChiTietSanPham = Convert.ToInt32(DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaChiTietSanPham"));

                if (DeleteChiTietSanPham(cMaChiTietSanPham))
                {
                    if (DeleteSanPham(cMaSanPham))
                    {
                        LayDanhSachSanPhamVaChiTiet();
                    }
                    else
                    {
                        MessageBoxHelper.ShowMessageBox("Xóa  Sản Phẩm thất bại"); return;
                    }
                }
                else
                {
                    MessageBoxHelper.ShowMessageBox("Xóa chi tiết Sản Phẩm thất bại");return;
                }


            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dtgv.Columns["cpathImgg"].Index)
            {
                

            }

            if (fPhieuNhapMoi.isAddSuccess)
            {
                fPhieuNhapMoi.isAddSuccess = false;
                LayDanhSachSanPhamVaChiTiet();
            }



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
            return  db.ExecuteQuery(query, parameters);
        }

        public DataTable SearchProductsByKeyWord(string KeyWord)
        {
            string query = "SELECT SanPham.*, ChiTietSanPham.* " +
                           "FROM SanPham " +
                           "INNER JOIN ChiTietSanPham ON SanPham.MaSanPham = ChiTietSanPham.MaSanPham " +
                           "WHERE TenSanPham LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("KeyWord","%"+ KeyWord + "%")
            };

            return db.ExecuteQuery(query, parameters);
        }

        private void txbSearchkeywordSP_OnValueChanged(object sender, EventArgs e)
        {
            LayDanhSachSanPhamVaChiTiet(keyword: txbSearchkeywordSP.Text.Trim());
        }

        private void cbbTypeSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDanhSachSanPhamVaChiTiet(categoryName: cbbTypeSP.Text.Trim() == "All" ? "" : cbbTypeSP.Text.Trim());
        }

        private void btnLinhSuNhap_Click(object sender, EventArgs e)
        {
            // Open forme phieu nhạp mới 
            Common.ShowForm(new fLichSuNhap());
            if (fLichSuNhap.isAddSuccess)
            {
                fLichSuNhap.isAddSuccess = false;
                LayDanhSachSanPhamVaChiTiet();
            }
        }
    }
}
