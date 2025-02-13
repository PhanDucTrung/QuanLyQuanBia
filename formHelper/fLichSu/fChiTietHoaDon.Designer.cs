namespace QuanLyQuanBia.formHelper.fLichSu
{
    partial class fChiTietHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChiTietHoaDon));
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaChiTietHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGia = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.lbTileName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.pnMain.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.White;
            this.pnMain.Controls.Add(this.panel5);
            this.pnMain.Controls.Add(this.btnClose);
            this.pnMain.Controls.Add(this.lbTileName);
            this.pnMain.Controls.Add(this.panel3);
            this.pnMain.Controls.Add(this.panel4);
            this.pnMain.Controls.Add(this.panel2);
            this.pnMain.Controls.Add(this.panel1);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(627, 450);
            this.pnMain.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bunifuSeparator1);
            this.panel5.Controls.Add(this.dtgv);
            this.panel5.Controls.Add(this.lblGia);
            this.panel5.Controls.Add(this.bunifuSeparator2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(607, 392);
            this.panel5.TabIndex = 365;
            // 
            // dtgv
            // 
            this.dtgv.AllowUserToAddRows = false;
            this.dtgv.AllowUserToDeleteRows = false;
            this.dtgv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSTT,
            this.cMaChiTietHoaDon,
            this.cMaHoaDon,
            this.cTenSanPham,
            this.cMaSanPham,
            this.cSoLuong,
            this.cDonGia,
            this.cGiaBan});
            this.dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv.DoubleBuffered = true;
            this.dtgv.EnableHeadersVisualStyles = false;
            this.dtgv.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgv.Location = new System.Drawing.Point(0, 10);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv.Size = new System.Drawing.Size(607, 344);
            this.dtgv.TabIndex = 364;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.Width = 50;
            // 
            // cMaChiTietHoaDon
            // 
            this.cMaChiTietHoaDon.DataPropertyName = "MaChiTietHoaDon";
            this.cMaChiTietHoaDon.HeaderText = "Mã Chi Tiết Hóa Đơn";
            this.cMaChiTietHoaDon.Name = "cMaChiTietHoaDon";
            this.cMaChiTietHoaDon.Visible = false;
            // 
            // cMaHoaDon
            // 
            this.cMaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cMaHoaDon.DataPropertyName = "MaHoaDon";
            this.cMaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.cMaHoaDon.Name = "cMaHoaDon";
            this.cMaHoaDon.Visible = false;
            this.cMaHoaDon.Width = 130;
            // 
            // cTenSanPham
            // 
            this.cTenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTenSanPham.DataPropertyName = "TenSanPham";
            this.cTenSanPham.HeaderText = "Tên Sản Phẩm";
            this.cTenSanPham.Name = "cTenSanPham";
            // 
            // cMaSanPham
            // 
            this.cMaSanPham.DataPropertyName = "MaSanPham";
            this.cMaSanPham.HeaderText = "Mã Sản Phẩm";
            this.cMaSanPham.Name = "cMaSanPham";
            this.cMaSanPham.Visible = false;
            this.cMaSanPham.Width = 150;
            // 
            // cSoLuong
            // 
            this.cSoLuong.DataPropertyName = "SoLuong";
            this.cSoLuong.HeaderText = "Số Lượng";
            this.cSoLuong.Name = "cSoLuong";
            // 
            // cDonGia
            // 
            this.cDonGia.DataPropertyName = "Gia";
            this.cDonGia.HeaderText = "Đơn Giá";
            this.cDonGia.Name = "cDonGia";
            // 
            // cGiaBan
            // 
            this.cGiaBan.DataPropertyName = "GiaBan";
            this.cGiaBan.HeaderText = "Thành Tiền";
            this.cGiaBan.Name = "cGiaBan";
            this.cGiaBan.Width = 150;
            // 
            // lblGia
            // 
            this.lblGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.lblGia.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblGia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGia.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(197)))));
            this.lblGia.Location = new System.Drawing.Point(0, 354);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(607, 38);
            this.lblGia.TabIndex = 363;
            this.lblGia.Text = "Tổng cộng: 0 vnđ";
            this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuSeparator2.ForeColor = System.Drawing.Color.Black;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 0);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(607, 10);
            this.bunifuSeparator2.TabIndex = 105;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ErrorImage")));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageActive")));
            this.btnClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnClose.InitialImage")));
            this.btnClose.Location = new System.Drawing.Point(600, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 18);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 363;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTileName
            // 
            this.lbTileName.BackColor = System.Drawing.Color.GhostWhite;
            this.lbTileName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbTileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTileName.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(197)))));
            this.lbTileName.Location = new System.Drawing.Point(10, 10);
            this.lbTileName.Name = "lbTileName";
            this.lbTileName.Size = new System.Drawing.Size(607, 38);
            this.lbTileName.TabIndex = 362;
            this.lbTileName.Text = "Chi Tiết Hóa Đơn : 0 ";
            this.lbTileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 440);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 10);
            this.panel3.TabIndex = 361;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(617, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 440);
            this.panel4.TabIndex = 360;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 10);
            this.panel2.TabIndex = 359;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 450);
            this.panel1.TabIndex = 358;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.Black;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 344);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(607, 10);
            this.bunifuSeparator1.TabIndex = 365;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // fChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(627, 450);
            this.Controls.Add(this.pnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fChiTietHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fChiTietHoaDon";
            this.Load += new System.EventHandler(this.fChiTietHoaDon_Load);
            this.pnMain.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        internal Bunifu.Framework.UI.BunifuCustomLabel lbTileName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaChiTietHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGiaBan;
        internal Bunifu.Framework.UI.BunifuCustomLabel lblGia;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}