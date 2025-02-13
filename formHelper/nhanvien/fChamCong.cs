using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.formHelper.nhanvien
{
    public partial class fChamCong : Form
    {
        DatabaseHelper dbHelper;
        public fChamCong()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dbHelper = new DatabaseHelper(fLogin.connectionStringSQL);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        public DataTable FilterAllCong()
        {  
           string    query = "SELECT HoTen,GioBatDau,GioKetThuc,SoTienBanDau,SoTienDuTinh,SoTienThucTe,ThoiGianLamViec,NgaySinh" +
                "  FROM dbo.ChamCong  " +
                " JOIN dbo.TaiKhoan ON   TaiKhoan.MaTaiKhoan = ChamCong.MaNhanVien ";
            DataTable dataTable = dbHelper.ExecuteQuery(query);
            return dataTable;

        }
        public DataTable FilterNhanvien()
        {
            string query = "SELECT DISTINCT MaNhanVien,HoTen" +
                " FROM dbo.ChamCong,dbo.TaiKhoan " +
                "WHERE MaNhanVien=MaTaiKhoan ";
            DataTable dataTable = dbHelper.ExecuteQuery(query);
            return dataTable;

        }

        public DataTable getCong(DateTime startTime, DateTime endTime, int employeeId)
        {
            string    query = "SELECT HoTen,GioBatDau,GioKetThuc,SoTienBanDau,SoTienDuTinh,SoTienThucTe,ThoiGianLamViec,NgaySinh " +
                "FROM dbo.ChamCong " +
                "JOIN dbo.TaiKhoan ON  TaiKhoan.MaTaiKhoan = ChamCong.MaNhanVien " +
                "WHERE GioBatDau between @StartTime AND  @EndTime AND MaNhanVien = @EmployeeId";
    
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@StartTime", startTime),
          new SqlParameter("@EndTime", endTime),
      new SqlParameter("@EmployeeId", employeeId)
            };
            return dbHelper.ExecuteQuery(query, parameters);

        }



        public DataTable filterCongByNhanVien(int MaNhanVien)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaNhanVien", MaNhanVien)
            };
            return dbHelper.ExecuteQuery("SELECT HoTen,GioBatDau,GioKetThuc,SoTienBanDau,SoTienDuTinh,SoTienThucTe,ThoiGianLamViec,NgaySinh  " +
                "FROM dbo.ChamCong  " +
                "JOIN dbo.TaiKhoan ON  TaiKhoan.MaTaiKhoan = ChamCong.MaNhanVien " +
                "WHERE MaNhanVien = @MaNhanVien", parameters);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
      public  int MaNhanVien=fLogin.MaNhanVien;
        private void fChamCong_Load(object sender, EventArgs e)
        {
            if (fLogin.PhanQuyen== "admin")
            {
                dtgv.DataSource = FilterAllCong();
                cbbTypeNhanVien.Enabled = true;
                cbbTypeNhanVien.DataSource = FilterNhanvien();
                cbbTypeNhanVien.DisplayMember = "HoTen";
                cbbTypeNhanVien.ValueMember = "MaNhanVien";
            }
            else
            {

                cbbTypeNhanVien.Items.Add(fLogin.HoTenNV) ;
                cbbTypeNhanVien.SelectedIndex = 0;
                cbbTypeNhanVien.ValueMember=MaNhanVien.ToString();
                MessageBox.Show(cbbTypeNhanVien.DisplayMember);
                dtgv.DataSource = filterCongByNhanVien(MaNhanVien);
             
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DataTable dt = FilterAllCong();
            dtgv.DataSource = dt;
           

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            dtgv.DataSource = getCong(DateTimeStart.Value,DateTimeStop.Value,int.Parse(cbbTypeNhanVien.SelectedValue.ToString()));
        }

        private void cbbTypeNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  dtgv.DataSource = filterCongByNhanVien(int.Parse(cbbTypeNhanVien.SelectedValue.ToString()));
        }
        public void ExportToExcel(DataGridView dataGridView, string title, string filePath)
        {
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Set the title
                worksheet.Cells["A1"].Value = title;
                worksheet.Cells["A1:H1"].Merge = true;
                worksheet.Cells["A1:H1"].Style.Font.Size = 16;
                worksheet.Cells["A1:H1"].Style.Font.Bold = true;
                worksheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Export DataGridView data to Excel
                int rowStart = 3;
                int colStart = 1;
                int rowEnd = rowStart + dataGridView.Rows.Count;
                int colEnd = colStart + dataGridView.Columns.Count - 1;

                // Header row
                for (int col = 0; col < dataGridView.Columns.Count; col++)
                {
                    if (dataGridView.Columns[col].HeaderText == "Chi Tiết")
                    {
                        continue;
                    }

                    worksheet.Cells[rowStart, colStart + col].Value = dataGridView.Columns[col].HeaderText;
                    worksheet.Cells[rowStart, colStart + col].Style.Font.Bold = true;
                    worksheet.Cells[rowStart, colStart + col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // Data rows
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        //if (dataGridView.Rows[row].Cells[col].Value.ToString() == "System.Drawing.Bitmap")
                        //{
                        //    continue;
                        //}



                        worksheet.Cells[rowStart + row + 1, colStart + col].Value = dataGridView.Rows[row].Cells[col].Value;
                        worksheet.Cells[rowStart + row + 1, colStart + col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                }

                // Save the file
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Thiết lập các thuộc tính của SaveFileDialog
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // Hiển thị hộp thoại SaveFileDialog và kiểm tra kết quả trả về
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Gọi phương thức xuất Excel với đường dẫn đã chọn
                ExportToExcel(dtgv, "Lịch Làm việc từ " + DateTimeStart + "đến"+DateTimeStop, saveFileDialog.FileName);

                // Hiển thị hộp thoại hỏi người dùng có muốn mở file vừa xuất ra không
                DialogResult result = MessageBox.Show("File đã được xuất. Bạn có muốn mở file không?", "Mở File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn "Có", mở file Excel
                if (result == DialogResult.Yes)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
    }
}
