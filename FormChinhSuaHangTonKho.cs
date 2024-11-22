using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormChinhSuaHangTonKho : Form
    {
        private string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User Id=sa;Password=sa;"; // Thay đổi nếu cần

        public FormChinhSuaHangTonKho()
        {
            InitializeComponent();
        }

        private class ComboBoxDanhMucItem{
            public int CategoryID{ get; set; }
            public string CategoryName { get; set; }
            public override string ToString()
            {
                return CategoryName;
            }
        }
        private void FormChinhSuaHangTonKho_Load(object sender, EventArgs e)
        {
            LoadProductIds();
            cmbMaSanPham.SelectedIndexChanged += cmbMaSanPham_SelectedIndexChanged;
            cmbIdList.Items.Add(new KeyValuePair<string, bool>("True", true));
            cmbIdList.Items.Add(new KeyValuePair<string, bool>("False", false));
            cmbIdList.DisplayMember = "Key"; 
            cmbIdList.ValueMember = "Value"; 
        }

        private void cmbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSanPham.SelectedItem != null)
            {
                int selectedProductId = Convert.ToInt32(cmbMaSanPham.SelectedItem.ToString());
                LoadProductDetails(selectedProductId);
            }
        }

        private int GetSelectedCategoryID()
        {
            var selectedItem = cmbDanhMuc.SelectedItem;
            if (selectedItem != null)
            {
                ComboBoxDanhMucItem item = (ComboBoxDanhMucItem)selectedItem;
                return item.CategoryID;
            }
            return -1;
        }

        private int GetSelectedID()
        {
            var selectedItem = cmbMaSanPham.SelectedItem;
            if (selectedItem != null)
            {
                int id = Convert.ToInt32(selectedItem);
                return id;
            }
            return -1;
        }

        private bool GetSelectedIdListValue()
        {
            var selectedItem = cmbIdList.SelectedItem;
            if (selectedItem != null)
            {
                var keyValue = (KeyValuePair<string, bool>)selectedItem;
                return keyValue.Value;
            }
            return false; 
        }

        private byte[] GetRowVersionById(int id)
        {
            string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User ID=sa;Password=sa;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Truy vấn RowVersion
                    using (SqlCommand cmd = new SqlCommand("sp_GetRowVersionById", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ID", id);
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

        private void LoadProductDetails(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GetClotheById", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", productId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbDanhMuc.SelectedIndex = cmbDanhMuc.Items
                                    .Cast<ComboBoxDanhMucItem>()
                                    .ToList()
                                    .FindIndex(x => x.CategoryID == Convert.ToInt32(reader["CATEGORYID"]));

                                txtTenSanPham.Text = reader["PRODUCTNAME"].ToString();
                                txtCurrentPrice.Text = reader["CURRENTPRICE"].ToString();
                                numSoLuong.Value = Convert.ToInt32(reader["QUANTITY"]);
                                txtMauSac.Text = reader["COLOR"].ToString();
                                txtKichThuoc.Text = reader["SIZE"].ToString();
                                bool idList = Convert.ToBoolean(reader["IDLIST"]);
                                
                                if (cmbIdList.Items.Count > 0)
                                {
                                    var selectedItem = cmbIdList.Items.Cast<KeyValuePair<string, bool>>()
                                        .FirstOrDefault(x => x.Value == idList);
                                    
                                    if (selectedItem.Key != null)
                                    {
                                        cmbIdList.SelectedItem = selectedItem;
                                    }
                                }
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải thông tin sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void LoadProductIds()
        {
           string connectionString = "Server=26.26.244.217,1434;Database=Assigment;User ID=sa;Password=sa;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using(SqlCommand cmd = new SqlCommand("sp_GetAllIdProducts",connection)){
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using(SqlDataReader reader = cmd.ExecuteReader()){
                            while(reader.Read()){
                                cmbMaSanPham.Items.Add(reader["ID"].ToString());
                            }
                        }
                    }
                    using(SqlCommand cmd = new SqlCommand("sp_GetCategories",connection)){
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using(SqlDataReader reader = cmd.ExecuteReader()){
                            while(reader.Read()){
                                var CATEGORYID = Convert.ToInt32(reader["CATEGORYID"]);
                                var CATEGORYNAME = reader["CATEGORYNAME"].ToString();
                                var item = new ComboBoxDanhMucItem{
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
                    MessageBox.Show("Có lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
    
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text) ||
                cmbDanhMuc.SelectedItem == null ||
                numSoLuong.Value == 0 ||
                string.IsNullOrWhiteSpace(txtMauSac.Text) ||
                string.IsNullOrWhiteSpace(txtKichThuoc.Text) ||
                string.IsNullOrWhiteSpace(txtCurrentPrice.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal currentPrice;
            if (!decimal.TryParse(txtCurrentPrice.Text, out currentPrice) || currentPrice <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = GetSelectedID();

            int categoryId = GetSelectedCategoryID();
            if (categoryId == 0)
            {
                MessageBox.Show("Danh mục không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenSanPham = txtTenSanPham.Text;
            if (string.IsNullOrWhiteSpace(tenSanPham))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

            byte[] rowVersion = GetRowVersionById(id);
            if (rowVersion == null)
            {
                MessageBox.Show("Sản phẩm này đã tồn tại trong kho, không thể cập nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool idList = GetSelectedIdListValue();  
            UpdateClothesByID(id,categoryId, tenSanPham, currentPrice, soLuong, mauSac, kichThuoc, idList);
        }

        private void UpdateClothesByID(int id, int categoryId, string productName, decimal currentPrice, int quantity, string color, string size, bool idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.CLOTHES WHERE CATEGORYID = @CATEGORYID AND PRODUCTNAME = @PRODUCTNAME AND COLOR = @COLOR AND SIZE = @SIZE AND ID != @ID", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@CATEGORYID", categoryId);
                        checkCmd.Parameters.AddWithValue("@PRODUCTNAME", productName);
                        checkCmd.Parameters.AddWithValue("@COLOR", color);
                        checkCmd.Parameters.AddWithValue("@SIZE", size);
                        checkCmd.Parameters.AddWithValue("@ID", id);

                        int existingProductCount = (int)checkCmd.ExecuteScalar();

                        if (existingProductCount > 0)
                        {
                            MessageBox.Show("Sản phẩm trùng với sản phẩm khác trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; 
                        }
                    }
                    

                    using (SqlCommand cmd = new SqlCommand("sp_UpdateClothesByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID",id);
                        cmd.Parameters.AddWithValue("@CATEGORYID", categoryId);
                        cmd.Parameters.AddWithValue("@PRODUCTNAME", productName);
                        cmd.Parameters.AddWithValue("@CURRENTPRICE", currentPrice);
                        cmd.Parameters.AddWithValue("@QUANTITY", quantity);
                        cmd.Parameters.AddWithValue("@COLOR", color);
                        cmd.Parameters.AddWithValue("@SIZE", size);
                        cmd.Parameters.AddWithValue("@IDLIST", idList);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dữ liệu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
