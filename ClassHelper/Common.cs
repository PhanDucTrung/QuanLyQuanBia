using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.ClassHelper
{
    public class Common
    {
        public static bool IsNumber(string pValue)
        {
            if (pValue == "")
            {
                return false;
            }
            for (int i = 0; i < pValue.Length; i++)
            {
                if (!char.IsDigit(pValue[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            // Sử dụng biểu thức chính quy để kiểm tra địa chỉ email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        public static string ConvertToVietnameseText(decimal number)
        {
            string[] units = { "", "nghìn", "triệu", "tỷ" };
            string[] words = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            string result = "";

            int unitIndex = 0;

            while (number > 0)
            {
                decimal chunk = number % 1000;
                number = Math.Floor(number / 1000);

                if (chunk > 0)
                {
                    string chunkText = "";

                    int ones = (int)(chunk % 10);
                    int tens = (int)((chunk % 100) / 10);
                    int hundreds = (int)(chunk / 100);

                    if (hundreds > 0)
                    {
                        chunkText += words[hundreds] + " trăm";
                        if (tens > 0 || ones > 0)
                            chunkText += " ";
                    }

                    if (tens > 1)
                    {
                        chunkText += words[tens] + " mươi";
                        if (ones > 0)
                            chunkText += " ";
                    }
                    else if (tens == 1)
                    {
                        chunkText += "mười";
                        if (ones > 0)
                            chunkText += " ";
                    }

                    if (ones > 0 && tens != 1)
                        chunkText += words[ones];

                    if (unitIndex > 0)
                        chunkText += " " + units[unitIndex];

                    result = chunkText + " " + result;
                }

                unitIndex++;
            }

            return result.Trim();
        }

        public static void ShowForm(Form form_0)
        {
            try
            {
                form_0.ShowInTaskbar = false;
                form_0.ShowDialog();
            }
            catch
            {
            }
        }

        public static string SelectImage(string title = "Chọn Hình Ảnh", string typeFile = "Image Files (*.jpg, *.png, *.gif, *.bmp)|*.jpg;*.png;*.gif;*.bmp|All files (*.*)|*.*")
        {
            string result = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = typeFile;
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Title = title;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    result = openFileDialog.FileName;
                }
            }
            return result;
        }

        public static bool CopyFile(string path_Goc, string path_Dich)
        {
            if (File.Exists(path_Goc))
            {
                try
                {
                    File.Copy(path_Goc, path_Dich, true);
                    if (File.Exists(path_Dich))
                    {
                        return true; // Sao chép thành công
                    }
                  
                }
                catch (Exception ex)
                {
                    if (File.Exists(path_Dich))
                    {
                        return true; // Sao chép thành công
                    }
                    Console.WriteLine("Lỗi khi sao chép tệp: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Tệp nguồn không tồn tại.");
            }
            return false; // Sao chép thất bại
        }

        public static string PathExE()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        public static string Path_NameFile(string pathFile,bool WithoutExtension = true)
        {
            if (WithoutExtension)
            {
                return Path.GetFileName(pathFile);
            }
            return Path.GetFileNameWithoutExtension(pathFile);
        }

        public static bool FileTonTai(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return true; //  File ton tai
                }

            }
            catch (Exception)
            {
            }

            return false; // File k ton tai
        }

        public static int ConverINT(object intNum)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(intNum);
            }
            catch (Exception)
            {
            }

            return num;
        }

        public static List<string> RemoveEmptyItems(List<string> List)
        {
            List<string> list = new List<string>();
            string text = "";
            for (int i = 0; i < List.Count; i++)
            {
                text = List[i].Trim();
                if (text != "")
                {
                    list.Add(text);
                }
            }
            return list;
        }


      
    }
}
