namespace QuanLyKho
{
    partial class FormNhatKyTonKho
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNhatKyTonKho;
        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.ComboBox cmbSanPham;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;

        // Correct Dispose method
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvNhatKyTonKho = new System.Windows.Forms.DataGridView();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.cmbSanPham = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKyTonKho)).BeginInit();
            this.SuspendLayout();

            // dgvNhatKyTonKho
            this.dgvNhatKyTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhatKyTonKho.Location = new System.Drawing.Point(12, 80);
            this.dgvNhatKyTonKho.Name = "dgvNhatKyTonKho";
            this.dgvNhatKyTonKho.Size = new System.Drawing.Size(760, 350);
            this.dgvNhatKyTonKho.TabIndex = 0;

            // cmbDanhMuc
            this.cmbDanhMuc.FormattingEnabled = true;
            this.cmbDanhMuc.Location = new System.Drawing.Point(95, 12);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(200, 21);
            this.cmbDanhMuc.TabIndex = 1;

            // cmbSanPham
            this.cmbSanPham.FormattingEnabled = true;
            this.cmbSanPham.Location = new System.Drawing.Point(95, 40);
            this.cmbSanPham.Name = "cmbSanPham";
            this.cmbSanPham.Size = new System.Drawing.Size(200, 21);
            this.cmbSanPham.TabIndex = 2;

            // dtpFromDate
            this.dtpFromDate.Location = new System.Drawing.Point(380, 12);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 3;

            // dtpToDate
            this.dtpToDate.Location = new System.Drawing.Point(380, 40);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 4;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(600, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);  // Đăng ký sự kiện

            // btnLoc
            this.btnLoc.Location = new System.Drawing.Point(600, 40);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 24);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);  // Đăng ký sự kiện

            // lblDanhMuc
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(20, 15);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(58, 13);
            this.lblDanhMuc.TabIndex = 7;
            this.lblDanhMuc.Text = "Danh mục:";

            // lblSanPham
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Location = new System.Drawing.Point(20, 45);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(61, 13);
            this.lblSanPham.TabIndex = 8;
            this.lblSanPham.Text = "Sản phẩm:";

            // lblFromDate
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(320, 15);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(54, 13);
            this.lblFromDate.TabIndex = 9;
            this.lblFromDate.Text = "Từ ngày:";

            // lblToDate
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(320, 45);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(60, 13);
            this.lblToDate.TabIndex = 10;
            this.lblToDate.Text = "Đến ngày:";

            // FormNhatKyTonKho
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblSanPham);
            this.Controls.Add(this.lblDanhMuc);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbSanPham);
            this.Controls.Add(this.cmbDanhMuc);
            this.Controls.Add(this.dgvNhatKyTonKho);
            this.Name = "FormNhatKyTonKho";
            this.Text = "Nhật Ký Tồn Kho";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKyTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
