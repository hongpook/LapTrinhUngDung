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
    public partial class frmCar : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public Car Car { get; set; }
        public List<ServiceDetail> ServiceDetail { get; set; }
        bool edit = false;
        public static bool Detail = false;
        public frmCar()
        {
            InitializeComponent();
        }


        public void Load_Cbo()
        {
            cboModel.DataSource = db.CarModels;
            cboModel.DisplayMember = "ModelName";
            cboModel.ValueMember = "ModelName";
        }

        public void Load_Ser()
        {
            lbxService.DataSource = db.Services;
            lbxService.DisplayMember = "Name";
            lbxService.ValueMember = "ServiceID";
            lbxService.ClearSelected();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                btnAccept.Enabled = true;
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var oldCar = (from c in db.Cars
                                  where c.CarNo == Car.CarNo
                                  select c).SingleOrDefault();

                    var id = Car.CarNo;
                    var _sd = from s in db.ServiceDetails
                              where s.CarNo == id
                              select s;
                    foreach (var item in _sd)
                    {
                        try
                        {
                            db.ServiceDetails.DeleteOnSubmit(item);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    Add_Service(Car.CarNo);

                    string err = "";
                    if (txtName.TextLength == 0)
                    {
                        err += "\nName không được để trống";
                    }
                    if (txtPrice.TextLength == 0)
                    {
                        err += "\nPrice không được để trống";
                    }
                    else
                    {
                        try
                        {
                            double pricee;
                            pricee = Convert.ToDouble(txtPrice.Text);
                        }
                        catch (Exception)
                        {

                            err += "\nPrice không đúng định dạng";
                        }
                    }
                    if (err.Length == 0)
                    {

                        oldCar.ModelName = cboModel.SelectedValue.ToString();
                        oldCar.Name = txtName.Text;
                        oldCar.AddInfor = txtAddInfo.Text;
                        oldCar.Price = Double.Parse(txtPrice.Text);
                        oldCar.Status = cboStatus.Checked ? true : false;

                        try
                        {
                            db.SubmitChanges();
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cập nhật dữ liệu không thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else {
                        MessageBox.Show(err,"Thông báo");
                    }
                }

            }
            else
            {
                btnAccept.Enabled = true;
                string err = "";
                if (txtName.TextLength == 0)
                {
                    err += "\nName không được để trống";
                }
                if (txtPrice.TextLength == 0)
                {
                    err += "\nPrice không được để trống";
                }
                else {
                    try
                    {
                        double pricee;
                        pricee = Convert.ToDouble(txtPrice.Text);
                    }
                    catch (Exception)
                    {

                        err += "\nPrice không đúng định dạng";
                    }
                }
                if (err.Length == 0)
                {
                    Car c = new Car();
                    c.Name = txtName.Text;
                    c.ModelName = cboModel.SelectedValue.ToString();
                    c.AddInfor = txtAddInfo.Text;
                    c.Price = Double.Parse(txtPrice.Text);
                    c.Status = cboStatus.Checked ? true : false;
                    db.Cars.InsertOnSubmit(c);
                    try
                    {
                        db.SubmitChanges();
                        Add_Service(c.CarNo);
                        MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else {
                    MessageBox.Show(err,"Thông báo");
                }
              
            }
        }

        private void Add_Service(long id)
        {
            // Duyet cac service duoc chon
            foreach (var item in lbxService.SelectedItems)
            {
                ServiceDetail sd = new ServiceDetail();
                sd.CarNo = id;
                sd.ServiceID = Convert.ToInt32(((Service)item).ServiceID);
                db.ServiceDetails.InsertOnSubmit(sd);
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void frmCar_Load(object sender, EventArgs e)
        {
            Load_Ser();
            Load_Cbo();
            if (Car != null)
            {
                edit = true;
                txtName.Text = Car.Name;
                txtAddInfo.Text = Car.AddInfor;
                cboModel.SelectedValue = Car.ModelName;
                txtPrice.Text = Car.Price.ToString();
                if (Car.Status == true)
                {
                    cboStatus.Checked = true;
                }
                else
                {
                    cboStatus.Checked = false;
                }
                if (ServiceDetail.Count > 0)
                {
                    Load_Ser();
                    foreach (var item in ServiceDetail)
                    {
                        lbxService.SelectedValue = item.ServiceID;
                    }
                }
                if (Detail)
                {
                    btnAccept.Enabled = false;
                }
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
