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
    public partial class lblCar : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public static string _quyen = string.Empty;
        public lblCar()
        {
            InitializeComponent();
            dgvCar.AutoGenerateColumns = false;
            dgvPurchase.AutoGenerateColumns = false;
        }

        public void Load_Car()
        {
            //var a = db.totalCar(2);

            var cars = db.Cars.Select(c => new CarViewModel
            {
                CarNo = c.CarNo,
                ModelName = c.ModelName,
                Name = c.Name,
                Price = c.Price,
                Quantity = 0
            }).ToList();
            foreach (var item in cars)
            {
                item.Quantity = db.totalCar(item.CarNo);
            }
            
            dgvCar.DataSource = cars;
        }

        public void Load_Manufactory()
        {
            var mans = from m in db.Manufactories
                       select new
                       {
                           ManufactoryID = m.ManufactoryID,
                           ManufactoryName = m.ManufactoryName,
                           Address = m.Address,
                           Phone = m.Phone
                       };
            dgvMan.DataSource = mans;
        }

        public void lblCar_Load(object sender, EventArgs e)
        {
            if (_quyen == "Sales")
            {
                btnAddCar.Enabled = false;
                btnUpdateCar.Enabled = false;
                btnDeleteCar.Enabled = false;
                btnDetailsCar.Enabled = false;

                btnAddModel.Enabled = false;
                btnUpdateModel.Enabled = false;
                btnDeleteModel.Enabled = false;
                btnDetailsModel.Enabled = false;

                btnAddMan.Enabled = false;
                btnUpdateMan.Enabled = false;
                btnDeleteMan.Enabled = false;
                btnDetailsMan.Enabled = false;

                btnAddPurchase.Enabled = false;
                btnUpdatePurchase.Enabled = false;
                btnDeletePurchase.Enabled = false;
                btnDetailsPurchase.Enabled = false;

                btnAddService.Enabled = false;
                btnUpdateService.Enabled = false;
                btnDeleteService.Enabled = false;
            }

            Load_Car();

           // Load_frmCar();

            Load_CarModel();

            Load_Manufactory();

            Load_Service();

            Load_Purchase();
        }

        public void btnAddMan_Click(object sender, EventArgs e)
        {
            frmMan frmM = new frmMan();
            if (frmM.ShowDialog() == DialogResult.OK)
            {
                Load_Manufactory();
            }
        }

        private void btnUpdateMan_Click(object sender, EventArgs e)
        {
            if (dgvMan.CurrentRow != null)
            {
                var row = dgvMan.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Manufactories);
                var _man = (from x in db.Manufactories
                            where x.ManufactoryID == id
                            select x).SingleOrDefault();
                frmMan frmM = new frmMan();
                frmM.Manufactory = _man;
                if (frmM.ShowDialog() == DialogResult.OK)
                {
                    Load_Manufactory();
                }
            }
        }

        private void btnDeleteMan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvMan.CurrentRow != null)
                {
                    var id = int.Parse(dgvMan.CurrentRow.Cells[0].Value.ToString());
                    var man = db.Manufactories.SingleOrDefault(m => m.ManufactoryID == id);

                    db.Manufactories.DeleteOnSubmit(man);
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    Load_Manufactory();
                }
            }
        }

        private void btnSearchMan_Click(object sender, EventArgs e)
        {
            if (txtSearchMan.Text != "")
            {
                var search_man = from m in db.Manufactories
                                 where m.ManufactoryName.Equals( txtSearchMan.Text)
                                 select new
                                 {
                                     ManufactoryID = m.ManufactoryID,
                                     ManufactoryName = m.ManufactoryName,
                                     Address = m.Address,
                                     Phone = m.Phone
                                 };
                dgvMan.DataSource = search_man;
            }
            else
            {
                Load_Manufactory();
            }

        }

        private void btnDetailsMan_Click(object sender, EventArgs e)
        {
            frmMan.Detail = true;
            if (dgvMan.CurrentRow != null)
            {
                var row = dgvMan.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                var _man = (from x in db.Manufactories
                            where x.ManufactoryID == id
                            select x).SingleOrDefault();
                frmMan frmM = new frmMan();
                frmM.Manufactory = _man;
                frmM.Show();
            }
        }

        public void Load_CarModel()
        {
            var CarM = from c in db.CarModels
                       join m in db.Manufactories on c.ManufactoryID equals m.ManufactoryID
                       select new
                       {
                           ModelName = c.ModelName,
                           ManufactoryName = m.ManufactoryName

                       };
            dgvModel.DataSource = CarM;
        }
        private void btnAddModel_Click(object sender, EventArgs e)
        {
            frmCarModel frmCM = new frmCarModel();
            if (frmCM.ShowDialog() == DialogResult.OK)
            {
                Load_CarModel();
            }
        }

        private void btnUpdateModel_Click(object sender, EventArgs e)
        {
            if (dgvModel.CurrentRow != null)
            {
                var row = dgvModel.CurrentRow;
                var name = row.Cells[0].Value;
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Manufactories);
                var _carModel = (from c in db.CarModels
                                 where c.ModelName == name
                                 select c).SingleOrDefault();
                frmCarModel frmCM = new frmCarModel();
                frmCM.CarModel = _carModel;
                if (frmCM.ShowDialog() == DialogResult.OK)
                {
                    Load_CarModel();
                }
            }
        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvModel.CurrentRow != null)
                {
                    var name = dgvModel.CurrentRow.Cells[0].Value.ToString();
                    var carmodel = db.CarModels.SingleOrDefault(c => c.ModelName == name);

                    db.CarModels.DeleteOnSubmit(carmodel);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    Load_CarModel();
                }
            }
        }

        private void btnDetailsModel_Click(object sender, EventArgs e)
        {
            frmCarModel.Detail = true;
            if (dgvModel.CurrentRow != null)
            {
                var row = dgvModel.CurrentRow;
                var name = row.Cells[0].Value;
                var _carModel = (from c in db.CarModels
                                 where c.ModelName == name
                                 select c).SingleOrDefault();
                frmCarModel frmCM = new frmCarModel();
                frmCM.CarModel = _carModel;
                frmCM.Show();
            }
        }

        public void Load_frmCar()
        {
            var Car = from c in db.Cars
                      join cm in db.CarModels on c.ModelName equals cm.ModelName
                      where c.Status == true
                      select new
                      {
                          CarID = c.CarNo,
                          ModelName = cm.ModelName,
                          Name = c.Name,
                          Price = c.Price
                      };
            dgvCar.DataSource = Car;
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            frmCar frmC = new frmCar();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                Load_frmCar();
            }
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            if (dgvCar.CurrentRow != null)
            {
                var row = dgvCar.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Cars);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.ServiceDetails);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Services);
                var _car = (from c in db.Cars
                            where c.CarNo == id
                            select c).SingleOrDefault();
                var _serviceDetail = from sd in db.ServiceDetails
                                     where sd.CarNo == id
                                     select sd;
                frmCar frmC = new frmCar();
                frmC.Car = _car;
                frmC.ServiceDetail = _serviceDetail.ToList();
                if (frmC.ShowDialog() == DialogResult.OK)
                {
                    Load_frmCar();
                }
            }
        }

        private void btnDetailsCar_Click(object sender, EventArgs e)
        {
            frmCar.Detail = true;
            if (dgvCar.CurrentRow != null)
            {
                var row = dgvCar.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Cars);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.ServiceDetails);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.Services);
                var _car = (from c in db.Cars
                            where c.CarNo == id
                            select c).SingleOrDefault();
                var _serviceDetail = from sd in db.ServiceDetails
                                     where sd.CarNo == id
                                     select sd;
                frmCar frmC = new frmCar();
                frmC.Car = _car;
                frmC.ServiceDetail = _serviceDetail.ToList();
                if (frmC.ShowDialog() == DialogResult.OK)
                {
                    Load_frmCar();
                }
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvCar.CurrentRow != null)
                {
                    var id = int.Parse(dgvCar.CurrentRow.Cells[0].Value.ToString());
                    var _car = db.Cars.SingleOrDefault(c => c.CarNo == id);

                    db.Cars.DeleteOnSubmit(_car);
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    Load_frmCar();
                }
            }
        }

        public void Load_Service()
        {
            var Service = from s in db.Services
                          select new
                          {
                              ID = s.ServiceID,
                              Name = s.Name,
                              Description = s.Description
                          };
            dgvService.DataSource = Service;
        }

        public void Service_Detail()
        {
            if (dgvService.CurrentRow != null)
            {
                var row = dgvService.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                txtNameService.Text = row.Cells[1].Value.ToString();
                txtDesService.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (txtNameService.Text != "")
            {
                Service s = new Service();
                s.Name = txtNameService.Text;
                s.Description = txtDesService.Text;
                db.Services.InsertOnSubmit(s);
                try
                {
                    db.SubmitChanges();
                    if (MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Load_Service();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tên Service không được để trống!");
            }
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var row = dgvService.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                var oldService = (from s in db.Services
                                  where s.ServiceID == id
                                  select s).SingleOrDefault();
                oldService.Name = txtNameService.Text;
                oldService.Description = txtDesService.Text;

                try
                {
                    db.SubmitChanges();
                    if (MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Load_Service();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn không thể thay đổi tên của CarModel", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void dgvService_SelectionChanged(object sender, EventArgs e)
        {
            Service_Detail();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvService.CurrentRow != null)
                {
                    var id = int.Parse(dgvService.CurrentRow.Cells[0].Value.ToString());
                    var _ser = db.Services.SingleOrDefault(s => s.ServiceID == id);

                    db.Services.DeleteOnSubmit(_ser);
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    Load_Service();
                }
            }
        }

        public void Load_Purchase()
        {
            var PurchaseOrder = from p in db.PurchaseOrders
                                join e in db.Employees on p.EmployeeID equals e.EmployeeID
                                select new
                                {
                                    Id = p.PurchaseOrderID,
                                    Date = p.Date,
                                    EmpName = e.FirstName + "" + e.LastName
                                };
            dgvPurchase.DataSource = PurchaseOrder;
        }

        private void btnAddPurchase_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder frmPO = new frmPurchaseOrder();
            if (frmPO.ShowDialog() == DialogResult.OK)
            {
                Load_Purchase();
            }
        }

        private void btnUpdatePurchase_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.CurrentRow != null)
            {
                frmCarList.update = true;
                var row = dgvPurchase.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.PurchaseOrders);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.PurchaseOrderDetails);
                var _purchase = (from p in db.PurchaseOrders
                                 where p.PurchaseOrderID == id
                                 select p).SingleOrDefault();

                //var _serviceDetail = from sd in db.ServiceDetails
                //                     where sd.CarNo == id
                //                     select sd;
                frmPurchaseOrderUpdate frmPou = new frmPurchaseOrderUpdate();
                frmPou.PurchaseOrder = _purchase;
                //frmC.ServiceDetail = _serviceDetail.ToList();
                if (frmPou.ShowDialog() == DialogResult.OK)
                {
                    Load_Purchase();
                }
            }
        }

        private void btnDeletePurchase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvPurchase.CurrentRow != null)
                {
                    var id = int.Parse(dgvPurchase.CurrentRow.Cells[0].Value.ToString());

                    var _purchaseOrder = from p in db.PurchaseOrderDetails
                                    where p.PurchaseOrderID == id
                                    select p;
                    foreach (var item in _purchaseOrder)
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
                    var _purchase = db.PurchaseOrders.SingleOrDefault(p => p.PurchaseOrderID == id);

                    db.PurchaseOrders.DeleteOnSubmit(_purchase);

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
                    Load_Purchase();
                }
            }
        }

        private void btnDetailsPurchase_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.CurrentRow != null)
            {
                frmCarList.update = true;
                var row = dgvPurchase.CurrentRow;
                var id = Convert.ToInt32(row.Cells[0].Value);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.PurchaseOrders);
                db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.PurchaseOrderDetails);
                var _purchase = (from p in db.PurchaseOrders
                                 where p.PurchaseOrderID == id
                                 select p).SingleOrDefault();

                //var _serviceDetail = from sd in db.ServiceDetails
                //                     where sd.CarNo == id
                //                     select sd;
                frmPurchaseOrderUpdate.detail = true;
                frmPurchaseOrderUpdate frmPou = new frmPurchaseOrderUpdate();                
                frmPou.PurchaseOrder = _purchase;
                //frmC.ServiceDetail = _serviceDetail.ToList();
                if (frmPou.ShowDialog() == DialogResult.OK)
                {
                    frmPurchaseOrderUpdate.detail = false;
                    Load_Purchase();
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmPrint print = new frmPrint();
            frmPrint.car = true;
            print.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPurchase.CurrentRow.Cells[0].Value);

            frmPrint print = new frmPrint();
            frmPrint.id = id;
            frmPrint.purchaseOrder = true;
            print.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmPrint print = new frmPrint();
            frmPrint.carmodel = true;
            print.ShowDialog();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            frmPrint print = new frmPrint();
            frmPrint.manufactory = true;
            print.ShowDialog();
        }

        private void btnSearchModel_Click(object sender, EventArgs e)
        {
            if (txtSearchModel.Text != "")
            {
                var search_man = from cus in db.CarModels
                                 join ma in db.Manufactories on cus.ManufactoryID equals ma.ManufactoryID
                                 where cus.ModelName.Contains(txtSearchModel.Text)
                                 select new
                                 {
                                     ModelName = cus.ModelName,
                                     ManufactoryName = ma.ManufactoryName
                                 };
                dgvModel.DataSource = search_man;
            }
            else
            {
                Load_Purchase();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
            var PurchaseOrder = from p in db.PurchaseOrders
                                join em in db.Employees on p.EmployeeID equals em.EmployeeID
                                select new
                                {
                                    Id = p.PurchaseOrderID,
                                    Date = p.Date,
                                    EmpName = em.FirstName + " " + em.LastName
                                };
            dgvPurchase.DataSource = PurchaseOrder;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dtpPickADay.Value;
           
                var PurchaseOrder = from p in db.PurchaseOrders
                                    join em in db.Employees on p.EmployeeID equals em.EmployeeID
                                    where p.Date == date
                                    select new
                                    {
                                        Id = p.PurchaseOrderID,
                                        Date = p.Date,
                                        EmpName = em.FirstName + " " + em.LastName
                                    };
                dgvPurchase.DataSource = PurchaseOrder;

            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtSearchCar.Text != "")
            {
                var search_man = (from c in db.Cars
                                 where c.Name.Contains(txtSearchCar.Text)
                                 select new CarViewModel
                                 {
                                     CarNo = c.CarNo,
                                     ModelName = c.ModelName,
                                     Name = c.Name,
                                     Price = c.Price,
                                     Quantity = 0
                                 }).ToList();

                
                foreach (var item in search_man)
                {
                    item.Quantity = db.totalCar(item.CarNo);
                }
                dgvCar.DataSource = search_man;
            }
            else
            {
                Load_Car();
            }
        }
    }
}

