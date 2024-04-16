using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmCarModel : Form
    {
        DbContextDataContext db = new DbContextDataContext();
        public CarModel CarModel { get; set; }
        bool edit = false;
        public static bool Detail = false;
        public frmCarModel()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var oldCarModel = (from c in db.CarModels
                                       where c.ModelName == CarModel.ModelName
                                       select c).SingleOrDefault();

                    string err = "";
                    if (txtName.TextLength == 0)
                    {
                        err += "\nName không được bỏ trống";
                    }
                    if (txtInfo.TextLength == 0)
                    {
                        err += "\nInformation không được bỏ trống";
                    }
                    if (err.Length == 0)
                    {

                        oldCarModel.ModelName = txtName.Text;
                        oldCarModel.ManufactoryID = Convert.ToInt32(cboMan.SelectedValue);
                        oldCarModel.AddInfor = txtInfo.Text;
                        try
                        {
                            Bitmap bmpPhoto = new Bitmap(pbxPicture.Image);
                            ImageConverter converter = new ImageConverter();
                            byte[] output = (byte[])converter.ConvertTo(pbxPicture.Image, typeof(byte[]));
                            oldCarModel.Image = output;
                        }
                        catch (Exception)
                        {


                        }
                        try
                        {
                            db.SubmitChanges();
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Bạn không thể thay đổi tên của CarModel", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(err,"Thông báo");

                    }
                }

            }
            else
            {
                string err = "";
                if (txtName.TextLength == 0)
                {
                    err += "\nName không được bỏ trống";
                }
                if (txtInfo.TextLength == 0)
                {
                    err += "\nInformation không được bỏ trống";
                }
                if (err.Length == 0)
                {
                    CarModel c = new CarModel();
                    c.ModelName = txtName.Text;
                    c.ManufactoryID = Convert.ToInt32(cboMan.SelectedValue);
                    c.AddInfor = txtInfo.Text;

                    try
                    {
                        Bitmap bmpPhoto = new Bitmap(pbxPicture.Image);
                        ImageConverter converter = new ImageConverter();
                        byte[] output = (byte[])converter.ConvertTo(pbxPicture.Image, typeof(byte[]));
                        c.Image = output;
                    }
                    catch (Exception)
                    {


                    }
                    db.CarModels.InsertOnSubmit(c);

                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(err,"Thông báo");

                }
                
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void frmCarModel_Load(object sender, EventArgs e)
        {
            Load_Cbo();
            if (CarModel != null)
            {
                edit = true;
                txtName.Text = CarModel.ModelName;
                txtInfo.Text = CarModel.AddInfor;
                cboMan.SelectedValue = CarModel.ManufactoryID;
                try
                {
                    pbxPicture.Image = ByteToImage(CarModel.Image.ToArray());
                }
                catch (Exception ex)
                {


                }
            }
            if (Detail)
            {
                btnAccept.Enabled = false;
            }
        }

        public void Load_Cbo()
        {
            cboMan.DataSource = db.Manufactories;
            cboMan.DisplayMember = "ManufactoryName";
            cboMan.ValueMember = "ManufactoryID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;

            }
            else
            {
                try
                {
                    Image img = Image.FromFile(file);
                    pbxPicture.Image = img;
                }
                catch (Exception ex)
                {


                }
            }
        }
    }
}
