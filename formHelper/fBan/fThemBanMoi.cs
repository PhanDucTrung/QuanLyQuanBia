using QuanLyQuanBia.ClassHelper.fLogin;
using QuanLyQuanBia.ClassHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS.ClassHelper;

namespace QuanLyQuanBia.formHelper.fBan
{
    public partial class fThemBanMoi : Form
    {   public static  int maban;
        DatabaseHelper db;
        string imagePath;
        public fThemBanMoi(bool check)
        {   
            InitializeComponent();
            db = new DatabaseHelper(fLogin.connectionStringSQL);
            List<string> donViTinhList = LayLoaiBan();
            cbbLoaiBan.DataSource = donViTinhList;
            groupBox1.Enabled = check;
      
            if (check == false)
            {
                //checkBox1.Checked = true;
             
                txbTenBan.Text = "trống";
                lbTileName.Text = " Phiếu Loại Bàn";
            }
          

        }
        public int MaLoaiBan=0;
     
        public fThemBanMoi(string TileName, string MaBan, string TenBan,  string LoaiBan,  decimal giatheogio, string GhiChu, string pathIMG)
        {
            InitializeComponent();
            //this.BackColor = Color.DodgerBlue;
            //this.Padding = new Padding(1, 1, 1, 1);
            db = new DatabaseHelper(fLogin.connectionStringSQL);

            // Gọi hàm để lấy danh sách đơn vị tính
            List<string> donViTinhList = LayLoaiBan();
            cbbLoaiBan.DataSource = donViTinhList;
            //// Đổ danh sách đơn vị tính vào ComboBox
            //foreach (string donViTinh in donViTinhList)
            //{
            //    cbbDonVi.Items.Add(donViTinh);
            //}
            lbTileName.Text = TileName;
            txbMaBan.Text = MaBan;
         
            txbTenBan.Text = TenBan;
            cbbLoaiBan.SelectedItem = LoaiBan;
            string GiaBanLe = giatheogio.ToString().Trim();
       
            txbGiaTheoGio.Text = GiaBanLe.ToString();

            

         
            txbGhiChu.Text = GhiChu;

            imagePath = pathIMG;
            if (Common.FileTonTai(Common.PathExE() + imagePath))
            {
                pictureBox.Image = Image.FromFile(Common.PathExE() + imagePath);
            }
            btnAdd.ButtonText = "Update";
            btnAddIMG.ButtonText = "Sửa ảnh Sản Phẩm";
         
        }
        public List<string> LayLoaiBan()
        {
            string query = "SELECT DISTINCT TenLoaiBan FROM LoaiBan";
            DataTable data = db.ExecuteQuery(query);

            List<string> danhsachban = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                danhsachban.Add(row["TenLoaiBan"].ToString());
            }

            return danhsachban;
        }
        public List<string> LayDSban(string TenloaiBan)
        {
            string query = "SELECT LoaiBan.* " +
                         "FROM LoaiBan " +
                         "  WHERE TenLoaiBan=N'" + TenloaiBan + "'";
            DataTable data = db.ExecuteQuery(query);

            List<string> LoaiBan = new List<string>();

            foreach (DataColumn column in data.Columns)
            {
                LoaiBan.Add(data.Rows[0][column].ToString());
            }

            return LoaiBan;
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
          
            this.Close();

        }

        private void cbbLoaiBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiBan.SelectedIndex!=-1)
            {
                List<string> ban = LayDSban(cbbLoaiBan.SelectedItem.ToString());

                MaLoaiBan = int.Parse(ban[0]);
                txbGiaTheoGio.Text = ban[2];
                txbGhiChu.Text = ban[3];
                imagePath = ban[4];
                checkBox1.Checked = false;
               
                btnAddIMG.ButtonText = "Sửa ảnh Loại Bàn";

                if (Common.FileTonTai(Common.PathExE() + imagePath))
                {
                    pictureBox.Image = Image.FromFile(Common.PathExE() + imagePath);
                }

                //btnAdd.ButtonText = "Thêm Bàn";
                if (groupBox1.Enabled==false)
                {
                    lbTileName.Text = $"Sửa Bàn {cbbLoaiBan.Text}";
                }
            }
           
           
        }

        private void txbGiaTheoGio_OnValueChanged(object sender, EventArgs e)
        {
            if (txbGiaTheoGio.Text != "")
            {
                if (int.TryParse(txbGiaTheoGio.Text.Trim(), out int amount))
                {
                    if (amount > 0)
                    {
                        labelResult2.Text = amount.ToString("N0") + " VNĐ"; // Định dạng số tiền và thêm đơn vị
                    }
                    else
                    {
                        MessageBox.Show("giá tiền ko dc âm ");
                        txbGiaTheoGio.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("giá tiền ko hợp lệ  ");
                    txbGiaTheoGio.Text = "";
                }
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        //bool checkban()
        //{
        //   bool check = false;
        //    foreach (var item in LayLoaiBan())
        //    {
        //        if (checkBox1.Checked==false)
        //        {
        //            if (item == cbbLoaiBan.Text)
        //            {
        //                check = true;
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            if (item == cbbLoaiBan.Text)
        //            {
        //                check = false;
        //                break;

        //            }
        //            else
        //            {
        //                check=true;
        //            }

        //        }
              
        //    }
        //    return check;
        //}
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (imagePath == "" || txbTenBan.Text == "" || txbGiaTheoGio.Text == "" || txbGhiChu.Text == "" || cbbLoaiBan.Text == "")
            {
                MessageBoxHelper.ShowMessageBox("Vui lòng điền đầy đủ thông tin, Thử lại sau!"); return;
            }
            
            if (checkBox1.Checked==true)
            {
               MaLoaiBan = ThemLoaiBan(cbbLoaiBan.Text, decimal.Parse(txbGiaTheoGio.Text), txbGhiChu.Text, imagePath);
                if (groupBox1.Enabled==false)
                {
                    if (MessageBoxHelper.Show($"Thêm thành công Loại Bàn: {cbbLoaiBan.Text.Trim()}\nĐóng của sổ ?") == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show($"Sửa Thành công Loại Bàn: {cbbLoaiBan.Text.Trim()}!");
                }

            }
            else
            {
                UpdateLoaiBan(cbbLoaiBan.Text,decimal.Parse(txbGiaTheoGio.Text),txbGhiChu.Text,imagePath);
            }

          
                if (btnAdd.ButtonText== "Update")
            {
                UpdateBan(int.Parse(txbMaBan.Text),MaLoaiBan,txbTenBan.Text);
                MessageBox.Show("Sửa Bàn Thành Công");
            }
            else
            {
                if (lbTileName.Text == "Thêm Bàn Mới")
                {
                    ThemBan(txbTenBan.Text, MaLoaiBan);
                    MessageBox.Show("Thêm bàn Thành Công");
                }
              
            }


            List<string> donViTinhList = LayLoaiBan();
            cbbLoaiBan.DataSource = donViTinhList;
           
        }

        private void cbbLoaiBan_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
          
            btnAddIMG.ButtonText = "Thêm Ảnh Loại Bàn";
            if (groupBox1.Enabled==false)
            {
                btnAdd.ButtonText = "Nhập";
                lbTileName.Text = "Phiếu Loại Bàn";
            }
        }

        private void fThemBanMoi_Load(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
           
        }
        public int ThemLoaiBan(string TenBan,decimal GiaTheoGio,string MieuTa,string Anh)
        {
            try
            {
                // Query để chèn dữ liệu mới vào bảng SanPham
                string query = "INSERT INTO dbo.LoaiBan(TenLoaiBan,GiaTheoGio,MieuTa,DuongDanHinhAnh)  " +
                               "VALUES(@TenLoaiBan,@GiaTheoGio,@MieuTa,@Anh); SELECT SCOPE_IDENTITY();";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {

            new SqlParameter("@TenLoaiBan", TenBan),
            new SqlParameter("@GiaTheoGio", GiaTheoGio),
            new SqlParameter("@MieuTa", MieuTa),
            new SqlParameter("@Anh", Anh),

                };

                // Thực hiện truy vấn thêm sản phẩm và lấy ID của sản phẩm vừa thêm
                int newProductId = db.ExecuteInsertAndGetIdentity(query, parameters);

                return newProductId;

            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
        public int ThemBan(string TenBan,int MaLoaiBan)
        {
            // Query để chèn dữ liệu mới vào bảng SanPham
            string query = "INSERT INTO dbo.Ban ( TenBan,MaLoaiBan,TinhTrang,MaHoaDon) " +
                           " VALUES(@TenBan,@MaLoaiBan,N'Trống', 0); SELECT SCOPE_IDENTITY();";

            // Tạo danh sách tham số để truyền vào truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {

            new SqlParameter("@TenBan", TenBan),
            new SqlParameter("@MaLoaiBan", MaLoaiBan),
      

            };

            // Thực hiện truy vấn thêm sản phẩm và lấy ID của sản phẩm vừa thêm
               int newProductId = db.ExecuteInsertAndGetIdentity(query, parameters);
            return newProductId;
        }
        public bool UpdateBan(int MaBan, int MaloaiBan, string TenBan)
        {
            string query = "UPDATE Ban  " +
                           "SET TenBan=@TenBan,MaLoaiBan=@MaLoaiBan  " +
                           "WHERE MaBan = @MaBan";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TenBan", TenBan),
        new SqlParameter("@MaLoaiBan", MaloaiBan),
        new SqlParameter("@MaBan", MaBan),
       
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateLoaiBan(string TenLoaiBan, decimal GiaTheoGio, string MieuTa, string Anh)
        {
            string query = "UPDATE LoaiBan " +
                           "SET MieuTa=@MieuTa,DuongDanHinhAnh=@Anh ,GiaTheoGio=@GiaTheoGio  " +
                           "WHERE  TenLoaiBan=@TenLoaiBan";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TenLoaiBan", TenLoaiBan),
        new SqlParameter("@MieuTa", MieuTa),
        new SqlParameter("@GiaTheoGio", GiaTheoGio),
        new SqlParameter("@Anh", Anh),

            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
        private void btnAddIMG_Click(object sender, EventArgs e)
        {
            imagePath = Common.SelectImage(); // Gọi hàm để chọn hình ảnh
            if (!string.IsNullOrEmpty(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
                string NameFile = Common.Path_NameFile(imagePath);
                if (Common.CopyFile(imagePath, Common.PathExE() + $"\\img\\BanBillar\\{NameFile}"))
                {
                    imagePath = $"\\img\\BanBillar\\{NameFile}";
                }
            }
        }
    }
}
