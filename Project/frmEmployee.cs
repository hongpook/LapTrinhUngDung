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
    public partial class frmEmployee : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public Employee Employee { get; set; }
        public static bool Detail = false;
        bool edit = false;
        public frmEmployee()
        {
            InitializeComponent();

        }


        public void Load_Cbo()
        {
            cboDepartment.DataSource = db.Departments;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "DepartmentName";
        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
           
            string err = "";
            if (txtAddress.TextLength == 0)
            {
                err += "\nAddress không được để trống";
            }
            if (txtFirstName.TextLength == 0)
            {
                err += "\nFirstName không được để trống";
            }
            if (txtLastName.TextLength == 0)
            {
                err += "\nLastName không được để trống";
            }
            DateTime date = new DateTime(2002, 12, 12);
            if (Convert.ToDateTime(dtpBirthday.Value) > date)
            {
                err += "\nNhân viên chưa đủ 18 tuổi";
            }
            if (txtPassword.TextLength == 0)
            {
                err += "\nPassword không được để trống";
            }
            int sdt;
            if (txtPhone.TextLength == 0)
            {
                err += "\nPhone không được để trống";
            }
            else if (txtPhone.TextLength<10||txtPhone.TextLength>11)
            {
                err += "\nSố điện thoại không đúng định dạng (số điện thoại chỉ có 10 số)";
            }
            else
            {
                try
                {
                    sdt = Convert.ToInt32(txtPhone.Text);
                }
                catch (Exception)
                {

                    err += "\nSố điện thoại không đúng định dạng";
                }

            }
            if (txtUsername.TextLength == 0)
            {
                err += "\nUsername không được để trống";
            }

            if (err.Length == 0)
            {
                if (edit)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var oldMan = (from om in db.Employees
                                      where om.EmployeeID == Employee.EmployeeID
                                      select om).SingleOrDefault();
                        oldMan.FirstName = txtFirstName.Text;
                        oldMan.LastName = txtLastName.Text;
                        oldMan.Sex = rdoMale.Checked ? true : false;
                        oldMan.DateOfBirth = DateTime.ParseExact(dtpBirthday.Text, "dd/MM/yyyy", null);
                        oldMan.Address = txtAddress.Text;
                        oldMan.Phone = Convert.ToInt32(txtPhone.Text);
                        oldMan.DepartmentName = cboDepartment.Text;
                        oldMan.UserName = txtUsername.Text;
                        oldMan.Password = txtPassword.Text;
                       
                        try
                        {
                            Bitmap bmpPhoto = new Bitmap(pbxPhoto.Image);
                            ImageConverter converter = new ImageConverter();
                            byte[] output = (byte[])converter.ConvertTo(pbxPhoto.Image, typeof(byte[]));
                            oldMan.Photo = output;
                        }
                        catch (Exception)
                        {


                        }
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
                    Employee m = new Employee();
                    m.FirstName = txtFirstName.Text;
                    m.LastName = txtLastName.Text;
                    m.Sex = rdoMale.Checked ? true : false;
                    m.DateOfBirth =dtpBirthday.Value.Date;
                    m.Address = txtAddress.Text;
                    m.Phone = Convert.ToInt32(txtPhone.Text);
                    m.DepartmentName = cboDepartment.Text;
                    m.UserName = txtUsername.Text;
                    m.Password = txtPassword.Text;

                    try
                    {
                        Bitmap bmpPhoto = new Bitmap(pbxPhoto.Image);
                        ImageConverter converter = new ImageConverter();
                        byte[] output = (byte[])converter.ConvertTo(pbxPhoto.Image, typeof(byte[]));
                        m.Photo = output;
                    }
                    catch (Exception)
                    {


                    }
                    db.Employees.InsertOnSubmit(m);
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
            else {
                MessageBox.Show(err, "Thông báo");
            }
            
        }

        //Hàm chuyển đổi kiểu dữ liệu ảnh
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void frmEmployeee_Load(object sender, EventArgs e)
        {
            Load_Cbo();
            if (Employee != null)
            {
                edit = true;
                cboDepartment.Text = Employee.DepartmentName;
                txtFirstName.Text = Employee.FirstName;
                txtLastName.Text = Employee.LastName;

                if (Employee.Sex == true)
                {
                    rdoMale.Checked = true;
                }
                else
                {
                    rdoFemale.Checked = true;
                }

                dtpBirthday.Text = Employee.DateOfBirth.ToString();
                txtAddress.Text = Employee.Address;
                txtPhone.Text = Employee.Phone.ToString();
                txtUsername.Text = Employee.UserName;
                txtPassword.Text = Employee.Password;

                //hiển thị ảnh
                //ImageConverter converter = new ImageConverter();
                try
                {
                    pbxPhoto.Image = ByteToImage(Employee.Photo.ToArray());
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (Detail)
            {
                btnAddEmployee.Enabled = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;

            }
            else
            {
                try
                {
                    Image img = Image.FromFile(file);
                    pbxPhoto.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
    }
}
