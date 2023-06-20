namespace CoffeeManagement
{
    partial class SalaryEmployeeForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbEmployee_Code = new System.Windows.Forms.ComboBox();
            this.dtgvWorking_Shift = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTypeSalary = new System.Windows.Forms.Label();
            this.lbTypeShift = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTienLuong = new System.Windows.Forms.TextBox();
            this.txtTongCa = new System.Windows.Forms.TextBox();
            this.txtKyLuong = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgvSalaryEmployee = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGioKT = new System.Windows.Forms.DateTimePicker();
            this.dtGioBD = new System.Windows.Forms.DateTimePicker();
            this.txtLuongCa = new System.Windows.Forms.TextBox();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.txtMaCa = new System.Windows.Forms.TextBox();
            this.btnLuuCa = new System.Windows.Forms.Button();
            this.btnXoaCa = new System.Windows.Forms.Button();
            this.btnLuuLuong = new System.Windows.Forms.Button();
            this.btnXoaLuong = new System.Windows.Forms.Button();
            this.btnClearCa = new System.Windows.Forms.Button();
            this.btnClearLuong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvWorking_Shift)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSalaryEmployee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEmployee_Code
            // 
            this.cbEmployee_Code.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbEmployee_Code.FormattingEnabled = true;
            this.cbEmployee_Code.Location = new System.Drawing.Point(172, 66);
            this.cbEmployee_Code.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmployee_Code.Name = "cbEmployee_Code";
            this.cbEmployee_Code.Size = new System.Drawing.Size(248, 27);
            this.cbEmployee_Code.TabIndex = 8;
            this.cbEmployee_Code.SelectedIndexChanged += new System.EventHandler(this.cbEmployee_Code_SelectedIndexChanged);
            // 
            // dtgvWorking_Shift
            // 
            this.dtgvWorking_Shift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvWorking_Shift.Location = new System.Drawing.Point(4, 209);
            this.dtgvWorking_Shift.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvWorking_Shift.Name = "dtgvWorking_Shift";
            this.dtgvWorking_Shift.RowHeadersWidth = 51;
            this.dtgvWorking_Shift.Size = new System.Drawing.Size(533, 314);
            this.dtgvWorking_Shift.TabIndex = 10;
            this.dtgvWorking_Shift.SelectionChanged += new System.EventHandler(this.dtgvWorking_Shift_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã ca :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(32, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên ca :";
            // 
            // lbTypeSalary
            // 
            this.lbTypeSalary.AutoSize = true;
            this.lbTypeSalary.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTypeSalary.Location = new System.Drawing.Point(42, 142);
            this.lbTypeSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTypeSalary.Name = "lbTypeSalary";
            this.lbTypeSalary.Size = new System.Drawing.Size(80, 19);
            this.lbTypeSalary.TabIndex = 4;
            this.lbTypeSalary.Text = "Tiền lương :";
            // 
            // lbTypeShift
            // 
            this.lbTypeShift.AutoSize = true;
            this.lbTypeShift.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTypeShift.Location = new System.Drawing.Point(42, 107);
            this.lbTypeShift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTypeShift.Name = "lbTypeShift";
            this.lbTypeShift.Size = new System.Drawing.Size(86, 19);
            this.lbTypeShift.TabIndex = 3;
            this.lbTypeShift.Text = "Tổng ca làm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(32, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giờ vào ca :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(32, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giờ ra ca :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(32, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lương 1 ca :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(42, 37);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Kỳ lương :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTienLuong);
            this.groupBox2.Controls.Add(this.txtTongCa);
            this.groupBox2.Controls.Add(this.txtKyLuong);
            this.groupBox2.Controls.Add(this.cbEmployee_Code);
            this.groupBox2.Controls.Add(this.lbTypeSalary);
            this.groupBox2.Controls.Add(this.lbTypeShift);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(545, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(751, 197);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LƯƠNG NHÂN VIÊN";
            // 
            // txtTienLuong
            // 
            this.txtTienLuong.Location = new System.Drawing.Point(172, 138);
            this.txtTienLuong.Name = "txtTienLuong";
            this.txtTienLuong.Size = new System.Drawing.Size(248, 29);
            this.txtTienLuong.TabIndex = 11;
            // 
            // txtTongCa
            // 
            this.txtTongCa.Location = new System.Drawing.Point(172, 101);
            this.txtTongCa.Name = "txtTongCa";
            this.txtTongCa.Size = new System.Drawing.Size(248, 29);
            this.txtTongCa.TabIndex = 10;
            // 
            // txtKyLuong
            // 
            this.txtKyLuong.Location = new System.Drawing.Point(172, 29);
            this.txtKyLuong.Name = "txtKyLuong";
            this.txtKyLuong.Size = new System.Drawing.Size(246, 29);
            this.txtKyLuong.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(42, 72);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 19);
            this.label12.TabIndex = 2;
            this.label12.Text = "Mã nhân viên :";
            // 
            // dtgvSalaryEmployee
            // 
            this.dtgvSalaryEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvSalaryEmployee.Location = new System.Drawing.Point(545, 209);
            this.dtgvSalaryEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvSalaryEmployee.Name = "dtgvSalaryEmployee";
            this.dtgvSalaryEmployee.RowHeadersWidth = 51;
            this.dtgvSalaryEmployee.Size = new System.Drawing.Size(751, 314);
            this.dtgvSalaryEmployee.TabIndex = 9;
            this.dtgvSalaryEmployee.SelectionChanged += new System.EventHandler(this.dtgvSalaryEmployee_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGioKT);
            this.groupBox1.Controls.Add(this.dtGioBD);
            this.groupBox1.Controls.Add(this.txtLuongCa);
            this.groupBox1.Controls.Add(this.txtTenCa);
            this.groupBox1.Controls.Add(this.txtMaCa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(533, 197);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QUẢN LÝ CA LÀM";
            // 
            // dtGioKT
            // 
            this.dtGioKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtGioKT.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtGioKT.Location = new System.Drawing.Point(149, 130);
            this.dtGioKT.Margin = new System.Windows.Forms.Padding(4);
            this.dtGioKT.Name = "dtGioKT";
            this.dtGioKT.Size = new System.Drawing.Size(235, 29);
            this.dtGioKT.TabIndex = 11;
            // 
            // dtGioBD
            // 
            this.dtGioBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtGioBD.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtGioBD.Location = new System.Drawing.Point(149, 97);
            this.dtGioBD.Margin = new System.Windows.Forms.Padding(4);
            this.dtGioBD.Name = "dtGioBD";
            this.dtGioBD.Size = new System.Drawing.Size(235, 29);
            this.dtGioBD.TabIndex = 10;
            // 
            // txtLuongCa
            // 
            this.txtLuongCa.Location = new System.Drawing.Point(149, 161);
            this.txtLuongCa.Name = "txtLuongCa";
            this.txtLuongCa.Size = new System.Drawing.Size(235, 29);
            this.txtLuongCa.TabIndex = 9;
            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(149, 68);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(235, 29);
            this.txtTenCa.TabIndex = 6;
            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(149, 37);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.Size = new System.Drawing.Size(235, 29);
            this.txtMaCa.TabIndex = 5;
            // 
            // btnLuuCa
            // 
            this.btnLuuCa.BackgroundImage = global::CoffeeManagement.Properties.Resources.icon_save;
            this.btnLuuCa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLuuCa.Location = new System.Drawing.Point(308, 530);
            this.btnLuuCa.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuCa.Name = "btnLuuCa";
            this.btnLuuCa.Size = new System.Drawing.Size(40, 37);
            this.btnLuuCa.TabIndex = 32;
            this.btnLuuCa.UseVisualStyleBackColor = true;
            this.btnLuuCa.Click += new System.EventHandler(this.btnLuuCa_Click);
            // 
            // btnXoaCa
            // 
            this.btnXoaCa.BackgroundImage = global::CoffeeManagement.Properties.Resources.icon_delete;
            this.btnXoaCa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXoaCa.Location = new System.Drawing.Point(260, 530);
            this.btnXoaCa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaCa.Name = "btnXoaCa";
            this.btnXoaCa.Size = new System.Drawing.Size(40, 37);
            this.btnXoaCa.TabIndex = 31;
            this.btnXoaCa.UseVisualStyleBackColor = true;
            this.btnXoaCa.Click += new System.EventHandler(this.btnXoaCa_Click);
            // 
            // btnLuuLuong
            // 
            this.btnLuuLuong.BackgroundImage = global::CoffeeManagement.Properties.Resources.icon_save;
            this.btnLuuLuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLuuLuong.Location = new System.Drawing.Point(968, 530);
            this.btnLuuLuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuLuong.Name = "btnLuuLuong";
            this.btnLuuLuong.Size = new System.Drawing.Size(40, 37);
            this.btnLuuLuong.TabIndex = 35;
            this.btnLuuLuong.UseVisualStyleBackColor = true;
            this.btnLuuLuong.Click += new System.EventHandler(this.btnLuuLuong_Click);
            // 
            // btnXoaLuong
            // 
            this.btnXoaLuong.BackgroundImage = global::CoffeeManagement.Properties.Resources.icon_delete;
            this.btnXoaLuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXoaLuong.Location = new System.Drawing.Point(920, 530);
            this.btnXoaLuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaLuong.Name = "btnXoaLuong";
            this.btnXoaLuong.Size = new System.Drawing.Size(40, 37);
            this.btnXoaLuong.TabIndex = 34;
            this.btnXoaLuong.UseVisualStyleBackColor = true;
            this.btnXoaLuong.Click += new System.EventHandler(this.btnXoaLuong_Click);
            // 
            // btnClearCa
            // 
            this.btnClearCa.BackgroundImage = global::CoffeeManagement.Properties.Resources.Clear;
            this.btnClearCa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearCa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearCa.Location = new System.Drawing.Point(212, 529);
            this.btnClearCa.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCa.Name = "btnClearCa";
            this.btnClearCa.Size = new System.Drawing.Size(40, 38);
            this.btnClearCa.TabIndex = 36;
            this.btnClearCa.UseVisualStyleBackColor = true;
            this.btnClearCa.Click += new System.EventHandler(this.btnClearCa_Click);
            // 
            // btnClearLuong
            // 
            this.btnClearLuong.BackgroundImage = global::CoffeeManagement.Properties.Resources.Clear;
            this.btnClearLuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearLuong.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearLuong.Location = new System.Drawing.Point(872, 529);
            this.btnClearLuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLuong.Name = "btnClearLuong";
            this.btnClearLuong.Size = new System.Drawing.Size(40, 38);
            this.btnClearLuong.TabIndex = 37;
            this.btnClearLuong.UseVisualStyleBackColor = true;
            this.btnClearLuong.Click += new System.EventHandler(this.btnClearLuong_Click);
            // 
            // SalaryEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearLuong);
            this.Controls.Add(this.btnClearCa);
            this.Controls.Add(this.dtgvSalaryEmployee);
            this.Controls.Add(this.btnLuuLuong);
            this.Controls.Add(this.btnXoaLuong);
            this.Controls.Add(this.dtgvWorking_Shift);
            this.Controls.Add(this.btnLuuCa);
            this.Controls.Add(this.btnXoaCa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalaryEmployeeForm";
            this.Size = new System.Drawing.Size(1300, 578);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvWorking_Shift)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSalaryEmployee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEmployee_Code;
        private System.Windows.Forms.DataGridView dtgvWorking_Shift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTypeSalary;
        private System.Windows.Forms.Label lbTypeShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvSalaryEmployee;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLuuCa;
        private System.Windows.Forms.Button btnXoaCa;
        private System.Windows.Forms.Button btnLuuLuong;
        private System.Windows.Forms.Button btnXoaLuong;
        private System.Windows.Forms.TextBox txtTienLuong;
        private System.Windows.Forms.TextBox txtTongCa;
        private System.Windows.Forms.TextBox txtKyLuong;
        private System.Windows.Forms.TextBox txtLuongCa;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.TextBox txtMaCa;
        private System.Windows.Forms.Button btnClearCa;
        private System.Windows.Forms.Button btnClearLuong;
        private System.Windows.Forms.DateTimePicker dtGioKT;
        private System.Windows.Forms.DateTimePicker dtGioBD;
    }
}
