using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKho
{
    public partial class FormNhatKyTonKho : Form
    {
        private string connectionString = "Server=26.26.244.217,1344;Database=Assigment;User Id=HTKN;Password=123456;"; 

        public FormNhatKyTonKho()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lấy danh mục từ bảng CATEGORY
                    string categoryQuery = "SELECT DISTINCT CATEGORYNAME, CATEGORYID FROM [Assigment].[dbo].[CATEGORY]";
                    SqlDataAdapter categoryAdapter = new SqlDataAdapter(categoryQuery, conn);
                    DataTable categoryTable = new DataTable();
                    categoryAdapter.Fill(categoryTable);
                    // Thêm dòng "ALL" vào danh sách Danh mục
                    DataRow allCategoryRow = categoryTable.NewRow();
                    allCategoryRow["CATEGORYNAME"] = "Tất cả";
                    allCategoryRow["CATEGORYID"] = DBNull.Value; // Giá trị NULL cho "ALL"
                    categoryTable.Rows.InsertAt(allCategoryRow, 0);

                    cmbDanhMuc.DataSource = categoryTable;
                    cmbDanhMuc.DisplayMember = "CATEGORYNAME";  // Hiển thị tên danh mục
                    cmbDanhMuc.ValueMember = "CATEGORYID";     // Giá trị là CATEGORYID

                    if (categoryTable.Rows.Count > 0)
                    {
                        cmbDanhMuc.SelectedIndex = 0;  // Chọn giá trị mặc định nếu có dữ liệu
                    }
                    else
                    {
                        cmbDanhMuc.Enabled = false;  // Nếu không có danh mục, tắt ComboBox
                    }

                    // Lấy sản phẩm từ bảng CLOTHES theo CATEGORYID đã chọn
                    string productQuery = @"
                        SELECT 
                            C.ID, 
                            C.PRODUCTNAME 
                        FROM 
                            CLOTHES C 
                        INNER JOIN 
                            CATEGORY CA ON C.CATEGORYID = CA.CATEGORYID";

                    SqlDataAdapter productAdapter = new SqlDataAdapter(productQuery, conn);
                    DataTable productTable = new DataTable();
                    productAdapter.Fill(productTable);

                    // Thêm dòng "ALL" vào danh sách Sản phẩm
                    DataRow allProductRow = productTable.NewRow();
                    allProductRow["PRODUCTNAME"] = "Tất cả";
                    allProductRow["ID"] = DBNull.Value; // Giá trị NULL cho "ALL"
                    productTable.Rows.InsertAt(allProductRow, 0);

                    cmbSanPham.DataSource = productTable;
                    cmbSanPham.DisplayMember = "PRODUCTNAME";  // Hiển thị tên sản phẩm
                    cmbSanPham.ValueMember = "ID";             // Giá trị là ID của sản phẩm

                    // Lấy dữ liệu mặc định cho DataGridView từ INVENTORYLOG kết hợp với CLOTHES
                    string inventoryQuery = @"
                        SELECT 
                            IL.PRODUCTID, 
                            IL.IEDATE, 
                            IL.IOE, 
                            IL.QUANTITY, 
                            IL.PRICE, 
                            C.PRODUCTNAME 
                        FROM 
                            INVENTORYLOG IL 
                        INNER JOIN 
                            CLOTHES C ON IL.PRODUCTID = C.ID";

                    SqlDataAdapter inventoryAdapter = new SqlDataAdapter(inventoryQuery, conn);
                    DataTable inventoryTable = new DataTable();
                    inventoryAdapter.Fill(inventoryTable);

                    // Xử lý dữ liệu cho DataGridView
                    DataTable processedTable = InitializeDataTable(inventoryTable);
                    dgvNhatKyTonKho.DataSource = processedTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable InitializeDataTable(DataTable dataTable)
        {
            DataTable processedTable = new DataTable();
            processedTable.Columns.Add("STT", typeof(int));
            processedTable.Columns.Add("MaSanPham", typeof(string));
            processedTable.Columns.Add("TenSanPham", typeof(string));
            processedTable.Columns.Add("SoLuong", typeof(int));
            processedTable.Columns.Add("Ngay", typeof(DateTime));
            processedTable.Columns.Add("HinhThuc", typeof(string));  // Cột Hình thức
            processedTable.Columns.Add("Tien", typeof(decimal)); // Cột Tiền cho giá trị PRICE

            foreach (DataRow row in dataTable.Rows)
            {
                int rowIndex = processedTable.Rows.Count + 1;

                // Lấy giá trị IOE và xác định Hình thức
                string hinhThuc = (row["IOE"] != DBNull.Value && (bool)row["IOE"]) ? "Nhập" : "Xuất";

                processedTable.Rows.Add(rowIndex, row["PRODUCTID"], row["PRODUCTNAME"], row["QUANTITY"], row["IEDATE"], hinhThuc, row["PRICE"]);
            }

            // Đặt thuộc tính ReadOnly cho DataGridView
            dgvNhatKyTonKho.DataSource = processedTable;

            // Đảm bảo tất cả các cột đều là ReadOnly
            foreach (DataGridViewColumn column in dgvNhatKyTonKho.Columns)
            {
                column.ReadOnly = true;
            }

            // Điều chỉnh độ rộng cột thủ công
            dgvNhatKyTonKho.Columns["STT"].Width = 40;
            dgvNhatKyTonKho.Columns["MaSanPham"].Width = 120;
            dgvNhatKyTonKho.Columns["TenSanPham"].Width = 120;
            dgvNhatKyTonKho.Columns["SoLuong"].Width = 90;
            dgvNhatKyTonKho.Columns["Ngay"].Width = 120;
            dgvNhatKyTonKho.Columns["HinhThuc"].Width = 90;
            dgvNhatKyTonKho.Columns["Tien"].Width = 120;

            // Căn giữa cho cột "STT" và "Số Lượng"
            dgvNhatKyTonKho.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhatKyTonKho.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhatKyTonKho.Columns["HinhThuc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn phải cho cột "Tiền"
            dgvNhatKyTonKho.Columns["Tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt tên cột bằng tiếng Việt có dấu và căn giữa
            dgvNhatKyTonKho.Columns["STT"].HeaderText = "STT";
            dgvNhatKyTonKho.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dgvNhatKyTonKho.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgvNhatKyTonKho.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvNhatKyTonKho.Columns["Ngay"].HeaderText = "Ngày";
            dgvNhatKyTonKho.Columns["HinhThuc"].HeaderText = "Hình Thức";
            dgvNhatKyTonKho.Columns["Tien"].HeaderText = "Tiền";

            // Căn giữa cho tiêu đề cột
            foreach (DataGridViewColumn column in dgvNhatKyTonKho.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            return processedTable;
        }

        private void FilterData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Truy vấn lọc sản phẩm dựa trên Danh mục và Sản phẩm
                    string filterQuery = @"
                        SELECT 
                            IL.PRODUCTID, 
                            IL.IEDATE, 
                            IL.IOE, 
                            IL.QUANTITY, 
                            IL.PRICE, 
                            C.PRODUCTNAME 
                        FROM 
                            INVENTORYLOG IL 
                        INNER JOIN 
                            CLOTHES C ON IL.PRODUCTID = C.ID 
                        WHERE 1 = 1"; // Điều kiện mặc định

                    // Lọc theo Danh mục (kiểm tra xem đã chọn danh mục chưa)
                    if (cmbDanhMuc.SelectedValue != DBNull.Value && cmbDanhMuc.SelectedValue != null)
                    {
                        filterQuery += " AND C.CATEGORYID = @CategoryId";
                    }

                    // Lọc theo Sản phẩm (kiểm tra xem đã chọn sản phẩm chưa)
                    if (cmbSanPham.SelectedValue != DBNull.Value && cmbSanPham.SelectedValue != null)
                    {
                        filterQuery += " AND IL.PRODUCTID = @ProductId";
                    }

                    SqlCommand filterCommand = new SqlCommand(filterQuery, conn);

                    // Thêm tham số cho Danh mục (nếu có)
                    if (cmbDanhMuc.SelectedValue != DBNull.Value && cmbDanhMuc.SelectedValue != null)
                    {
                        filterCommand.Parameters.AddWithValue("@CategoryId", cmbDanhMuc.SelectedValue);
                    }

                    // Thêm tham số cho Sản phẩm (nếu có)
                    if (cmbSanPham.SelectedValue != DBNull.Value && cmbSanPham.SelectedValue != null)
                    {
                        filterCommand.Parameters.AddWithValue("@ProductId", cmbSanPham.SelectedValue);
                    }

                    SqlDataAdapter filterAdapter = new SqlDataAdapter(filterCommand);
                    DataTable filterTable = new DataTable();
                    filterAdapter.Fill(filterTable);

                    // Xử lý dữ liệu cho DataGridView
                    DataTable processedTable = InitializeDataTable(filterTable);
                    dgvNhatKyTonKho.DataSource = processedTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi nhấn nút "Lọc"
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            IL.PRODUCTID, 
                            IL.IEDATE, 
                            IL.IOE, 
                            IL.QUANTITY, 
                            IL.PRICE, 
                            C.PRODUCTNAME
                        FROM 
                            INVENTORYLOG IL
                        INNER JOIN 
                            CLOTHES C ON IL.PRODUCTID = C.ID
                        WHERE IL.IEDATE BETWEEN @FromDate AND @ToDate";

                    // Lọc theo danh mục
                    if (cmbDanhMuc.SelectedValue != DBNull.Value && cmbDanhMuc.SelectedValue != null)
                    {
                        query += " AND C.CATEGORYID = @CategoryId";
                    }

                    // Lọc theo sản phẩm
                    if (cmbSanPham.SelectedValue != DBNull.Value && cmbSanPham.SelectedValue != null)
                    {
                        query += " AND IL.PRODUCTID = @ProductId";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    if (cmbDanhMuc.SelectedValue != DBNull.Value && cmbDanhMuc.SelectedValue != null)
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", cmbDanhMuc.SelectedValue);
                    }

                    if (cmbSanPham.SelectedValue != DBNull.Value && cmbSanPham.SelectedValue != null)
                    {
                        cmd.Parameters.AddWithValue("@ProductId", cmbSanPham.SelectedValue);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataTable processedTable = InitializeDataTable(dataTable);
                    dgvNhatKyTonKho.DataSource = processedTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi nhấn nút "Làm mới"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbDanhMuc.SelectedIndex = -1;
            cmbSanPham.SelectedIndex = -1;
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);  // Ví dụ: mặc định là 1 tháng trước
            dtpToDate.Value = DateTime.Now;

            LoadData();  // Tải lại dữ liệu không có bộ lọc
        }

        private void cmbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();  // Gọi hàm lọc khi người dùng thay đổi lựa chọn trong cmbDanhMuc
        }

        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();  // Gọi hàm lọc khi người dùng thay đổi lựa chọn trong cmbSanPham
        }


    }
}
