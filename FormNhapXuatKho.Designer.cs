namespace QuanLyKho 
{
    partial class FormNhapXuatKho
    {
        private void InitializeComponent()
        {
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();

            // Form
            this.Text = "Quản lý Nhập Xuất Kho";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // GroupBox
            groupBoxInfo.Text = "Thông tin nhập xuất";
            groupBoxInfo.Location = new System.Drawing.Point(20, 20);
            groupBoxInfo.Size = new System.Drawing.Size(540, 250);

            // Labels
            lblProduct.Text = "Sản phẩm:";
            lblProduct.Location = new System.Drawing.Point(20, 40);
            lblProduct.AutoSize = true;

            lblQuantity.Text = "Số lượng:";
            lblQuantity.Location = new System.Drawing.Point(20, 90);
            lblQuantity.AutoSize = true;

            lblPrice.Text = "Đơn giá:";
            lblPrice.Location = new System.Drawing.Point(20, 140);
            lblPrice.AutoSize = true;

            // ComboBox Products
            cboProducts.Location = new System.Drawing.Point(120, 35);
            cboProducts.Size = new System.Drawing.Size(380, 25);
            cboProducts.DropDownStyle = ComboBoxStyle.DropDownList;

            // TextBoxes
            txtQuantity.Location = new System.Drawing.Point(120, 85);
            txtQuantity.Size = new System.Drawing.Size(150, 25);

            txtPrice.Location = new System.Drawing.Point(120, 135);
            txtPrice.Size = new System.Drawing.Size(150, 25);

            // Buttons
            btnImport.Text = "Nhập kho";
            btnImport.Location = new System.Drawing.Point(120, 190);
            btnImport.Size = new System.Drawing.Size(120, 35);

            btnExport.Text = "Xuất kho";
            btnExport.Location = new System.Drawing.Point(260, 190);
            btnExport.Size = new System.Drawing.Size(120, 35);

            // Add controls to groupBox
            groupBoxInfo.Controls.AddRange(new Control[] {
                lblProduct, lblQuantity, lblPrice,
                cboProducts, txtQuantity, txtPrice,
                btnImport, btnExport
            });

            // Add groupBox to form
            this.Controls.Add(groupBoxInfo);
        }

        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.GroupBox groupBoxInfo;
    }
}
