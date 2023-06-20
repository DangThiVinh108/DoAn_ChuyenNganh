using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button.GroupBox;
using Label = System.Windows.Forms.Label;

namespace CoffeeManagement
{
    public partial class SellForm : UserControl
    {

        string strBill;

        List<TableChosed> lstTbl = new List<TableChosed>();

        public SellForm()
        {
            InitializeComponent();
            LoadTables();
            Load_TypeOfCommodity();
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
        }   

        private void LoadTables()
        {
            try
            {
                pnlTable.Controls.Clear();
                DataProvider provider = new DataProvider();
                DataTable table = provider.LoadTable();
                int x = 5;
                int y = 5;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = table.Rows[i][0].ToString(),
                        Text = table.Rows[i][1].ToString(), //ten ban
                        Tag = table.Rows[i][2].ToString(),
                        Width = 115,
                        Height = 50,
                        Location = new Point(x, y),
                        
                    };
                    //Set trang thai ban
                    if (btn.Tag.ToString() == "Trống")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("snow");
                        //Ban Trong contextmenu 2
                        //btn.ContextMenuStrip = cmnSubTable2;
                    }
                    else if (btn.Tag.ToString() == "Đang sử dụng")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("lime");
                        //Ban Trong contextmenu full option
                        //btn.ContextMenuStrip = cmnSubTable;
                    }
                    else if (btn.Tag.ToString() == "Đặt trước")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("red");
                        //Ban Trong contextmenu khoa
                        //btn.ContextMenuStrip = cmnSubTable3;
                    }
                    //Xu ly vi tri button, rat cong phu :)
                    if (x < pnlTable.Width - 220)
                    {
                        x += 125;
                    }
                    else
                    {
                        x = 5;
                        y += 60;
                    }
                    btn.MouseClick += new MouseEventHandler(btnTable_MouseClick);
                    pnlTable.Controls.Add(btn);
                }
            }
            catch
            {
                MessageBox.Show("Không thể tải bàn!", "Lỗi...");
            }
        }

        //Ham load BILL
        public void LoadBill()
        {
            try
            {
                //Don rac
                pnlBill.Controls.Clear();
                strBill = "";
                DataProvider provider = new DataProvider();
                DataTable table = provider.LoadBill(lbTableCode.Text);
                lbBill_Code.Text = table.Rows[0][0].ToString();
                lbEmployee_Code.Text = table.Rows[0][1].ToString();
                txtTotalMoney.Text = table.Rows[0][6].ToString() + " VNĐ ";  //
                //Load thong tin cac mon trong bill 
                int y = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //Thêm vào bill
                    strBill += (i + 1) + ".     " + table.Rows[i][4].ToString() + "  X  " + table.Rows[i][5].ToString() + "\n";
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

        private void Load_TypeOfCommodity()
        {
            try
            {
                //Don rac
                pnlTypeOfCommodity.Controls.Clear();
                DataProvider provider = new DataProvider();
                DataTable table = provider.LoadTypeOfCommodity();
                int x = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnFood" + i,
                        Text = table.Rows[i][1].ToString(), //name TypeOfCommodity
                        Width = 120,
                        Height = pnlTypeOfCommodity.Height - 30,
                        Location = new Point(x, pnlTypeOfCommodity.Location.Y - 20),
                        BackColor = ColorTranslator.FromHtml("Snow"),
                    };
                    x += 130;
                    pnlTypeOfCommodity.Controls.Add(btn);
                    btn.Click += new EventHandler(btnTypeOfCommodity_Click);
                }
                //san tien mo luon 1 food dau tien
                LoadCommodity(table.Rows[0][1].ToString());
            }
            catch
            {
            }
        }

        private void LoadCommodity(string nameCommodity)
        {
            try
            {
                //Don rac
                pnlCommodity.Controls.Clear();
                DataProvider provider = new DataProvider();
                DataTable table = provider.LoadCommodity(nameCommodity);
                lbNameCommodity.Text = table.Rows[0][0].ToString(); //ten cua thang food hien tai
                lbPrice.Text = table.Rows[0][2].ToString();  //gia cua thang food hien tai
                int y = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnFood" + i,
                        Text = table.Rows[i][0].ToString(), //name foods
                        Tag = table.Rows[i][2].ToString(), //Price food
                        Width = pnlCommodity.Width - 40,
                        Height = 50,
                        Location = new Point(pnlCommodity.Location.X, y),
                        BackColor = ColorTranslator.FromHtml("Snow"),
                    };
                    y += 60;
                    btn.Click += new EventHandler(btnCommodity_Click);
                    pnlCommodity.Controls.Add(btn);
                }
            }
            catch
            {
            }
        }

        //Su kien Mouseclick vao btnTABLE
        private void btnTable_MouseClick(object sender, EventArgs e)
        {
            ClickTable(sender, e);
        }

        private void ClickTable(object sender, EventArgs e)
        {
            //tra ve trang thai ban theo mau sac cua btnTable
            if (((Button)sender).BackColor.ToString() == "Color [Snow]")
            {
                lbStatus.Text = "Trống";
                pnlBill.Controls.Clear();
            }
            else if (((Button)sender).BackColor.ToString() == "Color [Lime]")
            {
                lbStatus.Text = "Đang sử dụng";
            }
            
            //tra ve ten ban
            lbTableCode.Text = ((Button)sender).Name;
            //Tra ve tong tien
            //txtTotalMoney.Text = ((Button)sender).Tag.ToString();
            LoadBill();
            // check table
           
        }

        //Su kien click btnTypeOfCommodity
        private void btnTypeOfCommodity_Click(object sender, EventArgs e)
        {
            string nameCommodity = ((Button)sender).Text;
            //Load mon theo yeu cau click cua Category
            LoadCommodity(nameCommodity);
        }

        //Su kiem click btnFood
        private void btnCommodity_Click(object sender, EventArgs e)
        {
            //Gan text button mon an => text groupbox . cho no dep
            lbNameCommodity.Text = ((Button)sender).Text;
            lbPrice.Text = ((Button)sender).Tag.ToString();
            OrderCommodity();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgvMenu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderCommodity();
        }

        private void OrderCommodity()
        {
            try
            {
                if (lbStatus.Text == "Đang sử dụng")
                {
                    AddCommodityForm addCommodityForm = new AddCommodityForm(lbEmployee_Code.Text, lbTableCode.Text, lbNameCommodity.Text, lbStatus.Text);
                    addCommodityForm.ShowDialog();
                    this.Show();
                    LoadTables();
                    LoadBill();
                }
                else if (lbStatus.Text == "Đặt trước")
                {
                    MessageBox.Show("Bàn đã được đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (lbStatus.Text == "Trống")
                {
                    //DialogResult ms = MessageBox.Show("Bàn này đang trống. Mở bàn nhé?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (ms == DialogResult.Yes)
                    //{
                        AddCommodityForm addCommodityForm = new AddCommodityForm(lbEmployee_Code.Text, lbTableCode.Text, lbNameCommodity.Text, lbStatus.Text);
                        addCommodityForm.ShowDialog();
                        this.Show();
                        LoadTables();
                        LoadBill();
                    //}
                }
            }
            catch { }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PayCommodity();
        }

        private void PayCommodity()
        {
            try
            {
                if (lbStatus.Text == "Đang sử dụng")
                {
                    PayForm payForm = new PayForm(lbTableCode.Text, lbBill_Code.Text);
                    payForm.ShowDialog();
                    this.Show();
                    LoadTables();
                    LoadBill();
                }
                
                else if (lbStatus.Text == "Trống")
                {
                    MessageBox.Show("Bàn này đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch 
            { 
            
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }

    public class TableChosed
    {
        string MaBan { get; set; }
        int TrangThai { get; set; }//0.trong, 1.dangchon
    }
}
