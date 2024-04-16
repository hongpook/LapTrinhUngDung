namespace Project
{
    partial class lblEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lblEmployee));
            this.tabDepartment = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tblEmployee = new System.Windows.Forms.DataGridView();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button29 = new System.Windows.Forms.Button();
            this.btnUpdate_em = new System.Windows.Forms.Button();
            this.btnDelete_em = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.searchEmployee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_department = new System.Windows.Forms.TabPage();
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchDe = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtsearchDe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabDepartment.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployee)).BeginInit();
            this.tab_department.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDepartment
            // 
            this.tabDepartment.Controls.Add(this.tabPage1);
            this.tabDepartment.Controls.Add(this.tab_department);
            this.tabDepartment.Location = new System.Drawing.Point(9, 15);
            this.tabDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.tabDepartment.Name = "tabDepartment";
            this.tabDepartment.SelectedIndex = 0;
            this.tabDepartment.Size = new System.Drawing.Size(963, 496);
            this.tabDepartment.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tblEmployee);
            this.tabPage1.Controls.Add(this.button29);
            this.tabPage1.Controls.Add(this.btnUpdate_em);
            this.tabPage1.Controls.Add(this.btnDelete_em);
            this.tabPage1.Controls.Add(this.button37);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.searchEmployee);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(955, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhân viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tblEmployee
            // 
            this.tblEmployee.AllowUserToAddRows = false;
            this.tblEmployee.AllowUserToDeleteRows = false;
            this.tblEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.FirstName,
            this.LastName,
            this.Sex,
            this.DateOfBirth,
            this.Address,
            this.Phone,
            this.DepartName,
            this.UserName,
            this.Password});
            this.tblEmployee.Location = new System.Drawing.Point(12, 101);
            this.tblEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.tblEmployee.MultiSelect = false;
            this.tblEmployee.Name = "tblEmployee";
            this.tblEmployee.ReadOnly = true;
            this.tblEmployee.RowHeadersWidth = 51;
            this.tblEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEmployee.Size = new System.Drawing.Size(917, 339);
            this.tblEmployee.TabIndex = 45;
            this.tblEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblEmployee_CellContentClick);
            // 
            // EmployeeId
            // 
            this.EmployeeId.DataPropertyName = "EmployeeId";
            this.EmployeeId.HeaderText = "Mã nhân viên";
            this.EmployeeId.MinimumWidth = 6;
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "Họ";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Tên";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.HeaderText = "Giới tính";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "Ngày sinh";
            this.DateOfBirth.MinimumWidth = 6;
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Địa chỉ";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Số điện thoại";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // DepartName
            // 
            this.DepartName.DataPropertyName = "DepartmentName";
            this.DepartName.HeaderText = "Vị trí";
            this.DepartName.MinimumWidth = 6;
            this.DepartName.Name = "DepartName";
            this.DepartName.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Tài khoản";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Mật khẩu";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // button29
            // 
            this.button29.Image = ((System.Drawing.Image)(resources.GetObject("button29.Image")));
            this.button29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button29.Location = new System.Drawing.Point(836, 46);
            this.button29.Margin = new System.Windows.Forms.Padding(4);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(93, 31);
            this.button29.TabIndex = 40;
            this.button29.Text = " Chi tiết";
            this.button29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click_2);
            // 
            // btnUpdate_em
            // 
            this.btnUpdate_em.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate_em.Image")));
            this.btnUpdate_em.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate_em.Location = new System.Drawing.Point(590, 46);
            this.btnUpdate_em.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate_em.Name = "btnUpdate_em";
            this.btnUpdate_em.Size = new System.Drawing.Size(93, 31);
            this.btnUpdate_em.TabIndex = 39;
            this.btnUpdate_em.Text = "Cập nhật";
            this.btnUpdate_em.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate_em.UseVisualStyleBackColor = true;
            this.btnUpdate_em.Click += new System.EventHandler(this.btnUpdate_em_Click);
            // 
            // btnDelete_em
            // 
            this.btnDelete_em.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete_em.Image")));
            this.btnDelete_em.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete_em.Location = new System.Drawing.Point(713, 46);
            this.btnDelete_em.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete_em.Name = "btnDelete_em";
            this.btnDelete_em.Size = new System.Drawing.Size(93, 31);
            this.btnDelete_em.TabIndex = 38;
            this.btnDelete_em.Text = "Xóa  ";
            this.btnDelete_em.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete_em.UseVisualStyleBackColor = true;
            this.btnDelete_em.Click += new System.EventHandler(this.btnDelete_em_Click);
            // 
            // button37
            // 
            this.button37.Image = ((System.Drawing.Image)(resources.GetObject("button37.Image")));
            this.button37.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button37.Location = new System.Drawing.Point(477, 45);
            this.button37.Margin = new System.Windows.Forms.Padding(4);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(83, 32);
            this.button37.TabIndex = 37;
            this.button37.Text = "Mới  ";
            this.button37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchEmployee
            // 
            this.searchEmployee.Location = new System.Drawing.Point(12, 50);
            this.searchEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.searchEmployee.Name = "searchEmployee";
            this.searchEmployee.Size = new System.Drawing.Size(241, 22);
            this.searchEmployee.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tìm kiếm tên nhân viên";
            // 
            // tab_department
            // 
            this.tab_department.Controls.Add(this.dgvDepartment);
            this.tab_department.Controls.Add(this.groupBox1);
            this.tab_department.Location = new System.Drawing.Point(4, 25);
            this.tab_department.Margin = new System.Windows.Forms.Padding(4);
            this.tab_department.Name = "tab_department";
            this.tab_department.Padding = new System.Windows.Forms.Padding(4);
            this.tab_department.Size = new System.Drawing.Size(955, 467);
            this.tab_department.TabIndex = 1;
            this.tab_department.Text = "Vị trí(Chức vụ)";
            this.tab_department.UseVisualStyleBackColor = true;
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.AllowUserToAddRows = false;
            this.dgvDepartment.AllowUserToDeleteRows = false;
            this.dgvDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartment.Location = new System.Drawing.Point(19, 133);
            this.dgvDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.ReadOnly = true;
            this.dgvDepartment.RowHeadersWidth = 51;
            this.dgvDepartment.Size = new System.Drawing.Size(908, 307);
            this.dgvDepartment.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchDe);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txtsearchDe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(907, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vị trí(Chức vụ)";
            // 
            // searchDe
            // 
            this.searchDe.Location = new System.Drawing.Point(371, 58);
            this.searchDe.Margin = new System.Windows.Forms.Padding(4);
            this.searchDe.Name = "searchDe";
            this.searchDe.Size = new System.Drawing.Size(87, 28);
            this.searchDe.TabIndex = 37;
            this.searchDe.Text = "Tìm";
            this.searchDe.UseVisualStyleBackColor = true;
            this.searchDe.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(689, 57);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 31);
            this.button2.TabIndex = 36;
            this.button2.Text = "Xóa";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(568, 56);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 32);
            this.button3.TabIndex = 35;
            this.button3.Text = "Mới";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtsearchDe
            // 
            this.txtsearchDe.Location = new System.Drawing.Point(121, 61);
            this.txtsearchDe.Margin = new System.Windows.Forms.Padding(4);
            this.txtsearchDe.Name = "txtsearchDe";
            this.txtsearchDe.Size = new System.Drawing.Size(228, 22);
            this.txtsearchDe.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên vị trí";
            // 
            // lblEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 512);
            this.Controls.Add(this.tabDepartment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "lblEmployee";
            this.Text = "lblEmployee";
            this.Load += new System.EventHandler(this.lblEmployee_Load_1);
            this.tabDepartment.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployee)).EndInit();
            this.tab_department.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDepartment;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tab_department;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDepartment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtsearchDe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button btnUpdate_em;
        private System.Windows.Forms.Button btnDelete_em;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView tblEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.Button searchDe;
    }
}