namespace QuanLyKho
{
    partial class FormDieuKhien
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnChinhSuaHangTonKho;
        private Button btnNhapHangTonKho;
        private Button btnNhapXuatKho;
        private Button btnNhatKyTonKho;
        private Button btnTongQuanTonKho;
        private Button btnLogout;
        private Panel panelSubForm; // Panel chứa các subform

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
            this.btnChinhSuaHangTonKho = new System.Windows.Forms.Button();
            this.btnNhapHangTonKho = new System.Windows.Forms.Button();
            this.btnNhapXuatKho = new System.Windows.Forms.Button();
            this.btnNhatKyTonKho = new System.Windows.Forms.Button();
            this.btnTongQuanTonKho = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSubForm = new System.Windows.Forms.Panel(); // Khởi tạo panel chứa subform

            // 
            // btnChinhSuaHangTonKho
            // 
            this.btnChinhSuaHangTonKho.Location = new System.Drawing.Point(50, 50);
            this.btnChinhSuaHangTonKho.Name = "btnChinhSuaHangTonKho";
            this.btnChinhSuaHangTonKho.Size = new System.Drawing.Size(200, 40);
            this.btnChinhSuaHangTonKho.TabIndex = 0;
            this.btnChinhSuaHangTonKho.Text = "Chỉnh Sửa Hàng Tồn Kho";
            this.btnChinhSuaHangTonKho.UseVisualStyleBackColor = true;
            this.btnChinhSuaHangTonKho.Click += new System.EventHandler(this.btnChinhSuaHangTonKho_Click);

            // 
            // btnNhapHangTonKho
            // 
            this.btnNhapHangTonKho.Location = new System.Drawing.Point(50, 100);
            this.btnNhapHangTonKho.Name = "btnNhapHangTonKho";
            this.btnNhapHangTonKho.Size = new System.Drawing.Size(200, 40);
            this.btnNhapHangTonKho.TabIndex = 1;
            this.btnNhapHangTonKho.Text = "Nhập Hàng Tồn Kho";
            this.btnNhapHangTonKho.UseVisualStyleBackColor = true;
            this.btnNhapHangTonKho.Click += new System.EventHandler(this.btnNhapHangTonKho_Click);

            // 
            // btnNhapXuatKho
            // 
            this.btnNhapXuatKho.Location = new System.Drawing.Point(50, 150);
            this.btnNhapXuatKho.Name = "btnNhapXuatKho";
            this.btnNhapXuatKho.Size = new System.Drawing.Size(200, 40);
            this.btnNhapXuatKho.TabIndex = 2;
            this.btnNhapXuatKho.Text = "Nhập Xuất Hàng Tồn Kho";
            this.btnNhapXuatKho.UseVisualStyleBackColor = true;
            this.btnNhapXuatKho.Click += new System.EventHandler(this.btnNhapXuatKho_Click);

            // 
            // btnNhatKyTonKho
            // 
            this.btnNhatKyTonKho.Location = new System.Drawing.Point(50, 200);
            this.btnNhatKyTonKho.Name = "btnNhatKyTonKho";
            this.btnNhatKyTonKho.Size = new System.Drawing.Size(200, 40);
            this.btnNhatKyTonKho.TabIndex = 3;
            this.btnNhatKyTonKho.Text = "Nhật Ký Tồn Kho";
            this.btnNhatKyTonKho.UseVisualStyleBackColor = true;
            this.btnNhatKyTonKho.Click += new System.EventHandler(this.btnNhatKyTonKho_Click);

            // 
            // btnTongQuanTonKho
            // 
            this.btnTongQuanTonKho.Location = new System.Drawing.Point(50, 250);
            this.btnTongQuanTonKho.Name = "btnTongQuanTonKho";
            this.btnTongQuanTonKho.Size = new System.Drawing.Size(200, 40);
            this.btnTongQuanTonKho.TabIndex = 4;
            this.btnTongQuanTonKho.Text = "Tổng Quan Tồn Kho";
            this.btnTongQuanTonKho.UseVisualStyleBackColor = true;
            this.btnTongQuanTonKho.Click += new System.EventHandler(this.btnTongQuanTonKho_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(50, 300);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // panelSubForm
            // 
            this.panelSubForm.Location = new System.Drawing.Point(300, 50);
            this.panelSubForm.Name = "panelSubForm";
            this.panelSubForm.Size = new System.Drawing.Size(800, 670);
            this.panelSubForm.TabIndex = 6; // Đây là panel chứa các form con

            // 
            // FormDieuKhien
            // 
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelSubForm); // Thêm panel vào form
            this.Controls.Add(this.btnChinhSuaHangTonKho);
            this.Controls.Add(this.btnNhapHangTonKho);
            this.Controls.Add(this.btnNhapXuatKho);
            this.Controls.Add(this.btnNhatKyTonKho);
            this.Controls.Add(this.btnTongQuanTonKho);
            this.Controls.Add(this.btnLogout);
            this.Text = "Điều Khiển";
        }
    }
}
