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
using System.Security.Cryptography;
using BCrypt.Net;

namespace CoffeeManagement
{

    public partial class LoginForm : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-GP47KE0;Initial Catalog=CoffeeManagementSystem;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            //Kiểm tra tài khoản và mật khẩu từ CSDL
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT MANV, TENNV, MatKhau, PhanQuyen FROM NHANVIEN WHERE MANV = @MANV";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MANV", username);
            SqlDataReader dr = cmd.ExecuteReader();
            bool isAdmin = false;
            if (dr.Read())
            {

                string MaNV = dr["MANV"].ToString();
                string TenNV = dr["TENNV"].ToString();
                int Quyen = Convert.ToInt32(dr["PhanQuyen"]);
                isAdmin = (Quyen == 1);
                // Kiểm tra mật khẩu đã mã hóa
                string hashedPassword = dr["MatKhau"].ToString();
                if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                {
                    this.Hide();
                    // Đăng nhập thành công, mở Form bán hàng
                    ManageForm manageForm = new ManageForm(MaNV, TenNV, isAdmin);
                    manageForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị hoặc ẩn mật khẩu
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
