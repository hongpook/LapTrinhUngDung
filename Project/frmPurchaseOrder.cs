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
    public partial class frmPurchaseOrder : Form
    {
        public static string Username = string.Empty;
        DbContextDataContext db = new DbContextDataContext();
        public List<PurchaseOrderModel> PurchaseOrder { get; set; }
        public static bool Detail = false;
        public frmPurchaseOrder()
        {
            InitializeComponent();
            PurchaseOrder = new List<PurchaseOrderModel>();
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            Load_PurchaseOrder();
            var employees = (from em in db.Employees
                             where em.UserName == Username
                             select em).SingleOrDefault();
            lblEmpName.Text = employees.FirstName + " " + employees.LastName;
        }

        public void Load_PurchaseOrder()
        {
            if (PurchaseOrder != null)
            {
                //dataGridView1.DataSource = PurchaseOrder;
                dgvPurchaseCar.Rows.Clear();
                foreach (var item in PurchaseOrder)
                {
                    dgvPurchaseCar.Rows.Add(new object[] { item.CarNo, item.Name, item.ModelName, item.Quantity, item.Price});
                }
                dgvPurchaseCar.Refresh();
                double total = 0, totalPrice = 0;
                foreach (var item in PurchaseOrder)
                {
                    total = item.Quantity * item.Price;
                    totalPrice += total;
                }
                lblTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            frmCarList frmCl = new frmCarList();
            frmCl.listPo = PurchaseOrder;
            frmCl.parent = this;
            if (frmCl.ShowDialog() == DialogResult.OK)
            {
                Load_PurchaseOrder();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseCar.CurrentRow != null)
            {
                var row = dgvPurchaseCar.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                // Tìm bản ghi trong collection
                // var purchaseOrder = PurchaseOrder.SingleOrDefault(x => x.CarNo == id);
                var purchaseOrder = (from po in PurchaseOrder
                                     where po.CarNo == id
                                     select po).SingleOrDefault();
                // Xóa
                PurchaseOrder.Remove(purchaseOrder);
                Load_PurchaseOrder();
            }            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
                var employees = (from em in db.Employees
                                 where em.UserName == Username
                                 select em).SingleOrDefault();
                var EmpId = employees.EmployeeID;
                PurchaseOrder po = new PurchaseOrder();
                po.Date = dtpDate.Value;
                po.EmployeeID = EmpId;
                db.PurchaseOrders.InsertOnSubmit(po);
                try
                {
                    db.SubmitChanges();
                    Add_PurchaseOrderDetail(po.PurchaseOrderID);
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void Add_PurchaseOrderDetail(long id)
        {
            foreach (var item in PurchaseOrder)
            {
                PurchaseOrderDetail po = new PurchaseOrderDetail();
                var row = item;
                po.PurchaseOrderID = id;
                po.CarNo = Convert.ToInt32(item.CarNo);
                po.Quantity = Convert.ToInt32(item.Quantity);
                po.Price = Convert.ToDouble(item.Price);
                db.PurchaseOrderDetails.InsertOnSubmit(po);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
