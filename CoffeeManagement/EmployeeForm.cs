using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CoffeeManagement
{
    public partial class EmployeeForm : UserControl
    {
        private DataTable table;
        bool modeInsert = true;
        private string maNhanVienCu;

        public EmployeeForm()
        {
            InitializeComponent();
            LoadEmployee();
        }

        private void LoadEmployee()
        {
            try
            {
                dtgvEmployees.Controls.Clear();
                DataProvider provider = new DataProvider();
                table = provider.LoadEmployee();
                dtgvEmployees.DataSource = table;
                dtgvEmployees.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dtgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (table != null && table.Rows.Count > 0)
            {
                int selectedIndex = dtgvEmployees.CurrentCell?.RowIndex ?? -1;
                if (selectedIndex >= 0 && selectedIndex < table.Rows.Count)
                {
                    modeInsert = false;
                    maNhanVienCu = table.Rows[selectedIndex][0].ToString();
                    txtMaNV.Text = table.Rows[selectedIndex][0].ToString();
                    txtTenNV.Text = table.Rows[selectedIndex][1].ToString();
                    txtSDT.Text = table.Rows[selectedIndex][6].ToString();
                    txtDiaChi.Text = table.Rows[selectedIndex][5].ToString();
                    txtChucVu.Text = table.Rows[selectedIndex][3].ToString();
                    string dateString = table.Rows[selectedIndex][4].ToString(); // Chuỗi đại diện ngày tháng từ cột trong bảng
                    DateTime dateValue;
                    if (DateTime.TryParse(dateString, out dateValue)) // Sử dụng DateTime.TryParse() để chuyển đổi
                    {
                        dtpNgayVaoLam.Value = dateValue.Date; // Gán giá trị DateTime cho DateTimePicker
                    }
                    else
                    {
                        // Xử lý khi không thể chuyển đổi chuỗi thành kiểu DateTime
                        // Ví dụ: Gán giá trị mặc định hoặc thông báo lỗi cho người dùng
                    }
                    bool phanquyen = Convert.ToBoolean(table.Rows[selectedIndex][7]); // Giá trị boolean từ cột trong bảng
                    cbQuyen.Checked = phanquyen; // Gán giá trị cho Checkbox
                    txtMatKhau.Text = table.Rows[selectedIndex][8].ToString();

                    bool gioitinh = Convert.ToBoolean(table.Rows[selectedIndex][2]); // Giá trị boolean từ cột trong bảng

                    if (gioitinh)
                    {
                        cbNam.Checked = true;
                        cbNu.Checked = false; // Chọn Checkbox 2
                        // Chọn Checkbox 1
                    }
                    else if (!gioitinh)
                    {
                        cbNam.Checked = false;
                        cbNu.Checked = true; // Chọn Checkbox 2
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                table.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                table.DefaultView.RowFilter = $"[Tên nhân viên] LIKE '%{searchText}%' OR [Số điện thoại] LIKE '%{searchText}%'";
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên hoặc SĐT để tìm kiếm")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Nhập tên hoặc SĐT để tìm kiếm";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            modeInsert = true;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtChucVu.Clear();
            txtMatKhau.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận chắc chắn xóa không?
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn xoá dữ liệu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            DataProvider provider = new DataProvider();
            provider.XoaNhanVien(maNhanVienCu);

            table = provider.LoadEmployee();
            dtgvEmployees.DataSource = table;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (modeInsert)
            {

                string passmaHoa = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);
                provider.ThemNhanVien(txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtDiaChi.Text, txtChucVu.Text, dtpNgayVaoLam.Text, cbQuyen.Checked, passmaHoa, cbNam.Checked);
                MessageBox.Show("Thêm nhân viên thành công");

            }
            else
            {
                string passmaHoa = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);
                provider.CapNhatNhanVien(maNhanVienCu, txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtDiaChi.Text, txtChucVu.Text, dtpNgayVaoLam.Text, cbQuyen.Checked, passmaHoa, cbNam.Checked);
                MessageBox.Show("Cập nhật nhân viên thành công");
            }

            table = provider.LoadEmployee();
            dtgvEmployees.DataSource = table;
        }
    }
}
