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
    public partial class lblsale : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public static string _quyen = string.Empty;
        public lblsale()
        {
            InitializeComponent();
        }

        private void Load_Order()
        {
            var _order = from o in db.Orders
                         join e in db.Employees on o.EmployeeID equals e.EmployeeID
                         join c in db.Customers on o.CustomerID equals c.CustomerID
                         select new
                                {
                                    Id = o.OrderID,
                                    CustomerName = c.FirstName + " " + c.LastName,
                                    OnOrder = o.OnOrder,
                                    Confirm = o.Confirmation,
                                    EmpName = e.FirstName + " " + e.LastName
                                };
            dgvOrder.DataSource = _order;
        }

        private void lblsale_Load(object sender, EventArgs e)
        {
            if (_quyen == "Car Manager")
            {
                btnAddOrder.Enabled = false;
                btnUpdateOrder.Enabled = false;
                btnDeleteOrder.Enabled = false;
                btnDetailsOrder.Enabled = false;
            }
                Load_Order();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            frmCreateOrder frmCo = new frmCreateOrder();
            if (frmCo.ShowDialog() == DialogResult.OK)
            {
                Load_Order();
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow != null)
            {
                frmCarListOrder.update = true;
                var row = dgvOrder.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Orders);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.OrderDetails);
                var _order = (from o in db.Orders
                                 where o.OrderID == id
                                 select o).SingleOrDefault();

                //var _serviceDetail = from sd in db.ServiceDetails
                //                     where sd.CarNo == id
                //                     select sd;
                frmUpdateOrder frmUo = new frmUpdateOrder();
                frmUo.Order = _order;
                //frmC.ServiceDetail = _serviceDetail.ToList();
                if (frmUo.ShowDialog() == DialogResult.OK)
                {
                    Load_Order();
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvOrder.CurrentRow != null)
                {
                    var id = int.Parse(dgvOrder.CurrentRow.Cells[0].Value.ToString());

                    var _orderDetail = from o in db.OrderDetails
                                       where o.OrderID == id
                                       select o;
                    foreach (var item in _orderDetail)
                    {
                        try
                        {
                            db.OrderDetails.DeleteOnSubmit(item);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    var _order = db.Orders.SingleOrDefault(o => o.OrderID == id);
                    db.Orders.DeleteOnSubmit(_order);

                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    frmCarList.update = false;
                    Load_Order();
                }
            }
        }

        private void btnReportOrder_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvOrder.CurrentRow.Cells[0].Value);
            //var data = (from od in db.OrderDetails
            //           where od.OrderID == id
            //           select od).SingleOrDefault();
                      
            
            frmPrint print = new frmPrint();
            frmPrint.id = id;
            frmPrint.OrderDetail = true;
            print.ShowDialog();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Load_Order();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dtpPickADay.Value;

            var _order = from o in db.Orders
                         join em in db.Employees on o.EmployeeID equals em.EmployeeID
                         join c in db.Customers on o.CustomerID equals c.CustomerID
                         where o.OnOrder == date
                         select new
                         {
                             Id = o.OrderID,
                             CustomerName = c.FirstName + " " + c.LastName,
                             OnOrder = o.OnOrder,
                             Confirm = o.Confirmation,
                             EmpName = em.FirstName + " " + em.LastName
                         };
            dgvOrder.DataSource = _order;
        }
    }
}
