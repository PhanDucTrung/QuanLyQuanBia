using QuanLyQuanBia.ClassHelper;
using QuanLyQuanBia.ClassHelper.fLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.formHelper.fBieuDo
{
    public partial class fBieuDoNgoai : Form
    {
        DatabaseHelper db;
        public fBieuDoNgoai()
        {
            InitializeComponent();
            //db = new DatabaseHelper(fLogin.connectionStringSQL);
            db = new DatabaseHelper("Data Source=TRUNG;Initial Catalog=quanly_quan_bi_a1;Integrated Security=True");
            List<string> year = Year();
            comboBox1.DataSource = year;
            comboBox1 .SelectedIndex = year.Count-1;
        }
        public List<string> Year()
        {
            string query = "SELECT DISTINCT YEAR(NgayLap) AS Nam FROM dbo.HoaDon";
            DataTable data = db.ExecuteQuery(query);

            List<string> year = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                year.Add(row["Nam"].ToString());
            }

            return year;
        }
        public DataTable DanhThuByTime(string year)
        {
                string query = @"SELECT MONTH(NgayLap) AS Thang,YEAR(NgayLap) AS Nam,SUM(ThanhTien) AS Tien
                                FROM dbo.HoaDon  
                                GROUP BY MONTH(NgayLap),YEAR(NgayLap)
                                HAVING YEAR(NgayLap)='" + year+ "'";


            DataTable data = db.ExecuteQuery(query);
            return data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            chart1.Series["Doanh Thu"].Points.Clear();
         DataTable data= DanhThuByTime(comboBox1.SelectedItem.ToString());

            groupBox1.Visible = true;
            comboBox2.DataSource = data;
            comboBox2.ValueMember = "Thang";
            comboBox2.SelectedIndex=data.Rows.Count-1;

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Thang";
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            for (int i = 0; i < data.Rows.Count ; i++)
            {
                chart1.Series["Doanh Thu"].Points.AddXY(data.Rows[i]["Thang"], data.Rows[i]["Tien"]);
            }
        }

        private void pnlTopTrai_Paint(object sender, PaintEventArgs e)
        {

        }
     

     
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Common.ShowForm(new fBieuDO(comboBox2.Text, comboBox1.Text));
        
        }

        private void fBieuDoNgoai_Load(object sender, EventArgs e)
        {

        }
    }
}
