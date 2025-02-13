using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBia.formHelper.fBan
{
    class ItemBan
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string TenLoaiBan { get; set; }
       
        public decimal GiaTheoGio { get; set; }
        public string MieuTa { get; set; }
        public string TinhTrang { get; set; }
        public int MaHoaDon { get; set; }
        public DateTime? GioBatDauChoi { get; set; }
   
        public string DuongDanHinhAnh { get; set; }

        

        public static List<ItemBan> GetListBan(DataTable dataTable)
        {
            
            var listBan = new List<ItemBan>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                DateTime? gioBatDauChoi = row["GioBatDauChoi"] as DateTime?;
                // Kiểm tra xem gioBatDauChoi có null không, nếu có thì gán một giá trị mặc định (ví dụ: DateTime.MinValue)
              


                listBan.Add(new ItemBan()
                {
                    MaBan = (int)row["MaBan"],
                    TenBan = (string)row["TenBan"],
                    TenLoaiBan = (string)row["TenLoaiBan"], // Giả sử TenLoaiBan là kiểu string
               
                    GiaTheoGio = (decimal)row["GiaTheoGio"], // Giả sử GiaTheoGio là kiểu decimal
                    MieuTa = (string)row["MieuTa"], // Sửa tên cột thành MieuTa
                    DuongDanHinhAnh = (string)row["DuongDanHinhAnh"], // Sửa tên cột thành DuongDanHinhAnh
                    MaHoaDon = (int)row["MaHoaDon"],
                    TinhTrang = (string)row["TinhTrang"], // Giả sử TinhTrang là kiểu string
                    
                    GioBatDauChoi = gioBatDauChoi
                });
            }
            return listBan;
        }

       


    }
}
