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

        public FormTongQuanTonKho()
        {
            InitializeComponent();
            _connection = new SqlConnection("Server=26.26.244.217,1344;Database=Assigment;User ID=sa;Password=sa");
            
            dataGridView.DataSource = _bindingSource;
            
            LoadInventoryData();
        }

        public void RefreshData()
        {
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
                dataGridView.Columns["CATEGORYID"].HeaderText = "Mã Loại";
                dataGridView.Columns["PRODUCTNAME"].HeaderText = "Tên Sản Phẩm";
                dataGridView.Columns["QUANTITY"].HeaderText = "Số Lượng";
                dataGridView.Columns["COLOR"].HeaderText = "Màu Sắc";
                dataGridView.Columns["SIZE"].HeaderText = "Kích Thước";
                dataGridView.Columns["CURRENTPRICE"].HeaderText = "Giá Hiện Tại";
                dataGridView.Columns["IDLIST"].HeaderText = "ID List";
                
                // Ẩn cột version nếu có
                if (dataGridView.Columns.Contains("RowVersionColumn"))
                    dataGridView.Columns["RowVersionColumn"].Visible = false;
                
                // Định dạng cột giá
                dataGridView.Columns["CURRENTPRICE"].DefaultCellStyle.Format = "N0";

                //Add CellFormatting event
                dataGridView.CellFormatting += DataGridView_CellFormatting;
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if this is the CATEGORYID column
            if (dataGridView.Columns[e.ColumnIndex].Name == "CATEGORYID" && e.Value != null)
            {
                // Convert category ID to text
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "Quần";
                        break;
                    case "2":
                        e.Value = "Áo";
                        break;
                }
                e.FormattingApplied = true;
            }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _connection.Dispose();
            base.OnFormClosing(e);
        }
    }
}