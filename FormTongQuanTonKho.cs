using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormTongQuanTonKho : Form
    {
        private readonly SqlConnection _connection;
        private readonly BindingSource _bindingSource = new BindingSource();
        private System.Windows.Forms.Timer _refreshTimer;

        public FormTongQuanTonKho()
        {
            InitializeComponent();
            _connection = new SqlConnection("Server=26.26.244.217,1344;Database=Assigment;User ID=sa;Password=sa");
            
            dataGridView.DataSource = _bindingSource;
            
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1000; // Làm mới mỗi 10 giây
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Start();

            LoadInventoryData();
        }

        private async void LoadInventoryData()
        {
            try
            {
                using var cmd = new SqlCommand("sp_GetClothes", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                
                if (_connection.State != ConnectionState.Open)
                    await _connection.OpenAsync();

                adapter.Fill(table);
                _bindingSource.DataSource = table;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
            finally 
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns["ID"].HeaderText = "Mã SP";
                dataGridView.Columns["PRODUCTNAME"].HeaderText = "Tên Sản Phẩm";
                dataGridView.Columns["QUANTITY"].HeaderText = "Số Lượng";
                dataGridView.Columns["CURRENTPRICE"].HeaderText = "Giá Hiện Tại";
                
                // Ẩn cột version nếu có
                if (dataGridView.Columns.Contains("RowVersionColumn"))
                    dataGridView.Columns["RowVersionColumn"].Visible = false;
                
                // Định dạng cột giá
                dataGridView.Columns["CURRENTPRICE"].DefaultCellStyle.Format = "N0";
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _refreshTimer.Stop();
            _connection.Dispose();
            base.OnFormClosing(e);
        }
    }
}