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
    public partial class frmCustomer : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public Customer Customer { get; set; }
        public static bool Detail = false;
        bool edit = false;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string err = "";
            if (txtaddress.TextLength==0)
            {
                err +="\nAddress không được bỏ trống";
            }
            DateTime date = new DateTime(2002, 12, 12);
            if (Convert.ToDateTime(dtpDate.Value) > date)
            {
                err += "\nNhân viên chưa đủ 18 tuổi";
            }
            if (txtFisrtName.TextLength==0)
            {
                err += "\nFirstName không được bỏ trống";
            }
            if (txtLastName.TextLength==0)
            {
                err +="\nLastName không được bỏ trống";
            }
            if (txtphone.TextLength==0)
            {
                err += "\nPhone không được bỏ trống";
            }
            else if (txtphone.TextLength < 10 || txtphone.TextLength > 11)
            {
                err += "\nSố điện thoại không đúng định dạng (số điện thoại chỉ có 10 số)";
            }
            else
            {
                try
                {
                    int sdt;
                    sdt = Convert.ToInt32(txtphone.Text);
                }
                catch (Exception)
                {

                    err +="\nPhone không đúng định dạng";
                }
            }
            if (err.Length==0)
            {
                if (edit)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var oldMan = (from om in db.Customers
                                      where om.CustomerID == Customer.CustomerID
                                      select om).SingleOrDefault();
                        oldMan.FirstName = txtFisrtName.Text;
                        oldMan.LastName = txtLastName.Text;
                        oldMan.Sex = rdomale.Checked ? true : false;


                        oldMan.DateOfBirth = DateTime.ParseExact(dtpDate.Text, "dd/MM/yyyy", null);
                        oldMan.Address = txtaddress.Text;
                        oldMan.Phone = Convert.ToInt32(txtphone.Text);

                        try
                        {

                            db.SubmitChanges();
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                else
                {
                    Customer m = new Customer();
                    m.FirstName = txtFisrtName.Text;
                    m.LastName = txtLastName.Text;
                    bool gender = true;
                    if (rdomale.Checked)
                    {
                        gender = true;
                    }
                    if (rdofmale.Checked)
                    {
                        gender = false;
                    }
                    m.Sex = gender;
                    //m.DateOfBirth = DateTime.ParseExact(dtpDate.Text, "dd/MM/yyyy", null);
                    m.DateOfBirth = dtpDate.Value.Date;
                    m.Address = txtaddress.Text;
                    m.Phone = Convert.ToInt32(txtphone.Text);
                    db.Customers.InsertOnSubmit(m);
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show(err,"Thông báo");
            }
            
        }

        public void load_formCustomer()
        {

        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                edit = true;
                txtFisrtName.Text = Customer.FirstName;
                txtLastName.Text = Customer.LastName;
                if (Customer.Sex == true)
                {
                    rdomale.Checked = true;
                }
                else
                {
                    rdofmale.Checked = true;
                }
                dtpDate.Text = Customer.DateOfBirth.ToString();
                txtaddress.Text = Customer.Address;
                txtphone.Text = Customer.Phone.ToString();
            }
            if (Detail)
            {
                btnAccept.Enabled = false;
            }
        }

        
    }
}
