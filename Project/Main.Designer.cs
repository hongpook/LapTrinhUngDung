namespace Project
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Side = new System.Windows.Forms.Panel();
            this.btn_ShowDT = new System.Windows.Forms.Button();
            this.btn_ShowNV = new System.Windows.Forms.Button();
            this.btn_ShowHD = new System.Windows.Forms.Button();
            this.btn_ShowKH = new System.Windows.Forms.Button();
            this.btn_ShowSP = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtFullName = new System.Windows.Forms.Label();
            this.tmTime = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoguot = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel_Side);
            this.panel1.Controls.Add(this.btn_ShowDT);
            this.panel1.Controls.Add(this.btn_ShowNV);
            this.panel1.Controls.Add(this.btn_ShowHD);
            this.panel1.Controls.Add(this.btn_ShowKH);
            this.panel1.Controls.Add(this.btn_ShowSP);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 596);
            this.panel1.TabIndex = 2;
            // 
            // panel_Side
            // 
            this.panel_Side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.panel_Side.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Side.Location = new System.Drawing.Point(83, 135);
            this.panel_Side.Name = "panel_Side";
            this.panel_Side.Size = new System.Drawing.Size(10, 48);
            this.panel_Side.TabIndex = 72;
            // 
            // btn_ShowDT
            // 
            this.btn_ShowDT.FlatAppearance.BorderSize = 0;
            this.btn_ShowDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowDT.Location = new System.Drawing.Point(93, 327);
            this.btn_ShowDT.Name = "btn_ShowDT";
            this.btn_ShowDT.Size = new System.Drawing.Size(224, 48);
            this.btn_ShowDT.TabIndex = 71;
            this.btn_ShowDT.Text = "Doanh thu";
            this.btn_ShowDT.UseVisualStyleBackColor = true;
            this.btn_ShowDT.Click += new System.EventHandler(this.btn_ShowDT_Click);
            // 
            // btn_ShowNV
            // 
            this.btn_ShowNV.FlatAppearance.BorderSize = 0;
            this.btn_ShowNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowNV.Location = new System.Drawing.Point(93, 279);
            this.btn_ShowNV.Name = "btn_ShowNV";
            this.btn_ShowNV.Size = new System.Drawing.Size(224, 48);
            this.btn_ShowNV.TabIndex = 70;
            this.btn_ShowNV.Text = "Nhân viên";
            this.btn_ShowNV.UseVisualStyleBackColor = true;
            this.btn_ShowNV.Click += new System.EventHandler(this.btn_ShowNV_Click);
            // 
            // btn_ShowHD
            // 
            this.btn_ShowHD.FlatAppearance.BorderSize = 0;
            this.btn_ShowHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowHD.Location = new System.Drawing.Point(93, 231);
            this.btn_ShowHD.Name = "btn_ShowHD";
            this.btn_ShowHD.Size = new System.Drawing.Size(224, 48);
            this.btn_ShowHD.TabIndex = 69;
            this.btn_ShowHD.Text = "Hóa đơn";
            this.btn_ShowHD.UseVisualStyleBackColor = true;
            this.btn_ShowHD.Click += new System.EventHandler(this.btn_ShowHD_Click);
            // 
            // btn_ShowKH
            // 
            this.btn_ShowKH.FlatAppearance.BorderSize = 0;
            this.btn_ShowKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowKH.Location = new System.Drawing.Point(93, 183);
            this.btn_ShowKH.Name = "btn_ShowKH";
            this.btn_ShowKH.Size = new System.Drawing.Size(224, 48);
            this.btn_ShowKH.TabIndex = 68;
            this.btn_ShowKH.Text = "Khách hàng";
            this.btn_ShowKH.UseVisualStyleBackColor = true;
            this.btn_ShowKH.Click += new System.EventHandler(this.btn_ShowKH_Click);
            // 
            // btn_ShowSP
            // 
            this.btn_ShowSP.FlatAppearance.BorderSize = 0;
            this.btn_ShowSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowSP.Location = new System.Drawing.Point(93, 135);
            this.btn_ShowSP.Name = "btn_ShowSP";
            this.btn_ShowSP.Size = new System.Drawing.Size(224, 48);
            this.btn_ShowSP.TabIndex = 67;
            this.btn_ShowSP.Text = "Sản phẩm";
            this.btn_ShowSP.UseVisualStyleBackColor = true;
            this.btn_ShowSP.Click += new System.EventHandler(this.btn_ShowSP_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(41, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(79, 550);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hỗ trợ khách hàng?\r\n\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox2.Image = global::Project.Properties.Resources.user_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(21, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // txtFullName
            // 
            this.txtFullName.AutoSize = true;
            this.txtFullName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(74, 36);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(72, 23);
            this.txtFullName.TabIndex = 7;
            this.txtFullName.Text = "label2";
            // 
            // tmTime
            // 
            this.tmTime.Enabled = true;
            this.tmTime.Interval = 1000;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.LightYellow;
            this.pnlMain.Location = new System.Drawing.Point(1, 99);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(972, 497);
            this.pnlMain.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel5.Controls.Add(this.btnProfile);
            this.panel5.Controls.Add(this.btnExit);
            this.panel5.Controls.Add(this.btnLoguot);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.txtFullName);
            this.panel5.Location = new System.Drawing.Point(1, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 91);
            this.panel5.TabIndex = 0;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.White;
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProfile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnProfile.Image")));
            this.btnProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProfile.Location = new System.Drawing.Point(705, 7);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(1);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(79, 75);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(885, 7);
            this.btnExit.Margin = new System.Windows.Forms.Padding(1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 75);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoguot
            // 
            this.btnLoguot.BackColor = System.Drawing.Color.White;
            this.btnLoguot.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLoguot.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoguot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoguot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoguot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoguot.Image = ((System.Drawing.Image)(resources.GetObject("btnLoguot.Image")));
            this.btnLoguot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoguot.Location = new System.Drawing.Point(795, 7);
            this.btnLoguot.Margin = new System.Windows.Forms.Padding(1);
            this.btnLoguot.Name = "btnLoguot";
            this.btnLoguot.Size = new System.Drawing.Size(79, 75);
            this.btnLoguot.TabIndex = 0;
            this.btnLoguot.Text = "Logout";
            this.btnLoguot.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoguot.UseVisualStyleBackColor = false;
            this.btnLoguot.Click += new System.EventHandler(this.btnLoguot_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pnlMain);
            this.panel2.Location = new System.Drawing.Point(324, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 596);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1301, 36);
            this.panel3.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 634);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoguot;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Timer tmTime;
        private System.Windows.Forms.Label txtFullName;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_ShowSP;
        private System.Windows.Forms.Panel panel_Side;
        private System.Windows.Forms.Button btn_ShowDT;
        private System.Windows.Forms.Button btn_ShowNV;
        private System.Windows.Forms.Button btn_ShowHD;
        private System.Windows.Forms.Button btn_ShowKH;
    }
}