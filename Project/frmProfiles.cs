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
    public partial class frmProfiles : Form
    {
        public static string Username = string.Empty;
        DbContextDataContext db = new DbContextDataContext();
        public Employee Employee { get; set; }
        public frmProfiles()
        {
            InitializeComponent();
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
        private void frmProfiles_Load(object sender, EventArgs e)
        {
            var employees = (from em in db.Employees
                             where em.UserName == Username
                             select em).SingleOrDefault();

            cboDepartment.Text = employees.DepartmentName.ToString();
            txtFirstName.Text = employees.FirstName.ToString();
            txtLastName.Text = employees.LastName.ToString();
            if (employees.Sex == true)
            {
                rdoMale.Checked = true;
            }
            else
            {
                rdoFemale.Checked = true;
            }
            dtpBirthday.Text = employees.DateOfBirth.ToShortDateString();
            txtPhone.Text = employees.Phone.ToString();
            txtAddress.Text = employees.Address.ToString();
            txtUsername.Text = employees.UserName.ToString();
            txtPassword.Text = employees.Password.ToString();
            try
            {
                ptbImage.Image = ByteToImage(employees.Photo.ToArray());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
