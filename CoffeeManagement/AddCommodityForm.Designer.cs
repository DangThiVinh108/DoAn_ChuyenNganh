namespace CoffeeManagement
{
    partial class AddCommodityForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCommodityForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtNgayLapHD = new System.Windows.Forms.DateTimePicker();
            this.lbEmployee_Code = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbTable = new System.Windows.Forms.Label();
            this.cbCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCommodity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaHang = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.lblGiaBan);
            this.groupBox1.Controls.Add(this.lblMaHang);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dtNgayLapHD);
            this.groupBox1.Controls.Add(this.lbEmployee_Code);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.lbTable);
            this.groupBox1.Controls.Add(this.cbCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbCommodity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(149)))), ((int)(((byte)(136)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtNgayLapHD
            // 
            resources.ApplyResources(this.dtNgayLapHD, "dtNgayLapHD");
            this.dtNgayLapHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayLapHD.Name = "dtNgayLapHD";
            // 
            // lbEmployee_Code
            // 
            resources.ApplyResources(this.lbEmployee_Code, "lbEmployee_Code");
            this.lbEmployee_Code.Name = "lbEmployee_Code";
            // 
            // lbStatus
            // 
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.Name = "lbStatus";
            // 
            // lbTable
            // 
            resources.ApplyResources(this.lbTable, "lbTable");
            this.lbTable.Name = "lbTable";
            // 
            // cbCount
            // 
            this.cbCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.cbCount, "cbCount");
            this.cbCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cbCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cbCount.Name = "cbCount";
            this.cbCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbCommodity
            // 
            this.cbCommodity.BackColor = System.Drawing.Color.White;
            this.cbCommodity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCommodity, "cbCommodity");
            this.cbCommodity.FormattingEnabled = true;
            this.cbCommodity.Name = "cbCommodity";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblMaHang
            // 
            resources.ApplyResources(this.lblMaHang, "lblMaHang");
            this.lblMaHang.Name = "lblMaHang";
            // 
            // lblGiaBan
            // 
            resources.ApplyResources(this.lblGiaBan, "lblGiaBan");
            this.lblGiaBan.Name = "lblGiaBan";
            // 
            // AddCommodityForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCommodityForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown cbCount;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbCommodity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.Label lbEmployee_Code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgayLapHD;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label lblMaHang;
    }
}