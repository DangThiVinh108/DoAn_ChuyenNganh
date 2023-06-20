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
    public partial class PayForm : Form
    {
        public PayForm()
        {
            InitializeComponent();
        }

        public PayForm(string tableName, string billCode)
            : this()
        {
            lbTable_Code.Text = tableName;
            lbBill_Code.Text = billCode.ToString();
            LoadDataForm();
            LoadDataBill();
        }

        //Load len cho nguoi dung xem thoi
        private void LoadDataForm()
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.LoadTableWhere(lbTable_Code.Text);
            lbTable_Code.Text = table.Rows[0][1].ToString();
        }

        private void LoadDataBill()
        {
            try
            {
                //Don rac
                pnlBill.Controls.Clear();
                DataProvider provider = new DataProvider();
                DataTable table = provider.LoadBillWhere(lbBill_Code.Text);
                //Load thong tin cac mon trong bill 
                int y = 10;
                lbTotal.Text = table.Rows[0][6].ToString();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,
                        //in ra man hinh tung mon nhu vay no moi dep :)
                        Text = (i + 1) + ".     " + table.Rows[i][4].ToString() + "  X  " + table.Rows[i][5].ToString(),
                        Width = pnlBill.Width - 20,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    y += 25;
                    pnlBill.Controls.Add(lbl);
                }
            }
            catch
            {
            }
        }

        private void PayForm_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thanh toán " + lbTable_Code.Text + "\nTổng tiền: " + lbTotal.Text + " VNĐ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (ms == DialogResult.Yes)
            {
                //Tih tien
                SetTableNull();
                //deleteBill();
                MessageBox.Show("Đã thanh toán " + lbTable_Code.Text, "Xong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (ms == DialogResult.No)
            {
                this.Close();
            }
            DataProvider provider = new DataProvider();

            provider.CapNhatTTBan(lbTable_Code.Text,"Trống");
            provider.CapNhatTTHoaDon(Int16.Parse(lbBill_Code.Text), 2);

            // load lại hóa đơn
            SellForm sellform = new SellForm();
            //Application.Run(SellForm());
        }

        //set ban ve rong
        public void SetTableNull()
        {
            DataProvider provider = new DataProvider();
            provider.ClearTable(lbTable_Code.Text);
        }
    }
}
