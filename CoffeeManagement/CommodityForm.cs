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
    public partial class CommodityForm : UserControl
    {
        private DataTable table;
        private string maHangHoaCu;
        bool modeInsert = true;
        public CommodityForm()
        {
            InitializeComponent();
            LoadTypeOfCommodity();
        }

        public CommodityForm(string MALH)
            :this ()
        {
            lbTypeOC_Code.Text = MALH;
        }

        private void LoadTypeOfCommodity()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable tableType = provider.LoadTypeOfCommodity();
                for (int i = 0; i < tableType.Rows.Count; i++)
                {
                    lbTypeOC_Code.Text = tableType.Rows[0][0].ToString();
                    cbTypeOC_Name.Text = tableType.Rows[0][1].ToString();
                    cbTypeOC_Name.Items.Add(tableType.Rows[i][1].ToString());
                    // Xử lý sự kiện SelectedIndexChanged của cbTypeOC_Name
                    cbTypeOC_Name.SelectedIndexChanged += (sender, e) =>
                    {
                        int selectedIndex = cbTypeOC_Name.SelectedIndex;
                        if (selectedIndex >= 0 && selectedIndex < tableType.Rows.Count)
                        {
                            lbTypeOC_Code.Text = tableType.Rows[selectedIndex][0].ToString();
                            LoadCommodity(lbTypeOC_Code.Text);
                        }
                    };

                    // Kiểm tra nếu có ít nhất một mục trong ComboBox, thì chọn mục đầu tiên
                    if (cbTypeOC_Name.Items.Count > 0)
                    {
                        cbTypeOC_Name.SelectedIndex = 0;
                    }
                }
            }
            catch
            {

            }
        }


        private void LoadCommodity(string MALH)
        {
            try
            {
                dtgvCommodity.Controls.Clear();
                DataProvider provider = new DataProvider();
                table = provider.LoadCommodityByType(MALH);
                dtgvCommodity.DataSource = table;
                dtgvCommodity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvCommodity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvCommodity.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        private void dtgvCommodity_SelectionChanged(object sender, EventArgs e)
        {
            if (table != null && table.Rows.Count > 0)
            {
                int selectedIndex = dtgvCommodity.CurrentCell?.RowIndex ?? -1;
                if (selectedIndex >= 0 && selectedIndex < table.Rows.Count)
                {

                    modeInsert = false;
                    maHangHoaCu = table.Rows[selectedIndex][1].ToString();
                    txtMaHH.Text = table.Rows[selectedIndex][1].ToString();
                    txtTenHH.Text = table.Rows[selectedIndex][2].ToString();
                    txtGia.Text = table.Rows[selectedIndex][3].ToString();
                }
            }
        }

      

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            modeInsert = true;
            txtMaHH.Clear();
            txtTenHH.Clear();
            txtGia.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (modeInsert)
            {
                provider.ThemHangHoa(lbTypeOC_Code.Text, txtMaHH.Text, txtTenHH.Text, txtGia.Text);
            }
            else
            {
                provider.CapNhatHangHoa(lbTypeOC_Code.Text,maHangHoaCu, txtMaHH.Text, txtTenHH.Text, txtGia.Text);
            }
            MessageBox.Show("luu hang hoa thanh cong");

           LoadCommodity(lbTypeOC_Code.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận chắc chắn xóa không?
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn xoá dữ liệu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            DataProvider provider = new DataProvider();
            provider.XoaHangHoa(maHangHoaCu);

            LoadCommodity(lbTypeOC_Code.Text);
        }
    }
}
