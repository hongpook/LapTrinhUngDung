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
    public partial class frmDepartment : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public Department Department { get; set; }
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Department de = new Department();
            if (txtname.TextLength == 0)
            {
                MessageBox.Show("Mục này không được bỏ trống","Thông báo");
            }
            else
            {

                de.DepartmentName = txtname.Text;
                db.Departments.InsertOnSubmit(de);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
