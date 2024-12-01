using System;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormDieuKhien : Form
    {
        private string _role;

        public FormDieuKhien(string role)
        {
            InitializeComponent();
            _role = role;

            // Điều chỉnh quyền truy cập dựa trên vai trò
            AdjustPermissions();
        }

        private void AdjustPermissions()
        {
            if (_role == "Quản lý")
            {
                // Nếu là "Quản lý", người dùng có thể truy cập tất cả các form
                btnChinhSuaHangTonKho.Enabled = true;
                btnNhapHangTonKho.Enabled = true;
                btnNhapXuatKho.Enabled = true;
                btnNhatKyTonKho.Enabled = true;
                btnTongQuanTonKho.Enabled = true;
            }
            else
            {
                // Nếu không phải "Quản lý", chỉ được phép truy cập một số form
                btnChinhSuaHangTonKho.Enabled = false;
                btnNhatKyTonKho.Enabled = false;
                btnTongQuanTonKho.Enabled = true;
                btnNhapXuatKho.Enabled = true;
            }
        }

        // Mở các form con trong panel
        private void ShowSubForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelSubForm.Controls.Clear();
            panelSubForm.Controls.Add(form);
            form.Show();
        }

        private void btnChinhSuaHangTonKho_Click(object sender, EventArgs e)
        {
            ShowSubForm(new FormChinhSuaHangTonKho());
        }

        private void btnNhapHangTonKho_Click(object sender, EventArgs e)
        {
            ShowSubForm(new FormNhapHangTonKho());
        }

        private void btnNhapXuatKho_Click(object sender, EventArgs e)
        {
            ShowSubForm(new FormNhapXuatKho());
        }

        private void btnNhatKyTonKho_Click(object sender, EventArgs e)
        {
            ShowSubForm(new FormNhatKyTonKho());
        }

        private void btnTongQuanTonKho_Click(object sender, EventArgs e)
        {
            ShowSubForm(new FormTongQuanTonKho());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormLogin().ShowDialog();
            this.Close();
        }
    }
}
