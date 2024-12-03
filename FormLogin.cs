using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormLogin : Form
    {
        private readonly SqlConnection _connection;

        public FormLogin()
        {
            InitializeComponent();
            _connection = new SqlConnection("Server=26.26.244.217,1434;Database=Assigment;User ID=HTKN;Password=123456;");

            // Đăng ký sự kiện nút Sign in
            btnSignin.Click += btnSignin_Click;
        }

        private async void btnSignin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string hashedPassword = HashPassword(password);
                // Kiểm tra thông tin đăng nhập
                string role = await AuthenticateUser(username, hashedPassword);
                if (role == null)
                {
                    MessageBox.Show("Sai thông tin đăng nhập. Vui lòng thử lại.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Chuyển tới FormDieuKhien và truyền role
                    FormDieuKhien formDieuKhien = new FormDieuKhien(role);
                    this.Hide();
                    formDieuKhien.ShowDialog();
                    this.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<string> AuthenticateUser(string username, string password)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    await _connection.OpenAsync();

                using var cmd = new SqlCommand("SELECT ROLE FROM ACCOUNT WHERE USERNAME = @Username AND PASSWORD = @Password", _connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // Giả sử mật khẩu đã băm (hash) và khớp

                var role = await cmd.ExecuteScalarAsync();

                return role?.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra thông tin tài khoản: {ex.Message}");
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    await _connection.CloseAsync();
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
