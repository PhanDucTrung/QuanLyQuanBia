using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBia.formHelper.ItemSP
{
   

    public partial class ItemSanPham : UserControl
    {

        public int count = 0;
        public int soluongton
        {
            set
            {
                count = value;
                if (value <= 5)
                {
                    lblTonKho.BackColor = ColorTranslator.FromHtml("#F68080");
                    if (value <= 0)
                        btnAddRoHang.Enabled = false;
                    else
                        btnAddRoHang.Enabled = true;
                    
                }
                lblTonKho.Text = value.ToString();

            }
            get { return this.count; }
        }

        public int _machitietSP;
        public int MaChiTietSanPham
        {
            set
            {
                this._machitietSP = value;
            }
            get { return _machitietSP; }
        }


        public int _maSP;
        public int MaSP
        {
            set
            {
                this._maSP = value;
            }
            get { return _maSP; }
        }


        public string _urimonan;
        public string uri_monan
        {
            set
            {
                this._urimonan = value;
            }
            get { return _urimonan; }
        }
        public string _name;
        public string name
        {
            set
            {
                _name = value;
                lbl_name.Text = value;
            }
            get { return this._name; }
        }
        public decimal _price;
        public decimal price
        {
            set
            {
                _price = value;
                lbl_price.Text = value.ToString() + "VNĐ";
            }
            get { return this._price; }
        }

      


        public event ItemValueChangedEventHandler itemValueChanged;

        public ItemSanPham()
        {
            InitializeComponent();
            //  btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
        }
        public int CountAdded
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
                if (this.count >= 5)
                {
                    lblTonKho.BackColor = Color.Gray;
                    btnAddRoHang.Enabled = true;
                    //  lblbtnMinus.Visible = true;
                }
                else
                {
                    lblTonKho.BackColor = ColorTranslator.FromHtml("#F68080");
                    if (this.count <= 0)
                    {
                       btnAddRoHang.Enabled = false;
                    }
                }
                lblTonKho.Text = value.ToString();
            }
        }

        public bool AddCartSuccess = false;



        public Task<Image> LoadImageFromFileAsync(string uri)
        {
            return Task.Run(() => {
                return Image.FromFile(uri);
            });
        }
        public async void LoadImageAsync()
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            var image = await LoadImageFromFileAsync(this.uri_monan);
            pictureBox.Image = image;
           

        }



        
        private void lblBtnAdd_Click(object sender, EventArgs e)
        {
         
            this.CountAdded += 1;
            ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(0, this.price, this.CountAdded);
            this.itemValueChanged(sender, myArgs);
           
        }

        private void lblbtnMinus_Click(object sender, EventArgs e)
        {
            if (this.CountAdded > 0)
            {
               
                ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(0, this.price, this.CountAdded);
                this.itemValueChanged(sender, myArgs);
                this.CountAdded -= 1;
            }
        }

        private void btnAddRoHang_Click(object sender, EventArgs e)
        {
           
            ItemValueChangedEventArgs myArgs = new ItemValueChangedEventArgs(1, this.price, this.CountAdded,this.MaSP,this.name,this.MaChiTietSanPham);
            this.itemValueChanged(sender, myArgs);
            if (myArgs.IsAdd)
            {
                this.CountAdded -= 1;
            }
            
        }





        public delegate void ItemValueChangedEventHandler(object sender, ItemValueChangedEventArgs e);
        public class ItemValueChangedEventArgs : EventArgs
        {
            private decimal value;
            private int SLvalue;
            private int numOrder;
            private string nameSP;
            private int maSP;
            private int maChiTietSP;
          

            public ItemValueChangedEventArgs(int _sl, decimal _value,int _numOrder,int _maSP = 0, string _nameSP = "",int _machitietSanPham = 0)
            {
                this.SLvalue = _sl;
                this.value = _value;
                this.numOrder = _numOrder;
                this.nameSP = _nameSP;
                this.maSP = _maSP;
                this.maChiTietSP = _machitietSanPham;
            }

            public int sLvalue { get { return this.SLvalue; } }
            public decimal Value { get { return this.value; } }
            public int NumOrder { get { return this.numOrder; } }
            public bool IsAdd;
            public string NameSP { get { return this.nameSP; } }
            public int MASP { get { return this.maSP; } }
            public int MaChiTietSanPham { get { return this.maChiTietSP; } }

        }
    }

}
