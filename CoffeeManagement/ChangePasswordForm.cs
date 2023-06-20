using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class ChangePasswordForm : Form
    {
        private readonly string connect = @"Data Source=DESKTOP-GP47KE0;Initial Catalog=CoffeeManagementSystem;Integrated Security=True";
        public ChangePasswordForm()
        {
            InitializeComponent();

        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {

            string passmaHoa = BCrypt.Net.BCrypt.HashPassword(txtMKCu.Text);
            string passmaHoa1 = BCrypt.Net.BCrypt.HashPassword(txtMKMoi.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    // Kiểm tra sự tồn tại của người dùng với tên đăng nhập và mật khẩu đã mã hóa
                    string selectQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE MANV = @Username AND MatKhau = @Password";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", txtHoTen.Text);
                        command.Parameters.AddWithValue("@Password", passmaHoa);
                        int count = (int)command.ExecuteScalar();

                        if (count == 1)
                        {
                            if (txtMKMoi.Text == txtXacNhanMK.Text)
                            {
                                // Cập nhật mật khẩu mới
                                string updateQuery = "UPDATE NHANVIEN SET MatKhau = @NewPassword WHERE MANV = @Username AND MatKhau = @OldPassword";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@NewPassword", passmaHoa1);
                                    updateCommand.Parameters.AddWithValue("@Username", txtHoTen.Text);
                                    updateCommand.Parameters.AddWithValue("@OldPassword", passmaHoa);
                                    int rowsAffected = updateCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}




