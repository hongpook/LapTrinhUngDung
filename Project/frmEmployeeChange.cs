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
    public partial class frmEmployeeChange : Form
    {
        public static string Username = string.Empty;
        DbContextDataContext db = new DbContextDataContext();
        public frmEmployeeChange()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            Load_Employee();
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

        public void Load_Employee()
        {
            var employees = (from em in db.Employees
                             where em.UserName == Username
                             select em).SingleOrDefault();

            cboDepartment.Text = employees.DepartmentName;
            txtFirstName.Text = employees.FirstName;
            txtLastName.Text = employees.LastName;

            if (employees.Sex == true)
            {
                rdoMale.Checked = true;
            }
            else
            {
                rdoFemale.Checked = true;
            }

            dtpBirthday.Text = employees.DateOfBirth.ToString();
            txtAddress.Text = employees.Address;
            txtPhone.Text = employees.Phone.ToString();
            txtUsername.Text = employees.UserName;
            txtPassword.Text = employees.Password;

            //hiển thị ảnh
            //ImageConverter converter = new ImageConverter();
            try
            {
                ptbImage.Image = ByteToImage(employees.Photo.ToArray());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       



        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var oldEMp = (from emp in db.Employees
                              where emp.UserName == Username
                              select emp).SingleOrDefault();
                oldEMp.FirstName = txtFirstName.Text;
                oldEMp.LastName = txtLastName.Text;
                oldEMp.Sex = rdoMale.Checked ? true : false;
                oldEMp.DateOfBirth = dtpBirthday.Value;
                oldEMp.Address = txtAddress.Text;
                oldEMp.Phone = Convert.ToInt32(txtPhone.Text);
                oldEMp.DepartmentName = cboDepartment.Text;
                oldEMp.UserName = txtUsername.Text;
                oldEMp.Password = txtPassword.Text;

                try
                {
                    Bitmap bmpPhoto = new Bitmap(ptbImage.Image);
                    ImageConverter converter = new ImageConverter();
                    byte[] output = (byte[])converter.ConvertTo(ptbImage.Image, typeof(byte[]));
                    oldEMp.Photo = output;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    ptbImage.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        
    }
}
