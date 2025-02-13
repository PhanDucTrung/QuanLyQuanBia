namespace QuanLyQuanBia.formHelper
{
    partial class fQLKhachHang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQLKhachHang));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.pnlClose = new System.Windows.Forms.Panel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.txbTimKiemTheoTuKhoakH = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnDeleteKhachHang = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnAddKhachHang = new Bunifu.Framework.UI.BunifuThinButton2();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSoDiemTichLuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEdit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(13, 778);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1438, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 778);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(13, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1425, 12);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(13, 766);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1425, 12);
            this.panel4.TabIndex = 3;
            // 
            // dtgv
            // 
            this.dtgv.AllowUserToAddRows = false;
            this.dtgv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSTT,
            this.cMaKhachHang,
            this.cHoTen,
            this.cSoDienThoai,
            this.cEmail,
            this.cSoDiemTichLuy,
            this.cEdit});
            this.dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv.DoubleBuffered = true;
            this.dtgv.EnableHeadersVisualStyles = false;
            this.dtgv.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgv.Location = new System.Drawing.Point(13, 124);
            this.dtgv.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.RowHeadersWidth = 51;
            this.dtgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv.Size = new System.Drawing.Size(1425, 642);
            this.dtgv.TabIndex = 8;
            this.dtgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_CellClick);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.pnlTop.Controls.Add(this.bunifuSeparator2);
            this.pnlTop.Controls.Add(this.pnlClose);
            this.pnlTop.Controls.Add(this.txbTimKiemTheoTuKhoakH);
            this.pnlTop.Controls.Add(this.btnDeleteKhachHang);
            this.pnlTop.Controls.Add(this.btnAddKhachHang);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(13, 12);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1425, 112);
            this.pnlTop.TabIndex = 7;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator2.ForeColor = System.Drawing.Color.Black;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 97);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(1425, 15);
            this.bunifuSeparator2.TabIndex = 91;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // pnlClose
            // 
            this.pnlClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClose.BackColor = System.Drawing.Color.Transparent;
            this.pnlClose.Controls.Add(this.btnClose);
            this.pnlClose.Location = new System.Drawing.Point(1397, -1);
            this.pnlClose.Margin = new System.Windows.Forms.Padding(4);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Size = new System.Drawing.Size(25, 26);
            this.pnlClose.TabIndex = 90;
            this.pnlClose.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ErrorImage")));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageActive")));
            this.btnClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnClose.InitialImage")));
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 26);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 356;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txbTimKiemTheoTuKhoakH
            // 
            this.txbTimKiemTheoTuKhoakH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbTimKiemTheoTuKhoakH.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbTimKiemTheoTuKhoakH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbTimKiemTheoTuKhoakH.HintForeColor = System.Drawing.Color.Empty;
            this.txbTimKiemTheoTuKhoakH.HintText = "Search keyword Khách hàng";
            this.txbTimKiemTheoTuKhoakH.isPassword = false;
            this.txbTimKiemTheoTuKhoakH.LineFocusedColor = System.Drawing.Color.Blue;
            this.txbTimKiemTheoTuKhoakH.LineIdleColor = System.Drawing.Color.Gray;
            this.txbTimKiemTheoTuKhoakH.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txbTimKiemTheoTuKhoakH.LineThickness = 3;
            this.txbTimKiemTheoTuKhoakH.Location = new System.Drawing.Point(91, 22);
            this.txbTimKiemTheoTuKhoakH.Margin = new System.Windows.Forms.Padding(5);
            this.txbTimKiemTheoTuKhoakH.Name = "txbTimKiemTheoTuKhoakH";
            this.txbTimKiemTheoTuKhoakH.Size = new System.Drawing.Size(364, 54);
            this.txbTimKiemTheoTuKhoakH.TabIndex = 89;
            this.txbTimKiemTheoTuKhoakH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbTimKiemTheoTuKhoakH.OnValueChanged += new System.EventHandler(this.txbTimKiemTheoTuKhoakH_OnValueChanged);
            // 
            // btnDeleteKhachHang
            // 
            this.btnDeleteKhachHang.ActiveBorderThickness = 1;
            this.btnDeleteKhachHang.ActiveCornerRadius = 20;
            this.btnDeleteKhachHang.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteKhachHang.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnDeleteKhachHang.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.btnDeleteKhachHang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteKhachHang.BackgroundImage")));
            this.btnDeleteKhachHang.ButtonText = "Xóa";
            this.btnDeleteKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteKhachHang.Enabled = false;
            this.btnDeleteKhachHang.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteKhachHang.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteKhachHang.IdleBorderThickness = 1;
            this.btnDeleteKhachHang.IdleCornerRadius = 20;
            this.btnDeleteKhachHang.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnDeleteKhachHang.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnDeleteKhachHang.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteKhachHang.Location = new System.Drawing.Point(1037, 22);
            this.btnDeleteKhachHang.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnDeleteKhachHang.Name = "btnDeleteKhachHang";
            this.btnDeleteKhachHang.Size = new System.Drawing.Size(267, 60);
            this.btnDeleteKhachHang.TabIndex = 86;
            this.btnDeleteKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteKhachHang.Visible = false;
            this.btnDeleteKhachHang.Click += new System.EventHandler(this.btnDeleteKhachHang_Click);
            // 
            // btnAddKhachHang
            // 
            this.btnAddKhachHang.ActiveBorderThickness = 1;
            this.btnAddKhachHang.ActiveCornerRadius = 20;
            this.btnAddKhachHang.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAddKhachHang.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnAddKhachHang.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.btnAddKhachHang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddKhachHang.BackgroundImage")));
            this.btnAddKhachHang.ButtonText = "Thêm";
            this.btnAddKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddKhachHang.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddKhachHang.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddKhachHang.IdleBorderThickness = 1;
            this.btnAddKhachHang.IdleCornerRadius = 20;
            this.btnAddKhachHang.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnAddKhachHang.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAddKhachHang.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddKhachHang.Location = new System.Drawing.Point(679, 22);
            this.btnAddKhachHang.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAddKhachHang.Name = "btnAddKhachHang";
            this.btnAddKhachHang.Size = new System.Drawing.Size(259, 60);
            this.btnAddKhachHang.TabIndex = 85;
            this.btnAddKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddKhachHang.Click += new System.EventHandler(this.btnAddKhachHang_Click_1);
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.MinimumWidth = 6;
            this.cSTT.Name = "cSTT";
            this.cSTT.ReadOnly = true;
            this.cSTT.Width = 50;
            // 
            // cMaKhachHang
            // 
            this.cMaKhachHang.DataPropertyName = "MaKhachHang";
            this.cMaKhachHang.HeaderText = "Mã khách hàng";
            this.cMaKhachHang.MinimumWidth = 6;
            this.cMaKhachHang.Name = "cMaKhachHang";
            this.cMaKhachHang.ReadOnly = true;
            this.cMaKhachHang.Visible = false;
            this.cMaKhachHang.Width = 150;
            // 
            // cHoTen
            // 
            this.cHoTen.DataPropertyName = "HoTen";
            this.cHoTen.HeaderText = "Họ tên";
            this.cHoTen.MinimumWidth = 6;
            this.cHoTen.Name = "cHoTen";
            this.cHoTen.Width = 150;
            // 
            // cSoDienThoai
            // 
            this.cSoDienThoai.DataPropertyName = "SoDienThoai";
            this.cSoDienThoai.HeaderText = "Số điện thoại";
            this.cSoDienThoai.MinimumWidth = 6;
            this.cSoDienThoai.Name = "cSoDienThoai";
            this.cSoDienThoai.Width = 150;
            // 
            // cEmail
            // 
            this.cEmail.DataPropertyName = "Email";
            this.cEmail.HeaderText = "Thông Tin Khác";
            this.cEmail.MinimumWidth = 6;
            this.cEmail.Name = "cEmail";
            this.cEmail.Width = 150;
            // 
            // cSoDiemTichLuy
            // 
            this.cSoDiemTichLuy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cSoDiemTichLuy.DataPropertyName = "SoDiemTichLuy";
            this.cSoDiemTichLuy.HeaderText = "Số Điểm Tích Lũy";
            this.cSoDiemTichLuy.MinimumWidth = 6;
            this.cSoDiemTichLuy.Name = "cSoDiemTichLuy";
            // 
            // cEdit
            // 
            this.cEdit.DataPropertyName = "ImgEdit";
            this.cEdit.HeaderText = "Sửa";
            this.cEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cEdit.MinimumWidth = 6;
            this.cEdit.Name = "cEdit";
            this.cEdit.Width = 50;
            // 
            // fQLKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 778);
            this.Controls.Add(this.dtgv);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fQLKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fKhachHang";
            this.Load += new System.EventHandler(this.fKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgv;
        private System.Windows.Forms.Panel pnlTop;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txbTimKiemTheoTuKhoakH;
        private Bunifu.Framework.UI.BunifuThinButton2 btnDeleteKhachHang;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddKhachHang;
        private System.Windows.Forms.Panel pnlClose;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSoDiemTichLuy;
        private System.Windows.Forms.DataGridViewImageColumn cEdit;
    }
}