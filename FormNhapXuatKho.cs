using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace QuanLyKho
{
    public partial class FormNhapXuatKho : Form
    {
        private readonly SqlConnection _connection;
        private readonly BindingSource _bindingSource = new BindingSource();

        public FormNhapXuatKho()
        {
            InitializeComponent();
            _connection = new SqlConnection("Server=26.26.244.217,1434;Database=Assigment;User ID=sa;Password=sa;");
            
            // Đăng ký event handler
            btnImport.Click += btnImport_Click;
            btnExport.Click += btnExport_Click;
            
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using var cmd = new SqlCommand("sp_GetClothes", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                
                cboProducts.DataSource = table;
                cboProducts.DisplayMember = "PRODUCTNAME";
                cboProducts.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}");
            }
        }

        private async Task ProcessInventory(bool isImport)
        {
            try
            {
                if (!ValidateInput()) return;

                if (_connection.State != ConnectionState.Open)
                    await _connection.OpenAsync();

                int productId = (int)cboProducts.SelectedValue;
                int quantity = int.Parse(txtQuantity.Text);
                decimal price = decimal.Parse(txtPrice.Text);

                MessageBox.Show($"Debug: ProductID={productId}, Quantity={quantity}, Price={price}");

                // Lấy phiên bản hiện tại của sản phẩm
                byte[] currentVersion = await GetRowVersion(productId);

                using var transaction = _connection.BeginTransaction();
                try
                {
                    using var updateCmd = new SqlCommand(@"
                        UPDATE CLOTHES 
                        SET QUANTITY = QUANTITY + @QuantityChange,
                            CURRENTPRICE = @NewPrice
                        WHERE ID = @ProductId 
                        AND RowVersionColumn = @RowVersion
                        AND (QUANTITY + @QuantityChange) >= 0", _connection, transaction);

                    updateCmd.Parameters.AddWithValue("@QuantityChange", isImport ? quantity : -quantity);
                    updateCmd.Parameters.AddWithValue("@NewPrice", price);
                    updateCmd.Parameters.AddWithValue("@ProductId", productId);
                    updateCmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp).Value = currentVersion;

                    int rowsAffected = await updateCmd.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new DBConcurrencyException("Dữ liệu đã bị thay đổi bởi người khác. Vui lòng thử lại.");
                    }

                    // Ghi log
                    var logCmd = new SqlCommand(@"
                        INSERT INTO INVENTORYLOG (PRODUCTID, IEDATE, IOE, QUANTITY, PRICE)
                        VALUES (@ProductId, GETDATE(), @IsImport, @Quantity, @Price)", 
                        _connection, transaction);

                    logCmd.Parameters.AddWithValue("@ProductId", productId);
                    logCmd.Parameters.AddWithValue("@IsImport", isImport);
                    logCmd.Parameters.AddWithValue("@Quantity", quantity);
                    logCmd.Parameters.AddWithValue("@Price", price);

                    await logCmd.ExecuteNonQueryAsync();

                    transaction.Commit();
                    MessageBox.Show($"{(isImport ? "Nhập" : "Xuất")} kho thành công!");
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("Dữ liệu đã bị thay đổi bởi người khác. Vui lòng thử lại.");
                LoadProducts(); // Tải lại dữ liệu mới
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chi tiết: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }

        private async Task<byte[]> GetRowVersion(int productId)
        {
            using var cmd = new SqlCommand("sp_GetRowVersionById", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", productId);

            if (_connection.State != ConnectionState.Open)
                await _connection.OpenAsync();

            return (byte[])await cmd.ExecuteScalarAsync();
        }

        private bool ValidateInput()
        {
            if (cboProducts.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Giá không hợp lệ");
                return false;
            }

            return true;
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            await ProcessInventory(true);
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            await ProcessInventory(false);
        }
    }
} 