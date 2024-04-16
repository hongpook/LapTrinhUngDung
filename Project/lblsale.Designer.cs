namespace Project
{
    partial class lblsale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lblsale));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnDetailsOrder = new System.Windows.Forms.Button();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSales = new System.Windows.Forms.Panel();
            this.dtpPickADay = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.pnlSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 512);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(972, 506);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtpPickADay);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnShowAll);
            this.tabPage1.Controls.Add(this.btnDetailsOrder);
            this.tabPage1.Controls.Add(this.btnUpdateOrder);
            this.tabPage1.Controls.Add(this.btnDeleteOrder);
            this.tabPage1.Controls.Add(this.btnAddOrder);
            this.tabPage1.Controls.Add(this.dgvOrder);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(964, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Đặt hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 45;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(420, 25);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 28);
            this.btnShowAll.TabIndex = 44;
            this.btnShowAll.Text = "Hiển thị tất cả";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnDetailsOrder
            // 
            this.btnDetailsOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailsOrder.Image")));
            this.btnDetailsOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailsOrder.Location = new System.Drawing.Point(837, 21);
            this.btnDetailsOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetailsOrder.Name = "btnDetailsOrder";
            this.btnDetailsOrder.Size = new System.Drawing.Size(93, 31);
            this.btnDetailsOrder.TabIndex = 39;
            this.btnDetailsOrder.Text = "Chi tiết";
            this.btnDetailsOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailsOrder.UseVisualStyleBackColor = true;
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateOrder.Image")));
            this.btnUpdateOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateOrder.Location = new System.Drawing.Point(635, 21);
            this.btnUpdateOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(93, 31);
            this.btnUpdateOrder.TabIndex = 38;
            this.btnUpdateOrder.Text = " Cập nhật";
            this.btnUpdateOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteOrder.Image")));
            this.btnDeleteOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteOrder.Location = new System.Drawing.Point(736, 21);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(93, 31);
            this.btnDeleteOrder.TabIndex = 37;
            this.btnDeleteOrder.Text = "Xóa";
            this.btnDeleteOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOrder.Image")));
            this.btnAddOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOrder.Location = new System.Drawing.Point(544, 21);
            this.btnAddOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(83, 32);
            this.btnAddOrder.TabIndex = 36;
            this.btnAddOrder.Text = " Mới";
            this.btnAddOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvOrder.Location = new System.Drawing.Point(21, 76);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(912, 330);
            this.dgvOrder.TabIndex = 31;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Mã đơn hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CustomerName";
            this.Column2.HeaderText = "Tên khách hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OnOrder";
            this.Column3.HeaderText = "Ngày đặt hàng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Confirm";
            this.Column4.HeaderText = "Xác nhận thông tin";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "EmpName";
            this.Column5.HeaderText = "Nhân viên trực ca";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Chọn ngày:";
            // 
            // pnlSales
            // 
            this.pnlSales.Controls.Add(this.panel1);
            this.pnlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSales.Location = new System.Drawing.Point(0, 0);
            this.pnlSales.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Size = new System.Drawing.Size(979, 512);
            this.pnlSales.TabIndex = 1;
            // 
            // dtpPickADay
            // 
            this.dtpPickADay.Location = new System.Drawing.Point(98, 29);
            this.dtpPickADay.Name = "dtpPickADay";
            this.dtpPickADay.Size = new System.Drawing.Size(200, 22);
            this.dtpPickADay.TabIndex = 46;
            // 
            // lblsale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 512);
            this.Controls.Add(this.pnlSales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "lblsale";
            this.Text = "lblsale";
            this.Load += new System.EventHandler(this.lblsale_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.pnlSales.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlSales;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnDetailsOrder;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DateTimePicker dtpPickADay;
    }
}