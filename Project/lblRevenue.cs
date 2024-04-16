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
    public partial class lblRevenue : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public lblRevenue()
        {
            InitializeComponent();
            loadDT();
        }


        void loadDT()
        {
            var _tong_SP =  from c in db.Cars select c.CarNo;
            int tongSP = _tong_SP.Count();

            var _tongKH = from kh in db.Customers select kh.CustomerID;
            int TongKH = _tongKH.Count();


            var _doanhThu = (from od in db.OrderDetails
                             join o in db.Orders on od.OrderID equals o.OrderID
                             join c in db.Cars on od.CarNo equals c.CarNo
                             select od.Quantity * c.Price).Sum();

            var _hoaDon = from o in db.Orders
                          select o;
            int tongHD = _hoaDon.Count();

            lb_TongKH.Text = TongKH.ToString();
            lb_TongSP.Text = tongSP.ToString();
            lb_DoanhThu.Text = _doanhThu.ToString();
            lb_TongHD.Text = tongHD.ToString();



        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var start = txtStartDate.Value;
            var end = txtEndDate.Value;

            var _quantityOrder = from o in db.Orders
                                 where o.OnOrder >= start && o.OnOrder <= end
                                 select o;

            int quantityOrder = _quantityOrder.Count();


            var _quantityNhap = from p in db.PurchaseOrders
                                join pd in db.PurchaseOrderDetails on p.PurchaseOrderID equals pd.PurchaseOrderID
                                where p.Date >= start && p.Date <= end
                                select pd.Quantity;

            int quantityNhap = _quantityNhap.Sum();

            var _quantityBan = from o in db.Orders
                               join od in db.OrderDetails on o.OrderID equals od.OrderID
                               where o.OnOrder >= start && o.OnOrder <= end
                               select od.Quantity;

            int quantityBan = _quantityBan.Sum();

            
                      
            var _nhap = (from pd in db.PurchaseOrderDetails
                        join p in db.PurchaseOrders on pd.PurchaseOrderID equals p.PurchaseOrderID
                        where p.Date >= start && p.Date <= end
                        select pd.Quantity * pd.Price).Sum();

            var _ban = (from od in db.OrderDetails
                        join o in db.Orders on od.OrderID equals o.OrderID
                        join c in db.Cars on od.CarNo equals c.CarNo
                        where o.OnOrder >= start && o.OnOrder <= end
                        select od.Quantity * c.Price).Sum();

            var revenue = _ban - _nhap;

            

            //if (_quantityBan != null)
            //{
            //    lblBan.Text = quantityBan.ToString();
            //}
            //else
            //{
            //    lblBan.Text = "0";
            //}

            //if (_quantityNhap != null)
            //{
            //    lblNhap.Text = quantityNhap.ToString();
            //}
            //else
            //{
            //    lblNhap.Text = "0";
            //}

            lblHoaDon.Text = quantityOrder.ToString();

            lblNhap.Text = quantityNhap.ToString();

            lblBan.Text = quantityBan.ToString();

            lblDoanhThu.Text = revenue.ToString();

            lblGiaBan.Text = _ban.ToString();

            lblGiaNhap.Text = _nhap.ToString();
        }

        
    }
}
