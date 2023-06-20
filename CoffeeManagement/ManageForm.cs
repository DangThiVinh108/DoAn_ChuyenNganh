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
    public partial class ManageForm : Form
    {
        // Khai báo biến kết nối CSDL

        private string MaNV;
        private string TenNV;
        private bool isAdmin;
        private UserControl CurrentControl;

        public ManageForm(string MaNV, string TenNV, bool isAdmin)
        {
            InitializeComponent();
            this.MaNV = MaNV;
            this.TenNV = TenNV;
            lbUserInfor.Text = MaNV + " - " + TenNV;
            this.isAdmin = isAdmin;

            if (isAdmin)
            {
                btnSell.Visible = true;
                btnEmployeeManager.Visible = true;
                btnEmployeeSalaryManagement.Visible = true;
                btnTypeOfCommodity.Visible = true;
                btnCommodity.Visible = true;
                btnArea_Table.Visible = true;
                btnStatistic.Visible = true;
                btnSalaryStatistics.Visible = true;
            }
            else
            {
                btnSell.Visible = true;
            }    
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "BÁN HÀNG";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }    
            CurrentControl = new SellForm();
            CurrentControl.Location = new Point(200,90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnEmployeeManager_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new EmployeeForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnEmployeeSalaryManagement_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "QUẢN LÝ LƯƠNG NHÂN VIÊN";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new SalaryEmployeeForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        

        private void btnTypeOfCommodity_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "LOẠI HÀNG";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new TypeOfCommodityForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnCommodity_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "HÀNG HÓA";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new CommodityForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnArea_Table_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "BÀN";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new Area_TableForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "THỐNG KÊ";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new StatisticForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnSalaryStatistics_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "THỐNG KÊ LƯƠNG";
            if (CurrentControl != null)
            {
                CurrentControl.Hide();
            }
            CurrentControl = new SalaryStatisticsForm();
            CurrentControl.Location = new Point(200, 90);
            Controls.Add(CurrentControl);
            CurrentControl.BringToFront();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog();
        }
    }
}
