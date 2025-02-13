using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBia.formHelper.ItemSP
{
    class ListSanPhamHelper
    {
        public int MaChiTietSanPham { get; set; }
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public string LoaiSanPham { get; set; }
        public string GhiChu { get; set; }
        public string pathImg { get; set; }
        public int SoLuongTon { get; set; }

        public int num_order { get; set; } = 0;
        public int Total
        {
            get
            {
                return num_order * (int)Gia;
            }
        }

        public static List<ListSanPhamHelper> GetListSP(DataTable dataTable)
        {
            var listSanPham = new List<ListSanPhamHelper>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                listSanPham.Add(new ListSanPhamHelper()
                {
                    MaChiTietSanPham = (int)row["MaChiTietSanPham"],
                    MaSanPham = (int)row["MaSanPham"],
                    TenSanPham = (string)row["TenSanPham"],
                    Gia = (decimal)row["Gia"],
                    LoaiSanPham = (string)row["LoaiSanPham"],
                    GhiChu = (string)row["GhiChu"],
                    pathImg = (string)row["pathImg"], 
                    SoLuongTon = (int)row["SoLuongTon"]

                });
            }
            return listSanPham;
        }
    }

}
