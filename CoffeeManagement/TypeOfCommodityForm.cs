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
    public partial class TypeOfCommodityForm : UserControl
    {
        private DataTable table;
        private string maLoaiHangCu;
        bool modeInsert = true;
        public TypeOfCommodityForm()
        {
            InitializeComponent();
            LoadTypeOfCommodity();
           
        }

        private void LoadTypeOfCommodity()
        {
            try
            {
                dtgvTypeOfCommodity.Controls.Clear();
                DataProvider provider = new DataProvider();
                table = provider.LoadTypeOfCommodity();
                dtgvTypeOfCommodity.DataSource = table;
                dtgvTypeOfCommodity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvTypeOfCommodity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvTypeOfCommodity.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        private void dtgvTypeOfCommodity_SelectionChanged(object sender, EventArgs e)
        {
            if (table != null && table.Rows.Count > 0)
            {
                int selectedIndex = dtgvTypeOfCommodity.CurrentCell?.RowIndex ?? -1;
                if (selectedIndex >= 0 && selectedIndex < table.Rows.Count)
                {
                    maLoaiHangCu = table.Rows[selectedIndex][0].ToString(); 
                    txtMaLoaiHang.Text = table.Rows[selectedIndex][0].ToString();
                    txtTenLoaiHang.Text = table.Rows[selectedIndex][1].ToString();
                    txtMoTa.Text = table.Rows[selectedIndex][2].ToString();
                    modeInsert = false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (modeInsert)
            {
                provider.ThemLoaiHang(txtMaLoaiHang.Text, txtTenLoaiHang.Text, txtMoTa.Text);
            }
            else
            {
                provider.CapNhatLoaiHang(maLoaiHangCu, txtMaLoaiHang.Text, txtTenLoaiHang.Text, txtMoTa.Text);
            }
            MessageBox.Show("luu loai hang thanh cong");

            table = provider.LoadTypeOfCommodity();
            dtgvTypeOfCommodity.DataSource = table;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            modeInsert = true;
            txtMaLoaiHang.Clear();
            txtTenLoaiHang.Clear();
            txtMoTa.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận chắc chắn xóa không?
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn xoá dữ liệu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            
            DataProvider provider = new DataProvider();
            provider.XoaLoaiHang(maLoaiHangCu);

            table = provider.LoadTypeOfCommodity();
            dtgvTypeOfCommodity.DataSource = table;
        }
    }
}
