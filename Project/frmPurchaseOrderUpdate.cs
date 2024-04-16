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
    public partial class frmPurchaseOrderUpdate : Form
    {
        public static bool check_data;
        public static bool detail;
        DbContextDataContext db = new DbContextDataContext();
        public PurchaseOrder PurchaseOrder { get; set; }

        public List<PurchaseOrderModel> ListPurchaseOrder { get; set; }
        public frmPurchaseOrderUpdate()
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
                if (PurchaseOrder != null)
                {
                    //MessageBox.Show("có dữ liệu");
                    lblIdPurchaseID.Text = PurchaseOrder.PurchaseOrderID.ToString();
                    dtpDate.Text = PurchaseOrder.Date.ToString();
                    var EmpName = (from n in db.Employees
                                   where n.EmployeeID == PurchaseOrder.EmployeeID
                                   select n).SingleOrDefault();
                    lblEmpName.Text = EmpName.FirstName + " " + EmpName.LastName;

                    ListPurchaseOrder = (from dt in db.PurchaseOrderDetails
                                    join c in db.Cars on dt.CarNo equals c.CarNo
                                    where dt.PurchaseOrderID == PurchaseOrder.PurchaseOrderID
                                    select new PurchaseOrderModel
                                    {
                                        CarNo = c.CarNo,
                                        Name = c.Name,
                                        ModelName = c.ModelName,
                                        Quantity = dt.Quantity,
                                        Price = dt.Price
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
                dgvPurchaseCar.Rows.Clear();
                foreach (var item in ListPurchaseOrder)
                {
                    dgvPurchaseCar.Rows.Add(new object[] { item.CarNo, item.Name, item.ModelName, item.Quantity, item.Price });
                }
                dgvPurchaseCar.Refresh();
                double total = 0, totalPrice = 0;
                foreach (var item in ListPurchaseOrder)
                {
                    total = item.Quantity * item.Price;
                    totalPrice += total;
                }
                lblTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void frmPurchaseOrderUpdate_Load(object sender, EventArgs e)
        {
            if (detail)
            {
                btnAccept.Enabled = false;
            }
            Load_From();
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            frmCarList frmCl = new frmCarList();
            frmCl.parent1 = this;
            frmCl.listPo = ListPurchaseOrder;
            if (frmCl.ShowDialog() == DialogResult.OK)
            {
                Load_From();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var oldPurchaseOrderDetail = from p in db.PurchaseOrderDetails
                                             where p.PurchaseOrderID == PurchaseOrder.PurchaseOrderID
                                             select p;
                foreach (var item in oldPurchaseOrderDetail)
                {
                    try
                    {
                        db.PurchaseOrderDetails.DeleteOnSubmit(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                try
                {
                    Add_PurchaseOrderDetail(PurchaseOrder.PurchaseOrderID);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCarList.update = false;
                    check_data = false;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật dữ liệu không thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Add_PurchaseOrderDetail(long id)
        {
            foreach (var item in ListPurchaseOrder)
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseCar.CurrentRow != null && MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var row = dgvPurchaseCar.CurrentRow;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
