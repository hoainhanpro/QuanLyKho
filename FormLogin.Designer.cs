namespace QuanLyKho
{
    partial class FormLogin
    {
        private void InitializeComponent()
        {
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignin = new System.Windows.Forms.Button();

            // Form
            this.Text = "Đăng nhập";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Label: User Name
            lblUserName.Text = "User Name:";
            lblUserName.Location = new System.Drawing.Point(30, 50);
            lblUserName.AutoSize = true;

            // TextBox: User Name
            txtUserName.Location = new System.Drawing.Point(150, 45);
            txtUserName.Size = new System.Drawing.Size(200, 25);

            // Label: Password
            lblPassword.Text = "Password:";
            lblPassword.Location = new System.Drawing.Point(30, 100);
            lblPassword.AutoSize = true;

            // TextBox: Password
            txtPassword.Location = new System.Drawing.Point(150, 95);
            txtPassword.Size = new System.Drawing.Size(200, 25);
            txtPassword.PasswordChar = '*'; // Ẩn ký tự khi nhập

            // Button: Sign in
            btnSignin.Text = "Sign in";
            btnSignin.Location = new System.Drawing.Point(150, 150);
            btnSignin.Size = new System.Drawing.Size(100, 35);

            // Add controls to the form
            this.Controls.Add(lblUserName);
            this.Controls.Add(txtUserName);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnSignin);
        }

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignin;
    }
}
