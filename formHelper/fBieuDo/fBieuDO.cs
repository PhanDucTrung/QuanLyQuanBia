using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.formHelper.fBan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyQuanBia.formHelper.fBieuDo
{
    public partial class fBieuDO : Form
    {
        DatabaseHelper db;
      public  string thang;
       public string Nam;
        public fBieuDO(string Thang,string nam)
        {
            InitializeComponent();
            db = new DatabaseHelper("Data Source=TRUNG;Initial Catalog=quanly_quan_bi_a1;Integrated Security=True");
            thang = Thang;
            Nam = nam;

        }
        public DataTable DanhThuByTime(string year,string month)
        {
            string query = @"SELECT SUM(ThanhTien)AS Tien,YEAR(NgayLap)AS Nam,DAY(NgayLap)AS Ngay,MONTH(NgayLap) AS	Thang  
                                FROM dbo.HoaDon 
                                GROUP BY YEAR(NgayLap),DAY(NgayLap),MONTH(NgayLap)
                                HAVING YEAR(NgayLap)='"+year+"' AND MONTH(NgayLap)='"+month+"'";


            DataTable data = db.ExecuteQuery(query);
            return data;
        }
        public DataTable CTSP(string year, string month)
        {
            string query = @"SELECT SUM(dbo.ChiTietHoaDon.GiaBan) AS Tien,SUM(SoLuong) AS SL,TenSanPham,YEAR(NgayLap)AS Nam,MONTH(NgayLap) AS Thang 
                            FROM dbo.HoaDon ,dbo.ChiTietHoaDon,dbo.SanPham
                               WHERE ChiTietHoaDon.MaSanPham=SanPham.MaSanPham AND ChiTietHoaDon.MaHoaDon=HoaDon.MaHoaDon
                               GROUP BY YEAR(NgayLap),MONTH(NgayLap),TenSanPham
                                HAVING YEAR(NgayLap)='" + year + "' AND MONTH(NgayLap)='" + month + "'";


            DataTable data = db.ExecuteQuery(query);
            return data;
        }

        public decimal CTBan(string year, string month)
        {
            string query = @"
                        SELECT SUM(ThanhTien)
                            FROM dbo.HoaDon
                             WHERE YEAR(NgayLap)='" + year + "' AND MONTH(NgayLap)='" + month + "'";
                        

            DataTable data = db.ExecuteQuery(query);
            decimal tien =decimal.Parse( data.Rows[0][0].ToString());
            return tien ;
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fBieuDO_Load(object sender, EventArgs e)
        {

            decimal TienBan = CTBan(Nam, thang);
            decimal tiendv=0;
            decimal tienn;
            //Doanh Thu Ngay
            DataTable data = DanhThuByTime(Nam,thang);
            charDTN.ChartAreas["ChartArea1"].AxisX.Title = "Ngày"; 
            //charDTN.ChartAreas["ChartArea1"].AxisY.Title = "VNĐ";
            charDTN.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            charDTN.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            for (int i = 0; i < data.Rows.Count; i++)
            {

                tienn = decimal.Parse(data.Rows[i]["Tien"].ToString()) / 1000; 
                charDTN.Series["Doanh Thu"].Points.AddXY(data.Rows[i]["Ngay"], tienn);
              
            }
            //Doanh Thu Sản Phẩm 
         
            DataTable data1 = CTSP(Nam, thang);
            //CharCTDV.ChartAreas["ChartArea1"].AxisX.Title = "Tên Sản Phẩm";
            //CharCTDV.ChartAreas["ChartArea1"].AxisY.Title = "(Nghìn VNĐ)";
            CharCTDV.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            CharCTDV.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            CharCTDV.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            CharCTDV.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
            for (int i = 0; i < data1.Rows.Count; i++)
            {
                tienn = decimal.Parse(data1.Rows[i]["Tien"].ToString()) / 1000;
                tiendv += tienn;
                CharCTDV.Series["Doanh Thu"].Points.AddXY(data1.Rows[i]["TenSanPham"], tienn);
                CharCTDV.Series["Số Lượng Bán"].Points.AddY(data1.Rows[i]["SL"]);

            }




            //    DataTable data2 = CTBan(Nam, thang);
            //    //CharCTDV.ChartAreas["ChartArea1"].AxisX.Title = "Tên Sản Phẩm";
            //    //CharCTDV.ChartAreas["ChartArea1"].AxisY.Title = "(Nghìn VNĐ)";
            //    CharTL.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            //    CharTL.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            //    CharTL.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //    CharTL.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
            //    for (int i = 0; i < data2.Rows.Count; i++)
            //    {
            //        tienn = decimal.Parse(data2.Rows[i][0].ToString()) / 1000;
            //        CharTL.Series["Doanh Thu"].Points.AddXY(data2.Rows[i][1], tienn);
            //        CharTL.Series["Số Lượng Đặt"].Points.AddY(data1.Rows[i][2]);

            //    }



            CharTL.Series["Doanh Thu"].Points.AddXY("Tiền DV",tiendv*1000);
            CharTL.Series["Doanh Thu"].Points.AddXY("Tiền bàn",TienBan-tiendv*1000);
 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
