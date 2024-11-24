using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormNhapHangTonKho : Form
    {
        private string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User Id=sa;Password=sa;";
        public FormNhapHangTonKho()
        {
            InitializeComponent();
            LoadCategories();
        }
        
        private class ComboBoxItem
        {
            public int CategoryID { get; set; }
            public required string CategoryName { get; set; }

            public override string ToString()
            {
                return CategoryName;
            }
        }
        private void LoadCategories()
        {
            string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User ID=sa;Password=sa;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetCategories", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                              var CATEGORYID = Convert.ToInt32(reader["CATEGORYID"]);
                              var CATEGORYNAME = reader["CATEGORYNAME"].ToString();
                              var item = new ComboBoxItem{
                                CategoryID = CATEGORYID,
                                CategoryName = CATEGORYNAME
                              };
                              cmbDanhMuc.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi nạp danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private int GetSelectedCategoryID()
        {
            var selectedItem = cmbDanhMuc.SelectedItem;
            if (selectedItem != null)
            {
                ComboBoxItem item = (ComboBoxItem)selectedItem;
                return item.CategoryID;
            }
            return -1;
        }

        private byte[] GetRowVersion(int categoryId, string productName, string color, string size)
        {
            string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User ID=sa;Password=sa;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Truy vấn RowVersion
                    using (SqlCommand cmd = new SqlCommand("sp_GetRowVersion", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("CATEGORYID", categoryId);
                        cmd.Parameters.AddWithValue("PRODUCTNAME", productName);
                        cmd.Parameters.AddWithValue("COLOR", color);
                        cmd.Parameters.AddWithValue("SIZE", size);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result is byte[])
                        {
                            return (byte[])result;  
                        }
                        return null; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy RowVersion: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tenSanPham = txtTenSanPham.Text;
            if (string.IsNullOrWhiteSpace(tenSanPham))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string danhMuc = ((ComboBoxItem)cmbDanhMuc.SelectedItem)?.CategoryName;

            int soLuong = (int)numSoLuong.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mauSac = txtMauSac.Text;
            if (string.IsNullOrWhiteSpace(mauSac))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string kichThuoc = txtKichThuoc.Text;
            if (string.IsNullOrWhiteSpace(kichThuoc))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(danhMuc))
            {
                MessageBox.Show("Vui lòng chọn danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal currentPrice;
            if (!decimal.TryParse(txtCurrentPrice.Text, out currentPrice) || currentPrice <= 0)
            {
                MessageBox.Show("Giá hiện tại phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int categoryId = GetSelectedCategoryID();
            if (categoryId == 0)
            {
                MessageBox.Show("Danh mục không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            byte[] rowVersion = GetRowVersion(categoryId, tenSanPham, mauSac, kichThuoc);
            if (rowVersion != null)
            {
                MessageBox.Show("Sản phẩm này đã tồn tại trong kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User ID=sa;Password=sa;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.CLOTHES WHERE PRODUCTNAME = @PRODUCTNAME AND CATEGORYID = @CATEGORYID AND COLOR = @COLOR AND SIZE = @SIZE", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@PRODUCTNAME", tenSanPham);
                        checkCmd.Parameters.AddWithValue("@CATEGORYID", categoryId);
                        checkCmd.Parameters.AddWithValue("@COLOR", mauSac);
                        checkCmd.Parameters.AddWithValue("@SIZE", kichThuoc);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Sản phẩm này đã tồn tại trong danh mục này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_UpsertClothesStock", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PRODUCTNAME", tenSanPham);
                        cmd.Parameters.AddWithValue("@CATEGORYID", categoryId);
                        cmd.Parameters.AddWithValue("@CURRENTPRICE", currentPrice);
                        cmd.Parameters.AddWithValue("@QUANTITY", soLuong);
                        cmd.Parameters.AddWithValue("@COLOR", mauSac);
                        cmd.Parameters.AddWithValue("@SIZE", kichThuoc);
                        
                        try
                        {
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show($"Dữ liệu đã được lưu:\n" +
                                                $"- Tên sản phẩm: {tenSanPham}\n" +
                                                $"- Danh mục: {danhMuc}\n" +
                                                $"- Giá hiện tại: {currentPrice}\n" +
                                                $"- Số lượng: {soLuong}\n" +
                                                $"- Màu sắc: {mauSac}\n" +
                                                $"- Kích thước: {kichThuoc}",
                                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetFields();
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Message.Contains("Sản phẩm đã tồn tại"))
                            {
                                MessageBox.Show("Sản phẩm này đã tồn tại trong kho với thông tin tương tự. Không thể thêm mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void ResetFields()
        {
            cmbDanhMuc.SelectedIndex = -1;
            numSoLuong.Value = 0;
            txtMauSac.Clear();
            txtKichThuoc.Clear();
            txtCurrentPrice.Clear();
            txtTenSanPham.Clear();
        }
    }
}
