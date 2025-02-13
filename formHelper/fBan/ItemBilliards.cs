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

namespace QuanLyQuanBia.formHelper.fBan
{
    
    public partial class ItemBilliards : UserControl
    {
       
        DatabaseHelper db;

        public int _maBan;
        public int MaBan 
        {
            set{this._maBan = value;}
            get { return _maBan; }

        }

        public string _tenBan;
        public string TenBan
        {
            set { this._tenBan = value; lbl_name.Text = value.ToString(); }
            get { return _tenBan; }
        }

        public string _tenloaiBan;
        public string TenLoaiBan 
        {
            set { this._tenloaiBan = value; lblTypeBan.Text = value.ToString(); }
            get { return _tenloaiBan; }
        }

        public decimal _giatheogio;
        public decimal GiaTheoGio
        {
            set { this._giatheogio = value; lbl_price.Text = value.ToString() + "VNĐ /1H"; }
            get { return _giatheogio; }
        }


        public string _tinhtrang { get; set; }
        public string TinhTrang
        {
            set
            {
                _tinhtrang = value;
                if (_tinhtrang != "Trống")
                {
                    
                    doimau();
                }
               

            }
            get { return this._tinhtrang; }
        }


        public DateTime? _giobatdauChoi { get; set; }
        public DateTime? GioBatDauChoi
        {
            set
            {
                this._giobatdauChoi = value;
                int totalMinutes = 0;
                if (GioBatDauChoi != null)
                {
                    TimeSpan timeDifference = DateTime.Now - _giobatdauChoi.Value;
                    totalMinutes = (int)timeDifference.TotalMinutes;

                    decimal totalPrice = totalMinutes * GiaTheoGio;
                    sotien = $"{totalPrice.ToString("#,##0")} VNĐ";
                    int hoursDifference = timeDifference.Hours; // Lấy số giờ
                    int minutesDifference = timeDifference.Minutes; // Lấy số phút
                    int secondsDifference = timeDifference.Seconds; // Lấy số giây
                    sogiochoi = $"{hoursDifference}{minutesDifference}{secondsDifference}";
                }
            }
            get { return _giobatdauChoi; }
        }


        public string _duongdanhinhanh;
        public string DuongDanHinhAnh
        {
            set
            {
                this._duongdanhinhanh = value;
            }
            get { return _duongdanhinhanh; }
        }


        public string _mieuta;
        public string MieuTa
        {
            set
            {
                this._mieuta = value;
            }
            get { return _mieuta; }
        }

        public int _mahoadon;
        public int MaHoaDon
        {
            set
            {
                this._mahoadon = value;
            }
            get { return _mahoadon; }
        }


        public string sogiochoi = "";
        public string sotien = "";



        public void doimau()
        {
            this.BackColor = Color.Red;
            this.Padding = new Padding(1, 1, 1, 1);
            btnView.ActiveFillColor = Color.Red;
            btnView.ActiveLineColor = Color.Red;
            btnView.ForeColor = Color.Red;
            btnView.IdleForecolor = Color.Red; // chu ben trong
            btnView.IdleLineColor = Color.Red; // vien
            bunifuThinButton21.Visible = false;
        }





        // đăng ký sự kiện itemValueChanged ở form này
        public event ItemValueChangedEventHandler itemValueChanged;

        public ItemBilliards()
        {
            db = new DatabaseHelper(fLogin.connectionStringSQL);
            InitializeComponent();
          
        }


        public Task<Image> LoadImageFromFileAsync(string uri)
        {
            return Task.Run(() => {
                return Image.FromFile(uri);
            });
        }
        public async void LoadImageAsync()
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            var image = await LoadImageFromFileAsync(this.DuongDanHinhAnh);
            pictureBox.Image = image;


        }



        private void btnView_Click(object sender, EventArgs e)
        {
            //if (_tinhtrang != "Trống")
            //{

            //    ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(this.MaBan, this.TenBan, this.TenLoaiBan, this.GiaTheoGio, this.MieuTa, this.TinhTrang, this.MaHoaDon, this.GioBatDauChoi);
            //    this.itemValueChanged(sender, myArgs);
            //}
            //else
            //{
                Common.ShowForm(new fThemBanMoi($"Update Sản Phẩm: {_tenBan}",_maBan.ToString(),_tenBan,_tenloaiBan,_giatheogio,MieuTa,_duongdanhinhanh));
            ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(this.MaBan, this.TenBan, this.TenLoaiBan, this.GiaTheoGio, this.MieuTa, this.TinhTrang, this.MaHoaDon, this.GioBatDauChoi);
            this.itemValueChanged(sender, myArgs);
            // }

        }

        // thực thi sự kiện ItemValueChangedEventHandler
        public delegate void ItemValueChangedEventHandler(object sender, ItemValueChangedEventArgs e);
        public class ItemValueChangedEventArgs : EventArgs // lưu trữ sự kiện
        {
            private int maBan;
            private string tenBan;
            private string tenLoaiBan;
            private decimal giaTheoGio;
            private string mieuta;
            private string tinhTrang;
            private DateTime? gioBatDauChoi;
            private int mahoadon;

            // các biến của sự kiện
            public ItemValueChangedEventArgs(int _maBan, string _tenBan, string _tenLoaiBan, decimal _giaTheoGio,string _mieuta ,string _tinhTrang,int _mahoadon, DateTime? gioBatDauChoi =null)
            {
                this.maBan = _maBan;
                this.tenBan = _tenBan;
                this.tenLoaiBan = _tenLoaiBan;
                this.giaTheoGio = _giaTheoGio;
                this.mieuta = _mieuta;
                this.tinhTrang = _tinhTrang;
                this.mahoadon = _mahoadon;
                this.gioBatDauChoi = gioBatDauChoi;
             
            }

            // các biến của sự kiện
            public int MaBan { get { return this.maBan; } }
            public string TenBan { get { return this.tenBan; } }
            public string TenLoaiBan { get { return this.tenLoaiBan; } }
            public decimal GiaTheoGio { get { return this.giaTheoGio; } }
            public string MieuTa { get { return this.mieuta; } }
            public string TinhTrang { get { return this.tinhTrang; } }
            public int MaHoaDon { get { return this.mahoadon; } }
            public DateTime? GioBatDauChoi { get { return this.gioBatDauChoi; } }
        }
        fTableStatus fTableStatus = new fTableStatus();
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DateTime timeHienTai = DateTime.Now;


            //sẽ có 2 trạng thái là : Đang Sử dụng và Trống
            int maHoaDon = 0;
            if (_tinhtrang == "Trống")
            {
                // Thêm hóa đơn và lấy mã hóa đơn vừa thêm
                maHoaDon = ThemHoaDon(_maBan, timeHienTai, _tenBan);
               int maloaiban= layMaban(_tenloaiBan);
                // thay đổi trạng thái của bàn  Và Thêm ID mã hóa đơn vào Bàn đó :D 
                CapNhatBan(_maBan, _tenBan, maloaiban, "Đang sử dụng", timeHienTai, maHoaDon);
            }
         

            ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(this.MaBan, this.TenBan, this.TenLoaiBan, this.GiaTheoGio, this.MieuTa, this.TinhTrang, this.MaHoaDon, this.GioBatDauChoi);
            this.itemValueChanged(sender, myArgs);
        }

        public int layMaban(string tenloai) // get Ban.MaHoaDon Bảng Ban :D
        {
            int MaLoaiBan = -1;  // Giá trị mặc định nếu không tìm thấy

            string query = "SELECT MaLoaiBan FROM LoaiBan WHERE TenLoaiBan = @MaBan";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaBan", tenloai) };

            DataTable data = db.ExecuteQuery(query, parameters);
            MaLoaiBan = (int)data.Rows[0]["MaLoaiBan"];


            return MaLoaiBan;
        }
        public int CapNhatBan(int maBan, string tenBan, int maLoaiBan, string tinhTrang, DateTime gioBatDauChoi, int maHoaDon)
        {
            string query = "UPDATE Ban " +
                           "SET TenBan = @TenBan, MaLoaiBan = @MaLoaiBan, TinhTrang = @TinhTrang, GioBatDauChoi = @GioBatDauChoi, MaHoaDon = @MaHoaDon " +
                           "WHERE MaBan = @MaBan";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaBan", maBan),
        new SqlParameter("@TenBan", tenBan),
        new SqlParameter("@MaLoaiBan", maLoaiBan),
        new SqlParameter("@TinhTrang", tinhTrang),
        new SqlParameter("@GioBatDauChoi", gioBatDauChoi),
        new SqlParameter("@MaHoaDon", maHoaDon)
            };

            int rowsAffected = db.ExecuteNonQuery(query, parameters);

            return rowsAffected;
        }
     
        public int ThemHoaDon(int maBan, DateTime ngayLap, string tenban)
        {

            string query = "INSERT INTO HoaDon (MaBan, NgayLap, TenBan) " +
                           "VALUES (@MaBan, @NgayLap, @TenBan)";

            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@MaBan", maBan),
             new SqlParameter("@NgayLap", ngayLap),
             new SqlParameter("@TenBan", tenban),
            };

            int newMaHoaDon = db.ExecuteInsertAndGetIdentity(query, parameters);

            return newMaHoaDon;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(this.MaBan, this.TenBan, this.TenLoaiBan, this.GiaTheoGio, this.MieuTa, this.TinhTrang, this.MaHoaDon, this.GioBatDauChoi);
            this.itemValueChanged(sender, myArgs);
        }
    }
}
