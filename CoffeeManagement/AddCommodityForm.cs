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
    public partial class AddCommodityForm : Form
    {
        bool isFood = false;

        public AddCommodityForm()
        {
            InitializeComponent();
        }

        public AddCommodityForm(string MANV, string MABAN, string TENHH, string STT)
            : this()
        {
            LoadCommodity();
            //chon gia tri goi y
            lbEmployee_Code.Text = MANV;
            lbTable.Text = MABAN;
            cbCommodity.Text = TENHH;
            lbStatus.Text = STT;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCommodity()
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.LoadAllCommodity();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbCommodity.Items.Add(table.Rows[i][2].ToString());
                // Xử lý sự kiện SelectedIndexChanged của cbTypeOC_Name
                cbCommodity.SelectedIndexChanged += (sender, e) =>
                {
                    int selectedIndex = cbCommodity.SelectedIndex;
                    if (selectedIndex >= 0 && selectedIndex < table.Rows.Count)
                    {
                        lblMaHang.Text = table.Rows[selectedIndex][0].ToString();
                        lblGiaBan.Text = table.Rows[selectedIndex][3].ToString();
                    }
                };
            }
        }

        //Ham Mở bàn
        public void OpenTable()
        {
            DataProvider provider = new DataProvider();
            provider.ResetTable(lbTable.Text);
        }

        public int TinhTongTien()
        {
            int tong = 0;

            return tong;
        }

        //Them mon moi
        public void AddCommodity()
        {
           
            DataProvider provider = new DataProvider();
            provider.ThemHoaDonBan("NV002", lbTable.Text, dtNgayLapHD.Value, Int16.Parse(lblGiaBan.Text));
            var mahd = provider.GetMaHohaDon_byTable(lbTable.Text);
            if (mahd == 0) { }
            provider.ThemChiTietHoaDon(mahd, lblMaHang.Text, Int16.Parse(cbCount.Value.ToString()));


            //dong thoi tang total
            //setTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                //Kiem tra ban trong k
                if (lbStatus.Text == "Trống")
                {
                    //Neu ban trong thi mo ban moi va them mon
                    OpenTable();
                    AddCommodity();
                    this.Close();
                }
                else if (lbStatus.Text == "Đang sử dụng")
                {
                    //Ban dang hoat dong. chi them mon
                    //isCountFood();
                    if (isFood == false)
                    {
                        //Neu mon chua co thi them mon
                        AddCommodity();
                        this.Close();
                    }
                    else
                    {
                        //Neu mon co roi thi tang so luong
                        //addCountFood();
                        this.Close();
                    }
                }
                MessageBox.Show("Thêm món thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm món không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
