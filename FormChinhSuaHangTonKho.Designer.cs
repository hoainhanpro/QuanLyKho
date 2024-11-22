namespace QuanLyKho
{
    partial class FormChinhSuaHangTonKho
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox groupBoxProductDetails;
        private System.Windows.Forms.Label lblMaSanPham;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.Label lblKichThuoc;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.Label lblIdList;
        private System.Windows.Forms.ComboBox cmbMaSanPham;
        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.TextBox txtKichThuoc;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.ComboBox cmbIdList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.groupBoxProductDetails = new System.Windows.Forms.GroupBox();
            this.lblMaSanPham = new System.Windows.Forms.Label();
            this.cmbMaSanPham = new System.Windows.Forms.ComboBox();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.txtKichThuoc = new System.Windows.Forms.TextBox();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.lblIdList = new System.Windows.Forms.Label();
            this.cmbIdList = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();

            // groupBoxProductDetails
            this.groupBoxProductDetails.Controls.Add(this.lblMaSanPham);
            this.groupBoxProductDetails.Controls.Add(this.cmbMaSanPham);
            this.groupBoxProductDetails.Controls.Add(this.lblTenSanPham);
            this.groupBoxProductDetails.Controls.Add(this.txtTenSanPham);
            this.groupBoxProductDetails.Controls.Add(this.lblDanhMuc);
            this.groupBoxProductDetails.Controls.Add(this.cmbDanhMuc);
            this.groupBoxProductDetails.Controls.Add(this.lblSoLuong);
            this.groupBoxProductDetails.Controls.Add(this.numSoLuong);
            this.groupBoxProductDetails.Controls.Add(this.lblMauSac);
            this.groupBoxProductDetails.Controls.Add(this.txtMauSac);
            this.groupBoxProductDetails.Controls.Add(this.lblKichThuoc);
            this.groupBoxProductDetails.Controls.Add(this.txtKichThuoc);
            this.groupBoxProductDetails.Controls.Add(this.lblCurrentPrice);
            this.groupBoxProductDetails.Controls.Add(this.txtCurrentPrice);
            this.groupBoxProductDetails.Controls.Add(this.lblIdList);
            this.groupBoxProductDetails.Controls.Add(this.cmbIdList);
            this.groupBoxProductDetails.Location = new System.Drawing.Point(20, 20);
            this.groupBoxProductDetails.Name = "groupBoxProductDetails";
            this.groupBoxProductDetails.Size = new System.Drawing.Size(400, 350);
            this.groupBoxProductDetails.TabIndex = 0;
            this.groupBoxProductDetails.TabStop = false;

            // lblMaSanPham
            this.lblMaSanPham.AutoSize = true;
            this.lblMaSanPham.Location = new System.Drawing.Point(20, 30);
            this.lblMaSanPham.Name = "lblMaSanPham";
            this.lblMaSanPham.Size = new System.Drawing.Size(92, 17);
            this.lblMaSanPham.Text = "Mã sản phẩm";

            // cmbMaSanPham
            this.cmbMaSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaSanPham.Location = new System.Drawing.Point(150, 30);
            this.cmbMaSanPham.Name = "cmbMaSanPham";
            this.cmbMaSanPham.Size = new System.Drawing.Size(200, 24);

            // lblTenSanPham
            this.lblTenSanPham.AutoSize = true;
            this.lblTenSanPham.Location = new System.Drawing.Point(20, 70);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(98, 17);
            this.lblTenSanPham.Text = "Tên sản phẩm";

            // txtTenSanPham
            this.txtTenSanPham.Location = new System.Drawing.Point(150, 70);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(200, 22);

            // lblDanhMuc
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(20, 110);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(69, 17);
            this.lblDanhMuc.Text = "Danh mục";

            // cmbDanhMuc
            this.cmbDanhMuc.Location = new System.Drawing.Point(150, 110);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(200, 24);
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblSoLuong
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 150);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(65, 17);
            this.lblSoLuong.Text = "Số lượng";

            // numSoLuong
            this.numSoLuong.Location = new System.Drawing.Point(150, 150);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(200, 22);

            // lblMauSac
            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Location = new System.Drawing.Point(20, 190);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(61, 17);
            this.lblMauSac.Text = "Màu sắc";

            // txtMauSac
            this.txtMauSac.Location = new System.Drawing.Point(150, 190);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(200, 22);

            // lblKichThuoc
            this.lblKichThuoc.AutoSize = true;
            this.lblKichThuoc.Location = new System.Drawing.Point(20, 230);
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.Size = new System.Drawing.Size(73, 17);
            this.lblKichThuoc.Text = "Kích thước";

            // txtKichThuoc
            this.txtKichThuoc.Location = new System.Drawing.Point(150, 230);
            this.txtKichThuoc.Name = "txtKichThuoc";
            this.txtKichThuoc.Size = new System.Drawing.Size(200, 22);

            // lblCurrentPrice
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Location = new System.Drawing.Point(20, 270);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(98, 17);
            this.lblCurrentPrice.Text = "Giá hiện tại";

            // txtCurrentPrice
            this.txtCurrentPrice.Location = new System.Drawing.Point(150, 270);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.Size = new System.Drawing.Size(200, 22);

            // lblIdList
            this.lblIdList.AutoSize = true;
            this.lblIdList.Location = new System.Drawing.Point(20, 310);
            this.lblIdList.Name = "lblIdList";
            this.lblIdList.Size = new System.Drawing.Size(50, 17);
            this.lblIdList.Text = "ID List";

            // cmbIdList
            this.cmbIdList.Location = new System.Drawing.Point(150, 310);
            this.cmbIdList.Name = "cmbIdList";
            this.cmbIdList.Size = new System.Drawing.Size(200, 24);
            this.cmbIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(100, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(220, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FormChinhSuaHangTonKho
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.groupBoxProductDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormChinhSuaHangTonKho";
            this.Text = "Chỉnh sửa hàng tồn kho";
            this.Load += new System.EventHandler(this.FormChinhSuaHangTonKho_Load);
            this.groupBoxProductDetails.ResumeLayout(false);
            this.groupBoxProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
