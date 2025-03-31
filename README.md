# QuanLyKho
 Đồ án môn Hệ Thống Phân Tán<br>
Đề tài: Một server CSDL lưu trữ thông tin hàng nhập, xuất và tồn kho; 1 máy server điều khiển tương tranh lạc quan. Các client tiến hành nhập,xuất kho.
Viết chương trình nhập xuất tồn kho trên các client và ứng dụng điều khiển tương tranh.

## 📋 Mô tả dự án

Dự án QuanLyKho là một hệ thống quản lý kho hàng phân tán, cho phép nhiều client đồng thời truy cập và thao tác với cơ sở dữ liệu trung tâm. Hệ thống áp dụng cơ chế điều khiển tương tranh lạc quan (optimistic concurrency control) để đảm bảo tính nhất quán của dữ liệu khi có nhiều người dùng cùng truy cập.

### ✨ Các chức năng chính

- **Đăng nhập và phân quyền người dùng**: Phân biệt người dùng "Quản lý" và người dùng thông thường
- **Quản lý hàng tồn kho**: Thêm, sửa, xóa thông tin hàng hóa
- **Nhập/Xuất kho**: Ghi nhận thông tin nhập xuất kho với cơ chế xử lý tương tranh
- **Theo dõi nhật ký tồn kho**: Xem lịch sử thao tác nhập xuất
- **Tổng quan tồn kho**: Hiển thị báo cáo tổng quan về hàng hóa hiện có

## 🏗️ Cấu trúc dự án

Dự án được tổ chức theo mô hình Windows Forms với các thành phần chính:

### 📊 Cơ sở dữ liệu
- **Bảng ACCOUNT**: Quản lý thông tin người dùng và phân quyền
- **Bảng CATEGORY**: Lưu trữ danh mục sản phẩm
- **Bảng CLOTHES**: Quản lý thông tin sản phẩm với cơ chế version control (RowVersionColumn)
- **Bảng INVENTORYLOG**: Ghi nhận lịch sử nhập xuất kho

### 📱 Các Form chính
- **FormLogin**: Đăng nhập vào hệ thống
- **FormDieuKhien**: Màn hình chính điều hướng đến các chức năng
- **FormChinhSuaHangTonKho**: Quản lý thông tin hàng hóa
- **FormNhapHangTonKho**: Thêm mới hàng hóa vào kho
- **FormNhapXuatKho**: Thực hiện các thao tác nhập xuất kho
- **FormNhatKyTonKho**: Xem lịch sử thao tác với kho hàng
- **FormTongQuanTonKho**: Hiển thị báo cáo tổng quan

## 💡 Cơ chế điều khiển tương tranh

Dự án ứng dụng cơ chế điều khiển tương tranh lạc quan (Optimistic Concurrency Control):
- Sử dụng `RowVersionColumn` để theo dõi thay đổi dữ liệu
- Kiểm tra version trước khi cập nhật dữ liệu
- Xử lý xung đột khi dữ liệu đã bị thay đổi bởi người dùng khác

## 🚀 Hướng dẫn cài đặt

### Yêu cầu hệ thống
- Microsoft SQL Server
- .NET Framework 4.7.2 trở lên
- Visual Studio 2019 trở lên (để phát triển)

### Cài đặt cơ sở dữ liệu
1. Mở SQL Server Management Studio
2. Chạy script SQL từ file `QuanLyKho_database.sql` để tạo cơ sở dữ liệu

### Cài đặt và chạy ứng dụng
1. Mở solution bằng Visual Studio
2. Khôi phục các gói NuGet (nếu cần):
   ```
   dotnet restore
   ```
3. Cấu hình chuỗi kết nối (connection string) trong các file .cs để trỏ đến server SQL của bạn
4. Build và chạy ứng dụng:
   ```
   dotnet build
   dotnet run
   ```

## 📚 Hướng dẫn sử dụng

1. **Đăng nhập**:
   - Sử dụng tài khoản được cấp để đăng nhập vào hệ thống
   - Tùy vào vai trò (quản lý/nhân viên) sẽ có các quyền truy cập khác nhau

2. **Quản lý hàng tồn kho**:
   - Thêm danh mục sản phẩm mới
   - Cập nhật thông tin sản phẩm hiện có
   - Xem danh sách sản phẩm theo danh mục

3. **Nhập xuất kho**:
   - Chọn sản phẩm cần nhập/xuất
   - Nhập số lượng và giá
   - Hệ thống tự động kiểm tra tồn kho và xử lý xung đột

4. **Xem báo cáo**:
   - Theo dõi lịch sử nhập xuất
   - Xem tổng quan tồn kho hiện tại

## 👨‍💻 Đóng góp và phát triển

Dự án được phát triển cho môn học Hệ Thống Phân Tán. Mọi đóng góp và cải tiến vui lòng liên hệ với nhóm phát triển.

## 📄 Giấy phép

Dự án này được phát triển phục vụ cho mục đích học tập.