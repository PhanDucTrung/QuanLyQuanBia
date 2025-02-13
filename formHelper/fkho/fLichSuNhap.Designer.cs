namespace QuanLyQuanBia.formHelper.fkho
{
    partial class fLichSuNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLichSuNhap));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xuấtFileTheoNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lbTileName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnClose = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dtgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xuấtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtFileTheoThứTựSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lsbSanPham = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnAdd = new Bunifu.Framework.UI.BunifuThinButton2();
            this.DateTimeNhap = new MetroFramework.Controls.MetroDateTime();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.txbTenSP = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpathImgg = new System.Windows.Forms.DataGridViewImageColumn();
            this.cMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhapHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xuấtFileTheoNgàyToolStripMenuItem
            // 
            this.xuấtFileTheoNgàyToolStripMenuItem.Name = "xuấtFileTheoNgàyToolStripMenuItem";
            this.xuấtFileTheoNgàyToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.xuấtFileTheoNgàyToolStripMenuItem.Text = "Xuất File theo ngày";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.pnlTop.Controls.Add(this.lbTileName);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.dtgv);
            this.pnlTop.Controls.Add(this.lsbSanPham);
            this.pnlTop.Controls.Add(this.groupBox1);
            this.pnlTop.Controls.Add(this.txbTenSP);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1005, 548);
            this.pnlTop.TabIndex = 8;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // lbTileName
            // 
            this.lbTileName.BackColor = System.Drawing.Color.GhostWhite;
            this.lbTileName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbTileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTileName.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(197)))));
            this.lbTileName.Location = new System.Drawing.Point(0, 0);
            this.lbTileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTileName.Name = "lbTileName";
            this.lbTileName.Size = new System.Drawing.Size(1005, 82);
            this.lbTileName.TabIndex = 128;
            this.lbTileName.Text = "Lịch Sử Nhập Hàng";
            this.lbTileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.ActiveBorderThickness = 1;
            this.btnClose.ActiveCornerRadius = 20;
            this.btnClose.ActiveFillColor = System.Drawing.Color.Maroon;
            this.btnClose.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnClose.ActiveLineColor = System.Drawing.Color.Maroon;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.ButtonText = "Thoát";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.IdleBorderThickness = 1;
            this.btnClose.IdleCornerRadius = 20;
            this.btnClose.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnClose.IdleForecolor = System.Drawing.Color.Maroon;
            this.btnClose.IdleLineColor = System.Drawing.Color.Maroon;
            this.btnClose.Location = new System.Drawing.Point(780, 111);
            this.btnClose.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 59);
            this.btnClose.TabIndex = 127;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.cpathImgg,
            this.cMaSanPham,
            this.TenSanPham,
            this.SoLuongNhap,
            this.GiaNhap,
            this.NgayNhapHang});
            this.dtgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dtgv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgv.DoubleBuffered = true;
            this.dtgv.EnableHeadersVisualStyles = false;
            this.dtgv.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgv.Location = new System.Drawing.Point(0, 204);
            this.dtgv.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.RowHeadersWidth = 51;
            this.dtgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgv.RowTemplate.Height = 60;
            this.dtgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv.Size = new System.Drawing.Size(1005, 344);
            this.dtgv.TabIndex = 9;
            this.dtgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuấtFileToolStripMenuItem,
            this.xuấtFileTheoThứTựSelectToolStripMenuItem,
            this.xuấtFileTheoNgàyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(256, 76);
            // 
            // xuấtFileToolStripMenuItem
            // 
            this.xuấtFileToolStripMenuItem.Name = "xuấtFileToolStripMenuItem";
            this.xuấtFileToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.xuấtFileToolStripMenuItem.Text = "Xuất File theo HSD";
            // 
            // xuấtFileTheoThứTựSelectToolStripMenuItem
            // 
            this.xuấtFileTheoThứTựSelectToolStripMenuItem.Name = "xuấtFileTheoThứTựSelectToolStripMenuItem";
            this.xuấtFileTheoThứTựSelectToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.xuấtFileTheoThứTựSelectToolStripMenuItem.Text = "Xuất File theo thứ tự select";
            // 
            // lsbSanPham
            // 
            this.lsbSanPham.FormattingEnabled = true;
            this.lsbSanPham.ItemHeight = 16;
            this.lsbSanPham.Location = new System.Drawing.Point(46, 145);
            this.lsbSanPham.Name = "lsbSanPham";
            this.lsbSanPham.Size = new System.Drawing.Size(173, 52);
            this.lsbSanPham.TabIndex = 126;
            this.lsbSanPham.Visible = false;
            this.lsbSanPham.SelectedIndexChanged += new System.EventHandler(this.lsbSanPham_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bunifuCustomLabel3);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.DateTimeNhap);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel1);
            this.groupBox1.Controls.Add(this.metroDateTime1);
            this.groupBox1.Location = new System.Drawing.Point(227, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 100);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Theo Ngày";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(30, 31);
            this.bunifuCustomLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(70, 19);
            this.bunifuCustomLabel3.TabIndex = 95;
            this.bunifuCustomLabel3.Text = "Từ Ngày ";
            // 
            // btnAdd
            // 
            this.btnAdd.ActiveBorderThickness = 1;
            this.btnAdd.ActiveCornerRadius = 20;
            this.btnAdd.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnAdd.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.ButtonText = "Tìm";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.IdleBorderThickness = 1;
            this.btnAdd.IdleCornerRadius = 20;
            this.btnAdd.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnAdd.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAdd.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.Location = new System.Drawing.Point(372, 41);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 54);
            this.btnAdd.TabIndex = 97;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DateTimeNhap
            // 
            this.DateTimeNhap.CustomFormat = "dd/MM/yyyy";
            this.DateTimeNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeNhap.Location = new System.Drawing.Point(38, 53);
            this.DateTimeNhap.Margin = new System.Windows.Forms.Padding(4);
            this.DateTimeNhap.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeNhap.Name = "DateTimeNhap";
            this.DateTimeNhap.Size = new System.Drawing.Size(127, 30);
            this.DateTimeNhap.TabIndex = 94;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(201, 31);
            this.bunifuCustomLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(76, 19);
            this.bunifuCustomLabel1.TabIndex = 95;
            this.bunifuCustomLabel1.Text = "Đến Ngày";
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.CustomFormat = "dd/MM/yyyy";
            this.metroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.metroDateTime1.Location = new System.Drawing.Point(209, 53);
            this.metroDateTime1.Margin = new System.Windows.Forms.Padding(4);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(108, 30);
            this.metroDateTime1.TabIndex = 94;
            // 
            // txbTenSP
            // 
            this.txbTenSP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbTenSP.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbTenSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbTenSP.HintForeColor = System.Drawing.Color.Empty;
            this.txbTenSP.HintText = "lọc theo Sản Phẩm";
            this.txbTenSP.isPassword = false;
            this.txbTenSP.LineFocusedColor = System.Drawing.Color.Blue;
            this.txbTenSP.LineIdleColor = System.Drawing.Color.Gray;
            this.txbTenSP.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txbTenSP.LineThickness = 3;
            this.txbTenSP.Location = new System.Drawing.Point(46, 87);
            this.txbTenSP.Margin = new System.Windows.Forms.Padding(5);
            this.txbTenSP.Name = "txbTenSP";
            this.txbTenSP.Size = new System.Drawing.Size(173, 54);
            this.txbTenSP.TabIndex = 85;
            this.txbTenSP.Text = "Lọc theo sản phẩm";
            this.txbTenSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbTenSP.OnValueChanged += new System.EventHandler(this.txbTenSP_OnValueChanged);
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.MinimumWidth = 6;
            this.cSTT.Name = "cSTT";
            this.cSTT.Width = 35;
            // 
            // cpathImgg
            // 
            this.cpathImgg.DataPropertyName = "PathImgg";
            this.cpathImgg.HeaderText = "Img_SP";
            this.cpathImgg.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cpathImgg.MinimumWidth = 6;
            this.cpathImgg.Name = "cpathImgg";
            this.cpathImgg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cpathImgg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cpathImgg.Width = 125;
            // 
            // cMaSanPham
            // 
            this.cMaSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cMaSanPham.DataPropertyName = "MaSanPham";
            this.cMaSanPham.HeaderText = "MãSP";
            this.cMaSanPham.MinimumWidth = 6;
            this.cMaSanPham.Name = "cMaSanPham";
            this.cMaSanPham.Visible = false;
            this.cMaSanPham.Width = 60;
            // 
            // TenSanPham
            // 
            this.TenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên Sản Phẩm ";
            this.TenSanPham.MinimumWidth = 6;
            this.TenSanPham.Name = "TenSanPham";
            // 
            // SoLuongNhap
            // 
            this.SoLuongNhap.DataPropertyName = "SoLuongNhap";
            this.SoLuongNhap.HeaderText = "Số Lượng Nhập";
            this.SoLuongNhap.MinimumWidth = 6;
            this.SoLuongNhap.Name = "SoLuongNhap";
            this.SoLuongNhap.Width = 125;
            // 
            // GiaNhap
            // 
            this.GiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GiaNhap.DataPropertyName = "GiaNhap";
            this.GiaNhap.HeaderText = "Giá Nhập Hàng";
            this.GiaNhap.MinimumWidth = 6;
            this.GiaNhap.Name = "GiaNhap";
            // 
            // NgayNhapHang
            // 
            this.NgayNhapHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayNhapHang.DataPropertyName = "NgayNhapHang";
            this.NgayNhapHang.HeaderText = "Ngày Nhập Hàng";
            this.NgayNhapHang.MinimumWidth = 6;
            this.NgayNhapHang.Name = "NgayNhapHang";
            // 
            // fLichSuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 548);
            this.Controls.Add(this.pnlTop);
            this.Name = "fLichSuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fLichSuNhap";
            this.Load += new System.EventHandler(this.fLichSuNhap_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem xuấtFileTheoNgàyToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStripMenuItem xuấtFileTheoThứTựSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtFileToolStripMenuItem;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txbTenSP;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private MetroFramework.Controls.MetroDateTime DateTimeNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAdd;
        private System.Windows.Forms.ListBox lsbSanPham;
        private Bunifu.Framework.UI.BunifuThinButton2 btnClose;
        internal Bunifu.Framework.UI.BunifuCustomLabel lbTileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewImageColumn cpathImgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhapHang;
    }
}