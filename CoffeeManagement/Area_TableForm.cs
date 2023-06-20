using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class Area_TableForm : UserControl
    {
        private DataTable table;
        private string maBanCu;
        bool modeInsert = true;
        public Area_TableForm()
        {
            InitializeComponent();
            LoadTable();
            LoadTrangThai();
        }

        private void LoadTable()
        {
            try
            {
                dtgvTable.Controls.Clear();
                DataProvider provider = new DataProvider();
                table = provider.LoadTable();
                dtgvTable.DataSource = table;
                dtgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvTable.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        public void LoadTrangThai()
        {
            cbTrangThai.Items.Add("Trống");
            cbTrangThai.Items.Add("Đặt trước");
        }

        private void dtgvTable_SelectionChanged(object sender, EventArgs e)
        {
            if (table != null && table.Rows.Count > 0)
            {
                int selectedIndex = dtgvTable.CurrentCell?.RowIndex ?? -1;
                if (selectedIndex >= 0 && selectedIndex < table.Rows.Count)
                {
                    maBanCu = table.Rows[selectedIndex][0].ToString();
                    txtMaBan.Text = table.Rows[selectedIndex][0].ToString();
                    txtTenBan.Text = table.Rows[selectedIndex][1].ToString();
                    cbTrangThai.Text = table.Rows[selectedIndex][2].ToString();
                    modeInsert = false;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            modeInsert = true;
            txtMaBan.Clear();
            txtTenBan.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận chắc chắn xóa không?
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn xoá dữ liệu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            DataProvider provider = new DataProvider();
            provider.XoaBan(maBanCu);

            table = provider.LoadTable();
            dtgvTable.DataSource = table;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (modeInsert)
            {
                provider.ThemBan(txtMaBan.Text, txtTenBan.Text, cbTrangThai.Text);
            }
            else
            {
                provider.CapNhatBan(maBanCu, txtMaBan.Text, txtTenBan.Text, cbTrangThai.Text);
            }
            MessageBox.Show("luu bàn thanh cong");

            table = provider.LoadTable();
            dtgvTable.DataSource = table;
        }
    }
}
