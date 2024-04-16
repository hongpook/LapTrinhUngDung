using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Main : Form
    {
        public static string Username = string.Empty;
        public static string _quyen = string.Empty;
        DbContextDataContext db = new DbContextDataContext();
        public Employee Employee { get; set; }
        public Main()
        {
            InitializeComponent();
            


        }

        //private void tmTime_Tick(object sender, EventArgs e)
        //{
        //    var now = DateTime.Now;
        //    lblTime.Text = String.Format("{0:HH:mm:ss}", now);
        //}

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedIndex == 0)
        //    {

        //        this.pnlMain.Controls.Clear();

        //        lblCar lblC = new lblCar();
        //        lblC.TopLevel = false;

        //        // Gắn vào panel
        //        this.pnlMain.Controls.Add(lblC);

        //        // Hiển thị form
        //        lblC.Show();
        //    }
        //    if (comboBox1.SelectedIndex == 1)
        //    {
        //        this.pnlMain.Controls.Clear();

        //        lblCustomer lblCustom = new lblCustomer();
        //        lblCustom.TopLevel = false;

        //        // Gắn vào panel
        //        this.pnlMain.Controls.Add(lblCustom);

        //        // Hiển thị form
        //        lblCustom.Show();
        //    }
        //    if (comboBox1.SelectedIndex == 2)
        //    {
        //        this.pnlMain.Controls.Clear();

        //        lblsale lblS = new lblsale();
        //        lblS.TopLevel = false;

        //        // Gắn vào panel
        //        this.pnlMain.Controls.Add(lblS);

        //        // Hiển thị form
        //        lblS.Show();
        //    }
        //    if (comboBox1.SelectedIndex == 3)
        //    {
        //        if (_quyen == "HR")
        //        {
        //            this.pnlMain.Controls.Clear();

        //            lblEmployee lblE = new lblEmployee();
        //            lblE.TopLevel = false;

        //            // Gắn vào panel
        //            this.pnlMain.Controls.Add(lblE);

        //            // Hiển thị form
        //            lblE.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //        }
        //    }
        //    if (comboBox1.SelectedIndex == 4)
        //    {
        //        if (_quyen == "HR")
        //        {
        //            this.pnlMain.Controls.Clear();

        //            lblRevenue lblR = new lblRevenue();
        //            lblR.TopLevel = false;

        //            // Gắn vào panel
        //            this.pnlMain.Controls.Add(lblR);

        //            // Hiển thị form
        //            lblR.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //        }
        //    }

        //}

        private void lblChange_Click(object sender, EventArgs e)
        {
            frmEmployeeChange frmEC = new frmEmployeeChange();
            frmEC.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Load_Main();
            OpenChildForm(new lblCar());
        }

        private void Load_Main()
        {
            this.pnlMain.Controls.Clear();

            //frmWellcome frmW = new frmWellcome();
            //frmW.TopLevel = false;

            // Gắn vào panel
            //this.pnlMain.Controls.Add(frmW);

            //// Hiển thị form
            //frmW.Show();

            var employees = (from em in db.Employees
                             where em.UserName == Username
                             select em).SingleOrDefault();

            //txtDept.Text = employees.DepartmentName.ToString();
            txtFullName.Text = employees.FirstName.ToString() + " " + employees.LastName.ToString();
            //txtUserName.Text = employees.UserName.ToString();
            //txtBirthDay.Text = employees.DateOfBirth.ToShortDateString();
            //try
            //{
            //    pbxPhoto.Image = ByteToImage(employees.Photo.ToArray());
            //}
            //catch (Exception)
            //{


            //}
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfiles frmP = new frmProfiles();
            frmP.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLoguot_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Hide();
                frmLogin frmL = new frmLogin();
                frmL.Show();
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ 0394421371","Hệ thống",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            frmEmployeeChange frmC = new frmEmployeeChange();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                Load_Main();
            }
        }

        #region tab
        private Form currentFormChild;
        private void OpenChildForm(Form ChildFrom)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = ChildFrom;
            ChildFrom.TopLevel = false;
            ChildFrom.FormBorderStyle = FormBorderStyle.None;
            ChildFrom.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ChildFrom);
            ChildFrom.BringToFront();
            ChildFrom.Show();

        }
        private void btn_ShowSP_Click(object sender, EventArgs e)
        {
            panel_Side.Height = btn_ShowSP.Height;
            panel_Side.Top = btn_ShowSP.Top;

            this.pnlMain.Controls.Clear();

            lblCar lblC = new lblCar();
            lblC.TopLevel = false;

            // Gắn vào panel
            this.pnlMain.Controls.Add(lblC);

            // Hiển thị form
            lblC.Show();
        }

        private void btn_ShowKH_Click(object sender, EventArgs e)
        {
            panel_Side.Height = btn_ShowKH.Height;
            panel_Side.Top = btn_ShowKH.Top;
            this.pnlMain.Controls.Clear();

            lblCustomer lblCustom = new lblCustomer();
            lblCustom.TopLevel = false;

            // Gắn vào panel
            this.pnlMain.Controls.Add(lblCustom);

            // Hiển thị form
            lblCustom.Show();
        }

        private void btn_ShowHD_Click(object sender, EventArgs e)
        {
            panel_Side.Height = btn_ShowHD.Height;
            panel_Side.Top = btn_ShowHD.Top;
            this.pnlMain.Controls.Clear();

            lblsale lblS = new lblsale();
            lblS.TopLevel = false;

            // Gắn vào panel
            this.pnlMain.Controls.Add(lblS);

            // Hiển thị form
            lblS.Show();
        }

        private void btn_ShowNV_Click(object sender, EventArgs e)
        {
            
            if (_quyen == "HR")
            {
                panel_Side.Height = btn_ShowNV.Height;
                panel_Side.Top = btn_ShowNV.Top;
                this.pnlMain.Controls.Clear();

                lblEmployee lblE = new lblEmployee();
                lblE.TopLevel = false;

                // Gắn vào panel
                this.pnlMain.Controls.Add(lblE);

                // Hiển thị form
                lblE.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btn_ShowDT_Click(object sender, EventArgs e)
        {
            
            if (_quyen == "HR")
            {

                panel_Side.Height = btn_ShowDT.Height;
                panel_Side.Top = btn_ShowDT.Top;
                this.pnlMain.Controls.Clear();

                lblRevenue lblR = new lblRevenue();
                lblR.TopLevel = false;

                // Gắn vào panel
                this.pnlMain.Controls.Add(lblR);

                // Hiển thị form
                lblR.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion
    }
}
