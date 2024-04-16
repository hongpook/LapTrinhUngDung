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
    public partial class lblCustomer : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public static string _quyen = string.Empty;
        public lblCustomer()
        {
            InitializeComponent();
            load_form_Customer();
            dgvCustomer.AutoGenerateColumns = false;
        }
        public void load_form_Customer() {
            if (_quyen == "Car Manager")
            {
                button37.Enabled = false;
                button35.Enabled = false;
                button36.Enabled = false;
                button29.Enabled = false;
            }

            var customer = from cus in db.Customers
                           select cus;
            dgvCustomer.DataSource = customer;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            frmCustomer frmCus = new frmCustomer();
            if (frmCus.ShowDialog() == DialogResult.OK)
            {
                load_form_Customer();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                var row = dgvCustomer.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Customers);
                var _customer = (from x in db.Customers
                            where x.CustomerID == id
                            select x).SingleOrDefault();
                frmCustomer frmM = new frmCustomer();
                frmM.Customer = _customer;
                if (frmM.ShowDialog() == DialogResult.OK)
                {
                    load_Customer();
                }
            }
        }

        public void load_Customer() {
            var mans = from m in db.Customers
                       select new
                       {
                           CustomerId = m.CustomerID,
                           FirstName = m.FirstName,
                           LastName = m.LastName,
                           Sex = m.Sex,
                           DateOfBirth=m.DateOfBirth,
                           Address=m.Address,
                           Phone=m.Phone
                       };
            dgvCustomer.DataSource = mans;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvCustomer.CurrentRow != null)
                {
                    var id = int.Parse(dgvCustomer.CurrentRow.Cells[0].Value.ToString());
                    var man = db.Customers.SingleOrDefault(m => m.CustomerID == id);

                    db.Customers.DeleteOnSubmit(man);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    load_Customer();
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            frmCustomer.Detail = true;
            if (dgvCustomer.CurrentRow != null)
            {
                var row = dgvCustomer.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                var _man = (from x in db.Customers
                            where x.CustomerID == id
                            select x).SingleOrDefault();
                frmCustomer frmM = new frmCustomer();
                frmM.Customer = _man;
                frmM.Show();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.Refresh();
            frmPrint print = new frmPrint();
            frmPrint.customer = true;
            print.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var search_man = from m in db.Customers
                                 where m.FirstName.Equals(textBox1.Text)
                                 select new
                                 {
                                     CustomerId = m.CustomerID,
                                     FirstName = m.FirstName,
                                     LastName = m.LastName,
                                     Sex = m.Sex,
                                     DateOfBirth = m.DateOfBirth,
                                     Address = m.Address,
                                     Phone = m.Phone
                                 };
                dgvCustomer.DataSource = search_man;
            }
            else
            {
                load_Customer();
            }
        }
    }
}
