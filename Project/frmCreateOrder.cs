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
    public partial class frmCreateOrder : Form
    {
        public static string Username = string.Empty;
        DbContextDataContext db = new DbContextDataContext();
        public List<PurchaseOrderModel> PurchaseOrder { get; set; }
        public static bool Detail = false;
        public frmCreateOrder()
        {
            InitializeComponent();
            PurchaseOrder = new List<PurchaseOrderModel>();
        }

        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            Load_ListCar();
            Load_Customer();
            var employees = (from em in db.Employees
                             where em.UserName == Username
                             select em).SingleOrDefault();
            lblEmpName.Text = employees.FirstName + "" + employees.LastName;
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            frmCarListOrder frmClo = new frmCarListOrder();
            frmClo.listPo = PurchaseOrder;
            frmClo.parent = this;
            if (frmClo.ShowDialog() == DialogResult.OK)
            {
                Load_ListCar();
            }
        }

        private void Load_ListCar()
        {
            if (PurchaseOrder != null)
            {
                //dataGridView1.DataSource = PurchaseOrder;
                dgvListOrder.Rows.Clear();
                foreach (var item in PurchaseOrder)
                {
                    dgvListOrder.Rows.Add(new object[] { item.CarNo, item.Name, item.ModelName, item.Quantity, item.Price });
                }
                dgvListOrder.Refresh();
                double total = 0, totalPrice = 0;
                foreach (var item in PurchaseOrder)
                {
                    total = item.Quantity * item.Price;
                    totalPrice += total;
                }
                lblTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvListOrder.CurrentRow != null)
            {
                var row = dgvListOrder.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                // Tìm bản ghi trong collection
                // var purchaseOrder = PurchaseOrder.SingleOrDefault(x => x.CarNo == id);
                var purchaseOrder = (from po in PurchaseOrder
                                     where po.CarNo == id
                                     select po).SingleOrDefault();
                // Xóa
                PurchaseOrder.Remove(purchaseOrder);
                Load_ListCar();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var employees = (from em in db.Employees
                             where em.UserName == Username
                             select em).SingleOrDefault();
            var EmpId = employees.EmployeeID;
            Order o = new Order();
            o.CustomerID = Convert.ToInt32(cboCustomer.SelectedValue);
            o.OnOrder = dtpDate.Value;
            o.EmployeeID = EmpId;
            o.Request = txtRequest.Text;
            o.Confirmation = rdoConfirm.Checked;
            db.Orders.InsertOnSubmit(o);
            try
            {
                db.SubmitChanges();
                Add_OrderDetail(o.OrderID);
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Add_OrderDetail(long id)
        {
            foreach (var item in PurchaseOrder)
            {
                OrderDetail od = new OrderDetail();
                var row = item;
                od.OrderID = id;
                od.CarNo = Convert.ToInt32(item.CarNo);
                od.Quantity = Convert.ToInt32(item.Quantity);
                db.OrderDetails.InsertOnSubmit(od);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Load_Customer()
        {
            cboCustomer.DataSource = db.Customers;
            cboCustomer.DisplayMember ="FirstName";
            cboCustomer.ValueMember = "CustomerID";
        }

       
    }
}
