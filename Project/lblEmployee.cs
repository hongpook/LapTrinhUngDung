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
    public partial class lblEmployee : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public lblEmployee()
        {
   
            InitializeComponent();
            Load_Employee();
            tblEmployee.AutoGenerateColumns = false;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            frmEmployee frmCus = new frmEmployee();
            if (frmCus.ShowDialog() == DialogResult.OK)
            {
                Load_Employee();
            }
        }

        public void Load_Employee()
        {
            var employee = (from cus in db.Employees
                            select new
                            {
                                EmployeeId = cus.EmployeeID,
                                FirstName = cus.FirstName,
                                LastName = cus.LastName,
                                Sex = (cus.Sex ? "Nam" : "Nữ"),
                                DateOfBirth = cus.DateOfBirth,
                                Address = cus.Address,
                                Phone = cus.Phone,
                                DepartmentName = cus.DepartmentName,
                                UserName = cus.UserName,
                                Password = cus.Password


                            });
            tblEmployee.DataSource = employee;
        }





        private void button35_Click(object sender, EventArgs e)
        {

            if (tblEmployee.CurrentRow != null)
            {
                var row = tblEmployee.CurrentRow;
                var id = row.Cells[0].Value;
                var _em = (from em in db.Employees
                           where em.EmployeeID == Convert.ToInt32(id)
                           select em).SingleOrDefault();
                frmEmployee frmEm = new frmEmployee();
                frmEm.Employee = _em;
                if (frmEm.ShowDialog() == DialogResult.OK)
                {
                    Load_Employee();
                }
            }
        }




        private void lblEmployee_Load(object sender, EventArgs e)
        {
            Load_Employee();
        }

        public void display_Department() {
            var load_department = from de in db.Departments
                                  select de;

            dgvDepartment.DataSource = load_department;
        }

        private void lblEmployee_Load_1(object sender, EventArgs e)
        {
            display_Department();
        }

        private void tblEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_em_Click(object sender, EventArgs e)
        {
            if (tblEmployee.CurrentRow != null)
            {
                var row = tblEmployee.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Customers);
                var _customer = (from x in db.Employees
                                 where x.EmployeeID == id
                                 select x).SingleOrDefault();
                frmEmployee frmM = new frmEmployee();
                frmM.Employee = _customer;
                if (frmM.ShowDialog() == DialogResult.OK)
                {
                    Load_Employee();
                }
            }
        }

        private void btnDelete_em_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (tblEmployee.CurrentRow != null)
                {
                    var id = int.Parse(tblEmployee.CurrentRow.Cells[0].Value.ToString());
                    var man = db.Employees.SingleOrDefault(m => m.EmployeeID == id);

                    db.Employees.DeleteOnSubmit(man);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    Load_Employee();
                }
            }
        }

        private void button29_Click_2(object sender, EventArgs e)
        {
            frmEmployee.Detail = true;
            if (tblEmployee.CurrentRow != null)
            {
                var row = tblEmployee.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                var _man = (from x in db.Employees
                            where x.EmployeeID == id
                            select x).SingleOrDefault();
                frmEmployee frmM = new frmEmployee();
                frmM.Employee = _man;
                frmM.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchEmployee.Text != "")
            {
                var search_man = from cus in db.Employees
                                 where cus.FirstName.Contains( searchEmployee.Text)
                                 select new
                                 {
                                     EmployeeId = cus.EmployeeID,
                                     FirstName = cus.FirstName,
                                     LastName = cus.LastName,
                                     Sex = (cus.Sex ? "Nam" : "Nữ"),
                                     DateOfBirth = cus.DateOfBirth,
                                     Address = cus.Address,
                                     Phone = cus.Phone,
                                     DepartmentName = cus.DepartmentName,
                                     UserName = cus.UserName,
                                     Password = cus.Password
                                 };
                tblEmployee.DataSource = search_man;
            }
            else
            {
                Load_Employee();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDepartment frmDe = new frmDepartment();
            if (frmDe.ShowDialog() == DialogResult.OK)
            {
                display_Department();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvDepartment.CurrentRow != null)
                {
                    var name = dgvDepartment.CurrentRow.Cells[0].Value;
                    var de = db.Departments.SingleOrDefault(d => d.DepartmentName == name);

                    db.Departments.DeleteOnSubmit(de);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    display_Department();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (searchDe.Text != "")
            {
                var searchDe = from de in db.Departments
                                 where de.DepartmentName.Contains(txtsearchDe.Text)
                                 select de;
                dgvDepartment.DataSource = searchDe;
            }
            else
            {
                display_Department();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
           
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.Refresh();
            frmPrint print = new frmPrint();
            frmPrint.employee = true;
            print.ShowDialog();
        }
    }
}
