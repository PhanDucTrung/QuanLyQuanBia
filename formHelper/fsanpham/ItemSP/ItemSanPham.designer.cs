
namespace QuanLyQuanBia.formHelper.ItemSP
{
    partial class ItemSanPham
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTonKho = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnAddRoHang = new System.Windows.Forms.Label();
            this.lbl_name = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_price = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTonKho
            // 
            this.lblTonKho.BackColor = System.Drawing.Color.Gray;
            this.lblTonKho.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTonKho.ForeColor = System.Drawing.Color.White;
            this.lblTonKho.Location = new System.Drawing.Point(0, 0);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(28, 23);
            this.lblTonKho.TabIndex = 8;
            this.lblTonKho.Text = "0";
            this.lblTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(160, 137);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // btnAddRoHang
            // 
            this.btnAddRoHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnAddRoHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddRoHang.Location = new System.Drawing.Point(15, 193);
            this.btnAddRoHang.Name = "btnAddRoHang";
            this.btnAddRoHang.Size = new System.Drawing.Size(128, 26);
            this.btnAddRoHang.TabIndex = 47;
            this.btnAddRoHang.Text = "Thêm vào Rỏ Hàng";
            this.btnAddRoHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddRoHang.Click += new System.EventHandler(this.btnAddRoHang_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.Black;
            this.lbl_name.Location = new System.Drawing.Point(0, 137);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(160, 25);
            this.lbl_name.TabIndex = 62;
            this.lbl_name.Text = "Tên Sản Phẩm";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_price
            // 
            this.lbl_price.BackColor = System.Drawing.Color.Transparent;
            this.lbl_price.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_price.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_price.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price.ForeColor = System.Drawing.Color.Black;
            this.lbl_price.Location = new System.Drawing.Point(0, 162);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(160, 25);
            this.lbl_price.TabIndex = 63;
            this.lbl_price.Text = "Tên Sản Phẩm";
            this.lbl_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblTonKho);
            this.panel1.Location = new System.Drawing.Point(132, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(28, 23);
            this.panel1.TabIndex = 64;
            // 
            // ItemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btnAddRoHang);
            this.Controls.Add(this.pictureBox);
            this.Name = "ItemSanPham";
            this.Size = new System.Drawing.Size(160, 227);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label btnAddRoHang;
        internal Bunifu.Framework.UI.BunifuCustomLabel lbl_name;
        internal Bunifu.Framework.UI.BunifuCustomLabel lbl_price;
        private System.Windows.Forms.Panel panel1;
    }
}
