namespace QuanLyKho
{
    partial class FormNhapHangTonKho
    {
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.Label lblKichThuoc;
        private System.Windows.Forms.Label lblCurrentPrice;

        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.TextBox txtKichThuoc;
        private System.Windows.Forms.TextBox txtCurrentPrice;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.lblCurrentPrice = new System.Windows.Forms.Label();

            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.txtKichThuoc = new System.Windows.Forms.TextBox();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();

            // Form properties
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
            this.ClientSize = new System.Drawing.Size(500, 450); 
            this.Text = "Nhập Hàng Tồn Kho";

            // lblDanhMuc
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(50, 50);
            this.lblDanhMuc.Size = new System.Drawing.Size(70, 17);
            this.lblDanhMuc.Text = "Danh mục";

            // lblTenSanPham
            this.lblTenSanPham.AutoSize = true;
            this.lblTenSanPham.Location = new System.Drawing.Point(50, 100);
            this.lblTenSanPham.Size = new System.Drawing.Size(100, 17);
            this.lblTenSanPham.Text = "Tên sản phẩm";

            // lblCurrentPrice
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Location = new System.Drawing.Point(50, 150);
            this.lblCurrentPrice.Size = new System.Drawing.Size(80, 17);
            this.lblCurrentPrice.Text = "Giá hiện tại";

            // lblSoLuong
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(50, 200);
            this.lblSoLuong.Size = new System.Drawing.Size(70, 17);
            this.lblSoLuong.Text = "Số lượng";

            // lblMauSac
            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Location = new System.Drawing.Point(50, 250);
            this.lblMauSac.Size = new System.Drawing.Size(60, 17);
            this.lblMauSac.Text = "Màu sắc";

            // lblKichThuoc
            this.lblKichThuoc.AutoSize = true;
            this.lblKichThuoc.Location = new System.Drawing.Point(50, 300);
            this.lblKichThuoc.Size = new System.Drawing.Size(75, 17);
            this.lblKichThuoc.Text = "Kích thước";

            this.cmbDanhMuc.Location = new System.Drawing.Point(180, 50);
            this.cmbDanhMuc.Size = new System.Drawing.Size(250, 24);
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // txtTenSanPham
            this.txtTenSanPham.Location = new System.Drawing.Point(180, 100);
            this.txtTenSanPham.Size = new System.Drawing.Size(250, 24);

            // txtCurrentPrice
            this.txtCurrentPrice.Location = new System.Drawing.Point(180, 150);
            this.txtCurrentPrice.Size = new System.Drawing.Size(250, 24);

            // numSoLuong
            this.numSoLuong.Location = new System.Drawing.Point(180, 200);
            this.numSoLuong.Size = new System.Drawing.Size(250, 24);

            // txtMauSac
            this.txtMauSac.Location = new System.Drawing.Point(180, 250);
            this.txtMauSac.Size = new System.Drawing.Size(250, 24);

            // txtKichThuoc
            this.txtKichThuoc.Location = new System.Drawing.Point(180, 300);
            this.txtKichThuoc.Size = new System.Drawing.Size(250, 24);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(130, 350);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(260, 350);
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Thêm controls vào form
            this.Controls.Add(this.lblDanhMuc);
            this.Controls.Add(this.cmbDanhMuc);
            this.Controls.Add(this.lblTenSanPham);
            this.Controls.Add(this.txtTenSanPham);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.txtCurrentPrice);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.lblMauSac);
            this.Controls.Add(this.txtMauSac);
            this.Controls.Add(this.lblKichThuoc);
            this.Controls.Add(this.txtKichThuoc);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
