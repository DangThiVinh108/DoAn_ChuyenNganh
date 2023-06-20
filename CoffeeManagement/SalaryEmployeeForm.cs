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
    public partial class SalaryEmployeeForm : UserControl
    {
        private DataTable table;
        private DataTable tableSD;
        private DataTable tableSDbyE;
        private string maCaCu;
        private string maLuongCu;
        bool modeInsert = true;

        public SalaryEmployeeForm()
        {
            InitializeComponent();
            LoadWorkingShift();
            LoadSalaryEmployeeDetail();
            cbEmployee_Code.SelectedIndexChanged += cbEmployee_Code_SelectedIndexChanged;

        }

        private void SalaryEmployeeForm_Load(object sender, EventArgs e)
        {
        }

        public SalaryEmployeeForm(string MANV_TENV)
            : this()
        {
            cbEmployee_Code.Text = MANV_TENV;
        }

        private void LoadWorkingShift()
        {
            try
            {
                dtgvWorking_Shift.Controls.Clear();
                DataProvider provider = new DataProvider();
                table = provider.LoadWorkingShift();
                dtgvWorking_Shift.DataSource = table;
                dtgvWorking_Shift.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvWorking_Shift.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvWorking_Shift.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        private void LoadSalaryEmployeeDetail()
        {
            try
            {
                dtgvSalaryEmployee.Controls.Clear();

                DataProvider provider = new DataProvider();
                tableSD = provider.LoadSalaryEmployeeDetail();


                

                dtgvSalaryEmployee.DataSource = tableSD;

                if (dtgvSalaryEmployee.Rows.Count > 0)
                {
                    // Lấy bản ghi đầu tiên
                    DataGridViewRow firstRow = dtgvSalaryEmployee.Rows[0];

                    // Hiển thị thông tin của bản ghi đầu tiên lên các Label
                    DisplayRecordDetails(firstRow);
                }

                dtgvSalaryEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvSalaryEmployee.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvSalaryEmployee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvSalaryEmployee.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        private void DisplayRecordDetails(DataGridViewRow selectedRow)
        {
            if (selectedRow != null)
            {
                txtKyLuong.Text = selectedRow.Cells["Kỳ lương"].Value.ToString();
                cbEmployee_Code.Text = selectedRow.Cells["Nhân viên"].Value.ToString();
                txtTongCa.Text = selectedRow.Cells["Số ca làm"].Value.ToString();
                txtTienLuong.Text = selectedRow.Cells["Tiền lương"].Value.ToString() + " VNĐ";
            }
        }
    private void LoadSalaryEmployeeDetailsByEmployeeCode(string MANV_TENNV)
        {
            try
            {
                dtgvSalaryEmployee.Controls.Clear();
                DataProvider provider = new DataProvider();
                tableSDbyE = provider.LoadSalaryEmployeeDetailsByEmployeeCode(MANV_TENNV);
                dtgvSalaryEmployee.DataSource = tableSDbyE;
                dtgvSalaryEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvSalaryEmployee.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvSalaryEmployee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvSalaryEmployee.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        private void dtgvWorking_Shift_SelectionChanged(object sender, EventArgs e)
        {
            if (table != null && table.Rows.Count > 0)
            {
                int selectedIndex = dtgvWorking_Shift.CurrentCell?.RowIndex ?? -1;
                if (selectedIndex >= 0 && selectedIndex < table.Rows.Count)
                {
                    maCaCu = table.Rows[selectedIndex][0].ToString();
                    txtMaCa.Text = table.Rows[selectedIndex][0].ToString();
                    txtTenCa.Text = table.Rows[selectedIndex][1].ToString();
                    dtGioBD.Text = table.Rows[selectedIndex][2].ToString();
                    dtGioKT.Text = table.Rows[selectedIndex][3].ToString();
                    txtLuongCa.Text = table.Rows[selectedIndex][4].ToString() + " VNĐ";
                    modeInsert = false;

                }
            }
        }

        private void dtgvSalaryEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (tableSD != null && tableSD.Rows.Count > 0)
            {
                int selectedIndex = dtgvSalaryEmployee.CurrentCell?.RowIndex ?? -1;
                if (selectedIndex >= 0 && selectedIndex < tableSD.Rows.Count)
                {
                    maLuongCu = tableSD.Rows[selectedIndex][1].ToString();
                    txtKyLuong.Text = tableSD.Rows[selectedIndex][0].ToString();
                    cbEmployee_Code.Text = tableSD.Rows[selectedIndex][1].ToString();                    
                    txtTongCa.Text = tableSD.Rows[selectedIndex][2].ToString();
                    txtTienLuong.Text = tableSD.Rows[selectedIndex][3].ToString() + " VNĐ";
                    modeInsert = false;

                }

                if (cbEmployee_Code.Items.Count > 0)
                {
                    cbEmployee_Code.SelectedIndex = 0;
                }
            }
        }

        private void cbEmployee_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployee = cbEmployee_Code.Text;
            LoadSalaryEmployeeDetailsByEmployeeCode(selectedEmployee);
        }

        private void btnClearCa_Click(object sender, EventArgs e)
        {
            modeInsert = true;
            txtMaCa.Clear();
            txtTenCa.Clear();
            txtLuongCa.Clear();
        }

        private void btnXoaCa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận chắc chắn xóa không?
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn xoá dữ liệu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            DataProvider provider = new DataProvider();
            provider.XoaCa(maCaCu);

            table = provider.LoadWorkingShift();
            dtgvWorking_Shift.DataSource = table;
        }

        private void btnLuuCa_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (modeInsert)
            {
                provider.ThemCa(txtMaCa.Text, txtTenCa.Text,dtGioBD.Value,dtGioKT.Value, txtLuongCa.Text);
            }
            else
            {
                provider.CapNhatCa(maCaCu, txtMaCa.Text, txtTenCa.Text,dtGioBD.Value,dtGioKT.Value, txtLuongCa.Text);
            }
            MessageBox.Show("luu loai hang thanh cong");

            table = provider.LoadWorkingShift();
            dtgvWorking_Shift.DataSource = table;
        }

        private void btnClearLuong_Click(object sender, EventArgs e)
        {
            modeInsert = true;
            txtKyLuong.Clear();
            cbEmployee_Code.Enabled = true;
            txtTongCa.Clear() ;
            txtTienLuong.Clear();
        }

        private void btnXoaLuong_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận chắc chắn xóa không?
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn xoá dữ liệu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            DataProvider provider = new DataProvider();
            provider.XoaLuong(cbEmployee_Code.Text,maLuongCu);

            table = provider.LoadSalaryEmployeeDetailsByEmployeeCode(cbEmployee_Code.Text);
            dtgvSalaryEmployee.DataSource = table;
        }

        private void btnLuuLuong_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (modeInsert)
            {
                provider.ThemLuong(txtKyLuong.Text,cbEmployee_Code.Text, Int16.Parse(txtTongCa.Text), Int16.Parse(txtTienLuong.Text));
            }
            else
            {
                provider.CapNhatLuong(maLuongCu, txtKyLuong.Text, cbEmployee_Code.Text, Int16.Parse(txtTongCa.Text), Int16.Parse(txtTienLuong.Text));
            }
            MessageBox.Show("luu luong thanh cong");

            table = provider.LoadSalaryEmployeeDetailsByEmployeeCode(cbEmployee_Code.Text);
            dtgvSalaryEmployee.DataSource = table;
        }
    }
}
