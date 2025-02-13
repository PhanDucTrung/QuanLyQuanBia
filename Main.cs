using BUS.ClassHelper;
using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using QuanLyQuanBia.formHelper;
using QuanLyQuanBia.formHelper.fBieuDo;
using QuanLyQuanBia.formHelper.fLichSu;
using QuanLyQuanBia.formHelper.ItemSP;
using QuanLyQuanBia.formHelper.nhanvien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyQuanBia
{
    public partial class fMain : Form
    {   DatabaseHelper db;
        int manhanvien;
        DateTime time;
        public fMain()
        {
            InitializeComponent();


            string pathImg = pathImgAvatarSQL();
            if (Common.FileTonTai(Common.PathExE() + pathImg))
                pictureBoxAvatar.Image = Image.FromFile(Common.PathExE() + pathImg);
            db = new DatabaseHelper(fLogin.connectionStringSQL);
            manhanvien = fLogin.MaNhanVien;
        }
        public static int MaChamCong=0;
        private string pathImgAvatarSQL()
        {
            DatabaseHelper db = new DatabaseHelper(fLogin.connectionStringSQL);
            DataTable Img = db.ExecuteQuery($"select TaiKhoan.PathImg from TaiKhoan where MaTaiKhoan ={fLogin.MaNhanVien}");
           return Img.Rows[0]["PathImg"].ToString();
        }
   

        private void fMain_Load(object sender, EventArgs e)
        {
            lblNameNV.Text = fLogin.HoTenNV;
            var imgPath = pathImgAvatarSQL();
            if (File.Exists(imgPath))
            {
            pictureBoxAvatar.Image = Image.FromFile(imgPath);

            }
            switch (fLogin.PhanQuyen)
            {

                case "admin":
                    //bntNhanVien.Visible = true;
                    //btnQlThongKe.Visible = true;
                    //btnKho.Visible = true;
                    //btnMenuDV.Enabled = false;
                    //btnTinhTrangBan.Enabled = false;

                    break;
                case "quản lý":
                    bntNhanVien.Visible = true;
                    btnQlThongKe.Visible = true;
                    btnKho.Visible = true;
                    btnMenuDV.Enabled = false;
                    btnTinhTrangBan.Enabled = false;

                    break;
                case "nhân viên":
                    bntNhanVien.Enabled = false;
                    btnQlThongKe.Enabled = false;


                    btnLichSu.Enabled = false;
                    btnKhachHang.Enabled = false;
                    btnKho.Enabled = false;
                    btnMenuDV.Enabled = false;
                    btnTinhTrangBan.Enabled = false;


                    break;
                default:
                    MessageBoxHelper.ShowMessageBox("Vui lòng báo Admin cung cấp quyền hạn sự dụng phần mềm!"); this.Close();
                    break;
            }




        }
        private Form activeFrom = null;

        private void openChildForm(Form childForm, Panel pnl)
        {
            // Đảm bảo đóng Form hiện tại nếu có
            if (activeFrom != null && !activeFrom.IsDisposed)
            {
                activeFrom.Close();
            }
            activeFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnl.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        #region top_Main
        private void pnlTileTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnChot.Visible==false)
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
            else
            {
                MessageBox.Show("Đã Chốt Ca Chưa Mà Thoát Có Muốn Bị Trường Lư Không");
            }
          
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
            Rectangle workingArea = Screen.FromHandle(this.Handle).WorkingArea;
            workingArea.Location = new Point(0, 0);
            this.MaximumSize = workingArea.Size;
            this.WindowState = FormWindowState.Maximized;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }
        #endregion


        private void btnMenuDV_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Menu Dịch Vụ";
            openChildForm(new fTableStatus(), pnMain);
        }

        private void btnTinhTrangBan_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Tình Trạng Bàn";
            openChildForm(new fbookMenuBookTable(), pnMain);
        }

        // đăng xuất :D
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Hide();
            fLogin fActive2 = new fLogin();
            fActive2.ShowInTaskbar = true;
            fActive2.ShowDialog();
        }

        private void bntNhanVien_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Nhân Viên";
            openChildForm(new fNhanVien(), pnMain);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Lịch Sử Bàn";
            openChildForm(new fHistoryDesk(), pnMain);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new fQLKhachHang(), pnMain);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Kho";
            openChildForm(new fKho(), pnMain);
        }

        private void btnQlThongKe_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Thống Kê";
            openChildForm(new fBieuDoNgoai(), pnMain);
        }

        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (activeFrom != null && !activeFrom.IsDisposed)
            {
                activeFrom.Close();
               
            }
            lblNameForm.Text = "Home";

            if (MaChamCong != 0)
            {
                List<string> chamcong = thongtin(MaChamCong);
                txtBandau.Text = chamcong[0];
                txtDuTinh.Text = chamcong[1];
            }

        }

        public int ChamCong( int MaNhanVien,DateTime GioBatDau, decimal SoTien,decimal tien)
        {
            try
            {
                // Query để chèn dữ liệu mới vào bảng SanPham
                string query = "INSERT INTO ChamCong (MaNhanVien,GioBatDau,SoTienBanDau,SoTienDuTinh) " +
                               "VALUES(@MaNhanVien,@GioBatDau,@SoTien,@tien); SELECT SCOPE_IDENTITY();";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
           new SqlParameter("@MaNhanVien", MaNhanVien),
            new SqlParameter("@GioBatDau", GioBatDau),
            new SqlParameter("@SoTien", SoTien),
           new SqlParameter("@tien", tien)


                };

                // Thực hiện truy vấn thêm sản phẩm và lấy ID của sản phẩm vừa thêm
                MaChamCong = db.ExecuteInsertAndGetIdentity(query, parameters);
                 
                return MaChamCong;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
        public List<string> thongtin(int MaChamCong)
        {
            string query = " SELECT SoTienBanDau,SoTienDuTinh " +
                         " FROM dbo.ChamCong " +
                         "  WHERE MaChamCong=" + MaChamCong + "";
            DataTable data = db.ExecuteQuery(query);

            List<string> chamcong = new List<string>();

            foreach (DataColumn column in data.Columns)
            {
                chamcong.Add(data.Rows[0][column].ToString());
            }

            return chamcong;
        }
        public List<string> tienbandau()
        {
            string query = " SELECT dbo.ChamCong.*   " +
                         " FROM dbo.ChamCong " +
                         " ORDER BY  MaChamCong DESC";
            DataTable data = db.ExecuteQuery(query);

            List<string> tien = new List<string>();

            foreach (DataColumn column in data.Columns)
            {
                tien.Add(data.Rows[0][column].ToString());
            }

            return tien;
        }
        public decimal TinhToanTime(DateTime? GioBatDauChoi)
        {
            decimal decimalValue = 0;
            try
            {
                TimeSpan timeDifference = DateTime.Now - GioBatDauChoi.Value;
                decimal totalHours = (decimal)timeDifference.TotalHours;
                // Chuyển đổi roundedTotalHours thành decimal(18, 2)
                decimalValue = Math.Round(totalHours, 2);// Làm tròn số giờ với 2 chữ số thập phân
                // giá trị dưới dạng decimal(18, 2)
            }
            catch (Exception)
            {
            }
            return decimal.Round((decimal)decimalValue, 2, MidpointRounding.AwayFromZero);


        }
        private void btnPhieuNhapMoi_Click(object sender, EventArgs e)
        {
          
            decimal tienBanDau =decimal.Parse(tienbandau()[6].ToString());
            time = DateTime.Now;
            MaChamCong = ChamCong(manhanvien, time, tienBanDau, tienBanDau);
            if (MaChamCong>0)
            {
                MessageBox.Show($"Nhân Viên{fLogin.HoTenNV} Chấm Công Thành Công \n Chúc Mừng bạn ko bị TRƯỜNG LƯ :)))");
                List<string> chamcong = thongtin(MaChamCong);
                txtBandau.Text = chamcong[0];
                txtDuTinh.Text = chamcong[1];

              
                btnKhachHang.Enabled = true;
                btnKho.Enabled = true;
                btnMenuDV.Enabled = true;
                btnTinhTrangBan.Enabled = true;

                btnChamCong.Visible = false;
                btnChot.Visible = true;
                groupBox1.Visible = true;
            }
           
        }
        public bool UpdateChamCong(int MaChamCong, decimal time , DateTime GioKetThuc , decimal moneyreal)
        {
            string query = "UPDATE ChamCong " +
                "  SET SoTienThucTe = @SoTienThucTe, GioKetThuc = @GioKetThuc , ThoiGianLamViec=@ThoiGianLamViec " +
                "    WHERE MaChamCong = @MaChamCong";
            SqlParameter[] parameters = new SqlParameter[]
   {
    new SqlParameter("@MaChamCong", MaChamCong),
    new SqlParameter("@SoTienThucTe", moneyreal),
    new SqlParameter("@GioKetThuc", GioKetThuc),
    new SqlParameter("@ThoiGianLamViec", time)

   };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
        private void btnChot_Click(object sender, EventArgs e)
        {
          decimal Time= TinhToanTime(time);
            if (txtThucTe.Text!=""&& txtThucTe.Text!= "Money")
            {
                if (UpdateChamCong(MaChamCong, Time, DateTime.Now, decimal.Parse(txtThucTe.Text)))
                {
                    MessageBox.Show("Chốt Ca Thành công \n Chim Cút");

                    Hide();
                    fLogin fActive2 = new fLogin();
                    fActive2.ShowInTaskbar = true;
                    fActive2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("số tiền thực tế ko dc trống ");
            }
         

         
        }

        private void lbTileName_Click(object sender, EventArgs e)
        {
            if (activeFrom != null && !activeFrom.IsDisposed)
            {
                activeFrom.Close();
                 
            }
            lblNameForm.Text = "Home";
            if (MaChamCong!=0)
            {
                List<string> chamcong = thongtin(MaChamCong);
                txtBandau.Text = chamcong[0];
                txtDuTinh.Text = chamcong[1];
            }
        

        }

        private void btnChamCongg_Click(object sender, EventArgs e)
        {
            lblNameForm.Text = "Chấm Công";
            openChildForm(new fChamCong(), pnMain);
        }

        private void txtBandau_OnValueChanged(object sender, EventArgs e)
        {
            if (txtBandau.Text != "")
            {
                if (int.TryParse(txtBandau.Text.Trim(), out int amount))
                {
                    if (amount > 0)
                    {
                        labelResult2.Text = amount.ToString("N0") + " VNĐ"; // Định dạng số tiền và thêm đơn vị
                    }
                    else
                    {
                        MessageBox.Show("giá tiền ko dc âm ");
                        txtBandau.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("giá tiền ko hợp lệ  ");
                    txtBandau.Text = "";
                }
            }
        }

        private void txtDuTinh_OnValueChanged(object sender, EventArgs e)
        {
            if (txtDuTinh.Text != "")
            {
                if (int.TryParse(txtDuTinh.Text.Trim(), out int amount))
                {
                    if (amount > 0)
                    {
                        label1.Text = amount.ToString("N0") + " VNĐ"; // Định dạng số tiền và thêm đơn vị
                    }
                    else
                    {
                        MessageBox.Show("giá tiền ko dc âm ");
                        txtDuTinh.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("giá tiền ko hợp lệ  ");
                    txtDuTinh.Text = "";
                }
            }
        }

        private void txtThucTe_OnValueChanged(object sender, EventArgs e)
        {
            if (txtThucTe.Text != "")
            {
                if (int.TryParse(txtThucTe.Text.Trim(), out int amount))
                {
                    if (amount > 0)
                    {
                        label2.Text = amount.ToString("N0") + " VNĐ"; // Định dạng số tiền và thêm đơn vị
                    }
                    else
                    {
                        MessageBox.Show("giá tiền ko dc âm ");
                        txtThucTe.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("giá tiền ko hợp lệ  ");
                    txtThucTe.Text = "";
                }
            }
        }
    }
}
