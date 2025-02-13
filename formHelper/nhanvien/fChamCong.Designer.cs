namespace QuanLyQuanBia.formHelper.nhanvien
{
    partial class fChamCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChamCong));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienBanDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienDuTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienThucTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.DateTimeStart = new MetroFramework.Controls.MetroDateTime();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cbbTypeNhanVien = new MetroFramework.Controls.MetroComboBox();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnXuatFileExcel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.DateTimeStop = new MetroFramework.Controls.MetroDateTime();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgv);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 643);
            this.panel1.TabIndex = 0;
            // 
            // dtgv
            // 
            this.dtgv.AllowUserToAddRows = false;
            this.dtgv.AllowUserToDeleteRows = false;
            this.dtgv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
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
            this.HoTen,
            this.GioBatDau,
            this.GioKetThuc,
            this.SoTienBanDau,
            this.SoTienDuTinh,
            this.SoTienThucTe,
            this.ThoiGianLamViec,
            this.NgaySinh});
            this.dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv.DoubleBuffered = true;
            this.dtgv.EnableHeadersVisualStyles = false;
            this.dtgv.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.dtgv.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgv.Location = new System.Drawing.Point(0, 100);
            this.dtgv.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.RowHeadersWidth = 51;
            this.dtgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv.Size = new System.Drawing.Size(1274, 543);
            this.dtgv.TabIndex = 11;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.MinimumWidth = 6;
            this.cSTT.Name = "cSTT";
            this.cSTT.Width = 35;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Tên Nhân Viên ";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 125;
            // 
            // GioBatDau
            // 
            this.GioBatDau.DataPropertyName = "GioBatDau";
            this.GioBatDau.HeaderText = "Bắt Đầu ";
            this.GioBatDau.MinimumWidth = 6;
            this.GioBatDau.Name = "GioBatDau";
            this.GioBatDau.Width = 125;
            // 
            // GioKetThuc
            // 
            this.GioKetThuc.DataPropertyName = "GioKetThuc";
            this.GioKetThuc.HeaderText = "Kết Thúc";
            this.GioKetThuc.MinimumWidth = 6;
            this.GioKetThuc.Name = "GioKetThuc";
            this.GioKetThuc.Width = 125;
            // 
            // SoTienBanDau
            // 
            this.SoTienBanDau.DataPropertyName = "SoTienBanDau";
            this.SoTienBanDau.HeaderText = "Tiền Ban Đầu";
            this.SoTienBanDau.MinimumWidth = 6;
            this.SoTienBanDau.Name = "SoTienBanDau";
            this.SoTienBanDau.Width = 125;
            // 
            // SoTienDuTinh
            // 
            this.SoTienDuTinh.DataPropertyName = "SoTienDuTinh";
            this.SoTienDuTinh.HeaderText = "Dự Tính Thu";
            this.SoTienDuTinh.MinimumWidth = 6;
            this.SoTienDuTinh.Name = "SoTienDuTinh";
            this.SoTienDuTinh.Width = 125;
            // 
            // SoTienThucTe
            // 
            this.SoTienThucTe.DataPropertyName = "SoTienThucTe";
            this.SoTienThucTe.HeaderText = "Thức Tế Thu";
            this.SoTienThucTe.MinimumWidth = 6;
            this.SoTienThucTe.Name = "SoTienThucTe";
            this.SoTienThucTe.Width = 125;
            // 
            // ThoiGianLamViec
            // 
            this.ThoiGianLamViec.DataPropertyName = "ThoiGianLamViec";
            this.ThoiGianLamViec.HeaderText = "Số Giờ Làm ";
            this.ThoiGianLamViec.MinimumWidth = 6;
            this.ThoiGianLamViec.Name = "ThoiGianLamViec";
            this.ThoiGianLamViec.Width = 125;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Sinh Nhật";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuCustomLabel3);
            this.panel2.Controls.Add(this.DateTimeStart);
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Controls.Add(this.bunifuCustomLabel1);
            this.panel2.Controls.Add(this.cbbTypeNhanVien);
            this.panel2.Controls.Add(this.bunifuThinButton22);
            this.panel2.Controls.Add(this.bunifuThinButton21);
            this.panel2.Controls.Add(this.btnXuatFileExcel);
            this.panel2.Controls.Add(this.DateTimeStop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1274, 100);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(559, 26);
            this.bunifuCustomLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(71, 19);
            this.bunifuCustomLabel3.TabIndex = 112;
            this.bunifuCustomLabel3.Text = "Từ ngày :";
            // 
            // DateTimeStart
            // 
            this.DateTimeStart.CustomFormat = "dd/MM/yyyy";
            this.DateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeStart.Location = new System.Drawing.Point(551, 48);
            this.DateTimeStart.Margin = new System.Windows.Forms.Padding(4);
            this.DateTimeStart.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeStart.Name = "DateTimeStart";
            this.DateTimeStart.Size = new System.Drawing.Size(141, 30);
            this.DateTimeStart.TabIndex = 111;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(709, 26);
            this.bunifuCustomLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(81, 19);
            this.bunifuCustomLabel2.TabIndex = 110;
            this.bunifuCustomLabel2.Text = "Đến ngày :";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(317, 26);
            this.bunifuCustomLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(110, 19);
            this.bunifuCustomLabel1.TabIndex = 109;
            this.bunifuCustomLabel1.Text = "Tên Nhân viên:";
            // 
            // cbbTypeNhanVien
            // 
            this.cbbTypeNhanVien.FormattingEnabled = true;
            this.cbbTypeNhanVien.ItemHeight = 24;
            this.cbbTypeNhanVien.Location = new System.Drawing.Point(321, 48);
            this.cbbTypeNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTypeNhanVien.Name = "cbbTypeNhanVien";
            this.cbbTypeNhanVien.Size = new System.Drawing.Size(156, 30);
            this.cbbTypeNhanVien.TabIndex = 108;
            this.cbbTypeNhanVien.UseSelectable = true;
            this.cbbTypeNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbbTypeNhanVien_SelectedIndexChanged);
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.Color.Transparent;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.ButtonText = "Tìm";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton22.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.Location = new System.Drawing.Point(887, 26);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(117, 54);
            this.bunifuThinButton22.TabIndex = 107;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton22.Click += new System.EventHandler(this.bunifuThinButton22_Click);
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "Hiện Tất Cả";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.Location = new System.Drawing.Point(36, 26);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(133, 54);
            this.bunifuThinButton21.TabIndex = 107;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // btnXuatFileExcel
            // 
            this.btnXuatFileExcel.ActiveBorderThickness = 1;
            this.btnXuatFileExcel.ActiveCornerRadius = 20;
            this.btnXuatFileExcel.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnXuatFileExcel.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnXuatFileExcel.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnXuatFileExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnXuatFileExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXuatFileExcel.BackgroundImage")));
            this.btnXuatFileExcel.ButtonText = "Xuất File Excel";
            this.btnXuatFileExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatFileExcel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFileExcel.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnXuatFileExcel.IdleBorderThickness = 1;
            this.btnXuatFileExcel.IdleCornerRadius = 20;
            this.btnXuatFileExcel.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnXuatFileExcel.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnXuatFileExcel.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnXuatFileExcel.Location = new System.Drawing.Point(1075, 26);
            this.btnXuatFileExcel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnXuatFileExcel.Name = "btnXuatFileExcel";
            this.btnXuatFileExcel.Size = new System.Drawing.Size(192, 54);
            this.btnXuatFileExcel.TabIndex = 107;
            this.btnXuatFileExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXuatFileExcel.Click += new System.EventHandler(this.btnXuatFileExcel_Click);
            // 
            // DateTimeStop
            // 
            this.DateTimeStop.CustomFormat = "dd/MM/yyyy";
            this.DateTimeStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeStop.Location = new System.Drawing.Point(713, 48);
            this.DateTimeStop.Margin = new System.Windows.Forms.Padding(4);
            this.DateTimeStop.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeStop.Name = "DateTimeStop";
            this.DateTimeStop.Size = new System.Drawing.Size(140, 30);
            this.DateTimeStop.TabIndex = 106;
            // 
            // fChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 643);
            this.Controls.Add(this.panel1);
            this.Name = "fChamCong";
            this.Text = "fChamCong";
            this.Load += new System.EventHandler(this.fChamCong_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgv;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private MetroFramework.Controls.MetroDateTime DateTimeStart;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private MetroFramework.Controls.MetroComboBox cbbTypeNhanVien;
        private Bunifu.Framework.UI.BunifuThinButton2 btnXuatFileExcel;
        private MetroFramework.Controls.MetroDateTime DateTimeStop;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienBanDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienDuTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienThucTe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
    }
}