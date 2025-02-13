using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using QuanLyQuanBia.formHelper.ItemSP;
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



namespace QuanLyQuanBia.formHelper.fLichSu
{
    public partial class fHistoryDesk : Form
    {

        DatabaseHelper dbHelper;
        public fHistoryDesk()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dbHelper = new DatabaseHelper(fLogin.connectionStringSQL);


            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Đặt LicenseContext thành NonCommercial


        }




       
        public DataTable FilterHoaDonByDate(DateTime startTime, DateTime endTime, int employeeId)
        {

            DateTime StartTime = startTime.Date; // Đặt giờ và phút về 00:00:00s
            DateTime EndTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59);// Đặt giờ và phút và giây về 23:59:59s
            string query = "";
            SqlParameter[] parameters = null;
            if (fLogin.PhanQuyen == "admin")
            {
                // tìm kiếm trong khoảng nhưng đoạn này nó sẽ bỏ đi mất ngày đầu của mình , nên sẽ k dùng BETWEEN được|BỎ ĐOẠN CODE NÀY ĐI
                //query = "SELECT * FROM HoaDon WHERE NgayLap BETWEEN @NgayBatDau AND @NgayKetThuc";
                query = "SELECT * FROM HoaDon WHERE NgayLap >= @StartTime AND NgayLap <= @EndTime";
                parameters = new SqlParameter[] { new SqlParameter("@StartTime", startTime), new SqlParameter("@EndTime", endTime) };
            }
            else
            {
                // tìm kiếm trong khoảng nhưng đoạn này nó sẽ bỏ đi mất ngày đầu của mình , nên sẽ k dùng BETWEEN được|BỎ ĐOẠN CODE NÀY ĐI
                // query = "SELECT * FROM HoaDon WHERE NgayLap BETWEEN @StartTime AND @EndTime AND TaiKhoanThanhToan = @EmployeeId";
                query = "SELECT * FROM HoaDon WHERE NgayLap >= @StartTime AND NgayLap <= @EndTime AND TaiKhoanThanhToan = @EmployeeId";
                parameters = new SqlParameter[]{new SqlParameter("@StartTime", StartTime),new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@EmployeeId", employeeId)};
            }
            DataTable dataTable = dbHelper.ExecuteQuery(query, parameters);
            return dataTable;

        }

        public DataTable GetAccountByID(int mataikhoan)
        {
            string query = "select * from TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaTaiKhoan", mataikhoan)
            };
            return dbHelper.ExecuteQuery(query, parameters);

        }

      

        public DataTable GetBillByIdAccount_ThanhToan(int idUserThanhToan)
        {
           
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TaiKhoanThanhToan", idUserThanhToan)
            };
            return dbHelper.ExecuteQuery("select * from HoaDon WHERE TaiKhoanThanhToan = @TaiKhoanThanhToan", parameters);
        }

        public DataTable GetInvoicesWithCashPayment(string HinhThucThanhToan ,int employeeId)
        {
            string query = "SELECT * FROM HoaDon WHERE HinhThucThanhToan = @HinhThucThanhToan";
            SqlParameter[] parameters = null;
            if (fLogin.PhanQuyen == "admin")
            {
                parameters = new SqlParameter[] {new SqlParameter("@HinhThucThanhToan", HinhThucThanhToan)};
            }
            else
            {
                query = "SELECT * FROM HoaDon WHERE HinhThucThanhToan = @HinhThucThanhToan " + "AND TaiKhoanThanhToan = @EmployeeId";
                parameters = new SqlParameter[] { new SqlParameter("@HinhThucThanhToan", HinhThucThanhToan), new SqlParameter("@EmployeeId", employeeId) };

            }

            return dbHelper.ExecuteQuery(query, parameters);
        }




        public void cbbTypeTaiKhoanByHoaDon()
        {
            // TRUY VẤN NÀY CHỈ SELECT TỚI NHỮNG TaiKhoanThanhToan ĐÃ THANH TOÁN TRÊN BILL
            string query = "SELECT DISTINCT HoaDon.TaiKhoanThanhToan, TaiKhoan.HoTen " +
                "FROM HoaDon " +
                "INNER JOIN TaiKhoan ON HoaDon.TaiKhoanThanhToan = TaiKhoan.MaTaiKhoan;";

            // TRUY VẤN NÀY SELECT ALL TÀI KHOẢN ĐANG HOẠT ĐỘNG TRONG HỆ THỐNG
            query = "select TaiKhoan.MaTaiKhoan , TaiKhoan.HoTen FROM TaiKhoan";

            DataTable dataTable = dbHelper.ExecuteQuery(query);
            DataRow newRow = dataTable.NewRow();
            newRow["HoTen"] = "All";
            newRow["MaTaiKhoan"] = 0;
            dataTable.Rows.InsertAt(newRow, 0);

            cbbTypeNhanVien.DisplayMember = "HoTen"; 
            cbbTypeNhanVien.ValueMember = "MaTaiKhoan";
            cbbTypeNhanVien.DataSource = dataTable;
        }

        public void cbbTypeHinhThucThanhToan()
        {
            DataTable paymentMethodsTable = dbHelper.ExecuteQuery("SELECT DISTINCT HinhThucThanhToan FROM HoaDon");
            DataRow newRow = paymentMethodsTable.NewRow();
            newRow["HinhThucThanhToan"] = "All";
            paymentMethodsTable.Rows.InsertAt(newRow, 0);

            List<string> danhSach = new List<string>();
            foreach (DataRow row in paymentMethodsTable.Rows)
            {
                danhSach.Add(row["HinhThucThanhToan"].ToString());
            }
            cbbHinhThucThanhToan.DataSource = danhSach;
        }



       



        void dataView(int idUserThanhToan = 0,bool filterHoaDonByDate = false,string hinhthucthanhtoan = "")
        {
            DataTable DATA = new DataTable();
           
            if (filterHoaDonByDate)
            {

                DATA =  FilterHoaDonByDate(DateTimeStart.Value, DateTimeStop.Value,fLogin.MaNhanVien);

            }
            else if (idUserThanhToan > 0)
            {
               DATA = GetBillByIdAccount_ThanhToan(idUserThanhToan);
            }
            else if (hinhthucthanhtoan != "")
            {
                
                DATA = GetInvoicesWithCashPayment(hinhthucthanhtoan,fLogin.MaNhanVien);
                
            }
            else
            {
               
               DATA = dbHelper.ExecuteQuery("select * from HoaDon");
               
            }


            DATA.Columns.Add("STT", typeof(string));
            DATA.Columns.Add("UserThanhToan", typeof(string));
            DATA.Columns.Add("IMG", typeof(Image));
            int Y = 0;
            for (int i = 0; i < DATA.Rows.Count; i++)
            {
                DataRow row = DATA.Rows[i];
                Y++;
                DATA.Rows[i]["STT"] = Y;
                int tkThanhToan = Common.ConverINT(row["TaiKhoanThanhToan"]);
                DATA.Rows[i]["IMG"] = Image.FromFile(@"img\info_25px.png");
                if (tkThanhToan > 0 )
                {
                    DataTable dataTable = GetAccountByID(tkThanhToan);
                    DATA.Rows[i]["UserThanhToan"] = dataTable.Rows[0]["HoTen"];
                }
            }
            dtgv.DataSource = DATA;
           
        }


      









        private void fHistoryDesk_Load(object sender, EventArgs e)
        {
            cbbTypeHinhThucThanhToan();
            cbbTypeTaiKhoanByHoaDon();
            dataView();

            
            cbbTypeNhanVien.SelectedValue = fLogin.PhanQuyen == "admin" ? 0 : fLogin.MaNhanVien;
            cbbTypeNhanVien.Enabled = fLogin.PhanQuyen == "admin";

        }

        private void cbbTypeNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataView(idUserThanhToan:(int)cbbTypeNhanVien.SelectedValue);
        }

        private void DateTimeStop_ValueChanged(object sender, EventArgs e)
        {
            dataView(filterHoaDonByDate: true);
        }

        private void DateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            dataView(filterHoaDonByDate: true);
        }

        private void cbbHinhThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {

            /// trường hợp này khá hy hữu , không phải quyền admin mà lại là all thì cho Load Lại All danh sách
            if (fLogin.PhanQuyen != "admin" && cbbHinhThucThanhToan.SelectedItem.ToString() == "All")
            {

                dataView(idUserThanhToan: fLogin.MaNhanVien);
            }
            else
            {
                // còn trường hợp này chắc chắn là admin thì nên chỉ cần để cho select vào bảng HoaDon mà k cần quan tâm nó là quyền gì , Vì admin là quyền to nhất rồi :D
                dataView(hinhthucthanhtoan: cbbHinhThucThanhToan.SelectedItem.ToString() == "All" ? "" : cbbHinhThucThanhToan.SelectedItem.ToString().Trim());
            }
            
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgv.Columns["cIMG"].Index)
            {
                string index = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cMaHoaDon");
              int cmahoadon = Convert.ToInt32(index);
                string gia = DatagridviewHelper.GetStatusDataGridView(dtgv, e.RowIndex, "cThanhTien");
                Common.ShowForm(new fChiTietHoaDon(cmahoadon, gia));

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
                ExportToExcel(dtgv, "Lịch Sử bán hàng "+ DateTime.Now, saveFileDialog.FileName);

                // Hiển thị hộp thoại hỏi người dùng có muốn mở file vừa xuất ra không
                DialogResult result = MessageBox.Show("File đã được xuất. Bạn có muốn mở file không?", "Mở File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn "Có", mở file Excel
                if (result == DialogResult.Yes)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }

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
                        if (dataGridView.Rows[row].Cells[col].Value.ToString() == "System.Drawing.Bitmap")
                        {
                            continue;
                        }



                        worksheet.Cells[rowStart + row + 1, colStart + col].Value = dataGridView.Rows[row].Cells[col].Value;
                        worksheet.Cells[rowStart + row + 1, colStart + col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                }

                // Save the file
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
