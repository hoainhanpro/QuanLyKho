namespace QuanLyKho
{
    public partial class FormTongQuanTonKho : System.Windows.Forms.Form
    {
        protected System.Windows.Forms.DataGridView dataGridView;
        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Panel panelTop;
        protected System.Windows.Forms.Panel panelMain;
        protected System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.Label lblSearch;

        protected void InitializeComponent()
        {
            // Khởi tạo các controls
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();

            // Panel Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 80;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 66, 91);
            this.panelTop.Controls.Add(this.lblTitle);


            // Label Title
            this.lblTitle.Text = "TỔNG QUAN TỒN KHO";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;

            // Panel Main
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Controls.Add(this.dataGridView);

            // DataGridView
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 239, 249);
            this.dataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(72, 123, 237);
            this.dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Form
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Text = "Tổng Quan Tồn Kho";
            this.Size = new System.Drawing.Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(800, 500);
        }
    }
} 