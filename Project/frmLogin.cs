using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmLogin : Form
    {
        DbContextDataContext db = new DbContextDataContext();

        public frmLogin()
        {
            InitializeComponent();

            //txtUsername.ForeColor = Color.LightGray;
            //txtUsername.Text = "Tên tài khoản";
            //this.txtUsername.Leave += new System.EventHandler(this.textBox1_Leave);
            //this.txtUsername.Enter += new System.EventHandler(this.textBox1_Enter);

            ////txtPassword.ForeColor = Color.LightGray;
            //txtPassword.Text = "Mật khẩu";
            //this.txtPassword.Leave += new System.EventHandler(this.textBox2_Leave);
            //this.txtPassword.Enter += new System.EventHandler(this.textBox2_Enter);
        }

        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    if (txtUsername.Text == "")
        //    {
        //        txtUsername.Text = "Tên tài khoản";
        //        //txtUsername.ForeColor = Color.Gray;
        //    }
        //}

        //private void textBox1_Enter(object sender, EventArgs e)
        //{
        //    if (txtUsername.Text == "Tên tài khoản")
        //    {
        //        txtUsername.Text = "";
        //        //txtUsername.ForeColor = Color.Black;
        //    }
        //}

        //private void textBox2_Enter(object sender, EventArgs e)
        //{
        //    if (txtPassword.Text == "Mật khẩu")
        //    {
        //        txtPassword.Text = "";
        //        //txtPassword.ForeColor = Color.Black;
        //    }
        //}

        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    if (txtPassword.Text == "")
        //    {
        //        txtPassword.Text = "Mật khẩu";
        //        txtPassword.UseSystemPasswordChar = false;
        //        //txtPassword.ForeColor = Color.Gray;
        //    }
        //}        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    if (txtUsername.Text == "")
        //    {
        //        txtUsername.Text = "Tên tài khoản";
        //        //txtUsername.ForeColor = Color.Gray;
        //    }
        //}

        //private void textBox1_Enter(object sender, EventArgs e)
        //{
        //    if (txtUsername.Text == "Tên tài khoản")
        //    {
        //        txtUsername.Text = "";
        //        //txtUsername.ForeColor = Color.Black;
        //    }
        //}

        //private void textBox2_Enter(object sender, EventArgs e)
        //{
        //    if (txtPassword.Text == "Mật khẩu")
        //    {
        //        txtPassword.Text = "";
        //        //txtPassword.ForeColor = Color.Black;
        //    }
        //}

        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    if (txtPassword.Text == "")
        //    {
        //        txtPassword.Text = "Mật khẩu";
        //        txtPassword.UseSystemPasswordChar = false;
        //        //txtPassword.ForeColor = Color.Gray;
        //    }
        //}


        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var employees = from em in db.Employees
                            select em;
            var emp = (from x in db.Employees
                       where x.UserName == txtUsername.Text && x.Password == txtPassword.Text
                       select x).SingleOrDefault();
            
            if (emp != null)
            {
                var _quyen = (from q in db.Employees
                              where q.UserName == txtUsername.Text
                              select q.DepartmentName).SingleOrDefault();
                Main.Username = txtUsername.Text;
                frmPurchaseOrder.Username = txtUsername.Text;
                frmProfiles.Username = txtUsername.Text;
                frmCreateOrder.Username = txtUsername.Text;
                frmEmployeeChange.Username = txtUsername.Text;
                lblCar._quyen = _quyen;
                lblsale._quyen = _quyen;
                lblCustomer._quyen = _quyen;
                Main._quyen = _quyen;
                this.Hide();
                Main m = new Main();
                m.Show();
            } else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
