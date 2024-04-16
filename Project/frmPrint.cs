using Project.Report;
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
    public partial class frmPrint : Form
    {
        public static bool car = false;
        public static bool employee = false;
        public static bool customer = false;
        public static bool carmodel = false;
        public static bool manufactory = false;
        public static bool OrderDetail = false;
        public static bool purchaseOrder = false;

        public static int id;
        DbContextDataContext db = new DbContextDataContext();
        public lblsale sale { get; set; }

        public frmPrint()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            if (car)
            {
                rptCar car = new rptCar();
                var datacar = (from cr in db.Cars
                            select cr).ToList();
                car.SetDataSource(datacar);
                rptViewer.ReportSource = car;
                rptViewer.Show();
            }
            if (employee)
            {

                rptEmployee emp = new rptEmployee();
                var dataemp = (from em in db.Employees
                            select em).ToList();
                emp.SetDataSource(dataemp);
                rptViewer.ReportSource = emp;
                rptViewer.Show();
            }
            if (customer)
            {

                rptCustomer cus = new rptCustomer();
                var datacus = (from cust in db.Customers
                            select cust).ToList();
                cus.SetDataSource(datacus);
                rptViewer.ReportSource = cus;
                rptViewer.Show();
            }
            if (carmodel)
            {

                rptCarModel carmodel = new rptCarModel();
                var datacarmodel = (from cm in db.CarModels
                            select cm).ToList();
                carmodel.SetDataSource(datacarmodel);
                rptViewer.ReportSource = carmodel;
                rptViewer.Show();
            }
            if (manufactory)
            {

                rptManufactory manu = new rptManufactory();
                var datamanu = (from ma in db.Manufactories
                            select ma).ToList();
                manu.SetDataSource(datamanu);
                rptViewer.ReportSource = manu;
                rptViewer.Show();
            }
            if (OrderDetail)
            {

                rptOrderDetail orderdetail = new rptOrderDetail();

                var dataorderdetail = from o in db.OrderDetails
                           join od in db.Orders on o.OrderID equals od.OrderID
                           join c in db.Cars on o.CarNo equals c.CarNo
                           join empl in db.Employees on od.EmployeeID equals empl.EmployeeID
                           join cust in db.Customers on od.CustomerID equals cust.CustomerID
                           where o.OrderID == id
                           select new OrderDetailRpt
                           {
                               idOrder = Convert.ToInt32(o.OrderID),
                               EmployeeName = empl.FirstName + " " + empl.LastName,
                               CustomerName = cust.FirstName + " " + cust.LastName,
                               onOrder = od.OnOrder,
                               confirmation = od.Confirmation,
                               carNo = Convert.ToInt32(c.CarNo),
                               carName = c.Name,
                               ModelName = c.ModelName,
                               quantity = o.Quantity,
                               Price = c.Price

                           };
                orderdetail.SetDataSource(dataorderdetail);
                rptViewer.ReportSource = orderdetail;
                rptViewer.Show();
            }
            if (purchaseOrder)
            {
                rptPurchaseOrderDetail purchase = new rptPurchaseOrderDetail();
                var datapurchase = from purcha in db.PurchaseOrderDetails
                           join purchao in db.PurchaseOrders on purcha.PurchaseOrderID equals purchao.PurchaseOrderID
                           join car in db.Cars on purcha.CarNo equals car.CarNo
                           join carmo in db.CarModels on car.ModelName equals carmo.ModelName
                           join emp in db.Employees on purchao.EmployeeID equals emp.EmployeeID
                           where purcha.PurchaseOrderID == id
                           select new PurchaseOrderDetailrpt
                           {
                               PurchaseOrderID = Convert.ToInt32(purcha.PurchaseOrderID),
                               EmployeeName = emp.FirstName + " " + emp.LastName,
                               OnOrder = purchao.Date,
                               CarNo = Convert.ToInt32(car.CarNo),
                               Name = car.Name,
                               ModelName = carmo.ModelName,
                               Quantity = purcha.Quantity,
                               Price = Convert.ToInt32(purcha.Price)
                           };
                purchase.SetDataSource(datapurchase);
                rptViewer.ReportSource = purchase;
                rptViewer.Show();
            }
        }
    }
}
