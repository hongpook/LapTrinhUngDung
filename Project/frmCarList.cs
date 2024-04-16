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
    public partial class frmCarList : Form
    {
        public static bool update;
        public frmPurchaseOrder parent { get; set; }

        public frmPurchaseOrderUpdate parent1 { get; set; }
        
        public List<PurchaseOrderModel> listPo { get; set; }
        DbContextDataContext db = new DbContextDataContext();
        public frmCarList()
        {
            InitializeComponent();
            dgvListCar.AutoGenerateColumns = false;
            if (listPo == null)
            {
                listPo = new List<PurchaseOrderModel>();
            }
        }

        private void frmCarList_Load(object sender, EventArgs e)
        {
            var _car = from c in db.Cars
                       select c;
            dgvListCar.DataSource = _car;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text != null)
            {
                var row = dgvListCar.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                var quantity = Convert.ToInt32(txtQuantity.Text);
                var check = false;

                foreach (var item in listPo)
                {
                    if (item.CarNo == id)
                    {
                        item.Quantity += quantity;
                        check = true;
                        break;
                    }
                }
                if (!check)// Không bị trùng
                {
                    var name = row.Cells[1].Value.ToString();
                    var modelName = row.Cells[2].Value.ToString();
                    var price = Convert.ToDouble(txtPrice.Text);

                    //frmPurchaseOrder frmPO = new frmPurchaseOrder();
                    PurchaseOrderModel Po = new PurchaseOrderModel();
                    Po.CarNo = id;
                    Po.Name = name;
                    Po.ModelName = modelName;
                    Po.Price = price;
                    Po.Quantity = quantity;

                    listPo.Add(Po);
                }
                if (update)
                {
                    parent1.ListPurchaseOrder = listPo;
                    frmPurchaseOrderUpdate.check_data = true;                    
                }else
                {
                    parent.PurchaseOrder = listPo;
                }
                
               
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show("Bạn chưa nhập số lượng!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            
        }
    }
}
