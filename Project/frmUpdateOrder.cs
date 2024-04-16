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
    public partial class frmUpdateOrder : Form
    {
        public static bool check_data;
        public static bool detail;
        DbContextDataContext db = new DbContextDataContext();
        public Order Order { get; set; }

        public List<PurchaseOrderModel> ListPurchaseOrder { get; set; }
        public frmUpdateOrder()
        {
            InitializeComponent();
            ListPurchaseOrder = new List<PurchaseOrderModel>();
        }
       

        public void Load_From()
        {
            if (check_data)
            {
                Load_Data();
            }
            else
            {
                if (Order != null)
                {
                    //MessageBox.Show("có dữ liệu");
                    lblOrderId.Text = Order.OrderID.ToString();
                    dtpDate.Text = Order.OnOrder.ToString();
                    var CusName = (from c in db.Customers
                                   where c.CustomerID == Order.CustomerID
                                   select c).SingleOrDefault();
                    //MessageBox.Show(CusName.FirstName);
                    lblCustomerName.Text =CusName.LastName + " " + CusName.FirstName;
                    if (Order.Confirmation == true)
                    {
                        rdoConfirm.Checked = true;
                    } else
                    {
                        rdoConfirm.Checked = false;
                    }

                    var EmpName = (from n in db.Employees
                                   where n.EmployeeID == Order.EmployeeID
                                   select n).SingleOrDefault();
                    lblEmpName.Text = EmpName.FirstName + " " + EmpName.LastName;

                    ListPurchaseOrder = (from dt in db.OrderDetails
                                         join c in db.Cars on dt.CarNo equals c.CarNo
                                         where dt.OrderID == Order.OrderID
                                         select new PurchaseOrderModel
                                         {
                                             CarNo = c.CarNo,
                                             Name = c.Name,
                                             ModelName = c.ModelName,
                                             Quantity = dt.Quantity,
                                             Price = c.Price
                                         }).ToList();
                    Load_Data();
                    double total = 0, totalPrice = 0;
                    foreach (var item in ListPurchaseOrder)
                    {
                        total = item.Quantity * item.Price;
                        totalPrice += total;
                    }
                    lblTotalPrice.Text = totalPrice.ToString();
                }
            }
        }

        public void Load_Data()
        {
            if (ListPurchaseOrder != null)
            {
                //dataGridView1.DataSource = PurchaseOrder;
                dgvListOrder.Rows.Clear();
                foreach (var item in ListPurchaseOrder)
                {
                    dgvListOrder.Rows.Add(new object[] { item.CarNo, item.Name, item.ModelName, item.Quantity, item.Price });
                }
                dgvListOrder.Refresh();
                double total = 0, totalPrice = 0;
                foreach (var item in ListPurchaseOrder)
                {
                    total = item.Quantity * item.Price;
                    totalPrice += total;
                }
                lblTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void frmUpdateOrder_Load(object sender, EventArgs e)
        {
            if (detail)
            {
                btnAccept.Enabled = false;
            }
            Load_From();
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            frmCarListOrder frmClo = new frmCarListOrder();
            frmClo.listPo = ListPurchaseOrder;
            frmClo.parent1 = this;
            if (frmClo.ShowDialog() == DialogResult.OK)
            {
                Load_From();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvListOrder.CurrentRow != null && MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var row = dgvListOrder.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                // Tìm bản ghi trong collection
                // var purchaseOrder = PurchaseOrder.SingleOrDefault(x => x.CarNo == id);
                var _purchaseOrder = (from po in ListPurchaseOrder
                                      where po.CarNo == id
                                      select po).SingleOrDefault();
                // Xóa
                ListPurchaseOrder.Remove(_purchaseOrder);
                Load_From();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var oldOrder = (from o in db.Orders
                                where o.OrderID == Order.OrderID
                                select o).SingleOrDefault();
                
                oldOrder.CustomerID = Convert.ToInt32(lblOrderId.Text);
                oldOrder.OnOrder = dtpDate.Value;
                oldOrder.EmployeeID = Order.EmployeeID;
                oldOrder.Request = txtRequest.Text;
                oldOrder.Confirmation = rdoConfirm.Checked;
                //var oldOrderDetail = from p in db.OrderDetails
                //                     where p.OrderID == Order.OrderID
                //                     select p;
                try
                {
                    db.SubmitChanges();
                    Update_Product(Order.OrderID);
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Update_Product(long id)
        {
            var oldOrderDetail = from p in db.OrderDetails
                                 where p.OrderID == Order.OrderID
                                 select p;

            foreach (var item in oldOrderDetail)
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

            try
            {
                Add_OrderDetail(Order.OrderID); ;
                //MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCarList.update = false;
                check_data = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật dữ liệu không thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Add_OrderDetail(long id)
        {
            foreach (var item in ListPurchaseOrder)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
