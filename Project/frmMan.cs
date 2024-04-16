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
    public partial class frmMan : Form
    {
        DbContextDataContext db = new DbContextDataContext();        
        public Manufactory Manufactory { get; set; }
        public static bool Detail = false;
        bool edit = false;
        public frmMan()
        {
            InitializeComponent();
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string err = "";
            if (txtAddress.TextLength == 0)
            {
                err += "\nKhông được để trống mục Address này";
            }
            if (txtName.TextLength == 0)
            {
                err += "\nKhông được để trống mục Name này";
            }
            int sdt;

            if (txtPhone.TextLength == 0)
            {
                err += "\nKhông được để trống mục Phone này";
            }
            else
            {
                try
                {
                    sdt = Convert.ToInt32(txtPhone.Text);
                }
                catch (Exception)
                {

                    err += "Số điện thoại không đúng định dạng";
                }

            }
            if (err .Length!=0)
            {
                MessageBox.Show(err, "Thông báo"); ;
            }
            else {
                if (edit)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var oldMan = (from om in db.Manufactories
                                      where om.ManufactoryID == Manufactory.ManufactoryID
                                      select om).SingleOrDefault();
                        oldMan.ManufactoryName = txtName.Text;
                        oldMan.Address = txtAddress.Text;
                        oldMan.Phone = Convert.ToInt32(txtPhone.Text);
                        oldMan.AddInfor = txtInfo.Text;

                        try
                        {
                            Bitmap bmpPhoto = new Bitmap(pbxPicture1.Image);
                            ImageConverter converter = new ImageConverter();
                            byte[] output = (byte[])converter.ConvertTo(pbxPicture1.Image, typeof(byte[]));
                            oldMan.Logo = output;
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
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                else
                {
                    Manufactory m = new Manufactory();
                    m.ManufactoryName = txtName.Text;
                    m.Address = txtAddress.Text;
                    m.Phone = Convert.ToInt32(txtPhone.Text);
                    m.AddInfor = txtInfo.Text;
                    try
                    {
                        Bitmap bmpPhoto = new Bitmap(pbxPicture1.Image);
                        ImageConverter converter = new ImageConverter();
                        byte[] output = (byte[])converter.ConvertTo(pbxPicture1.Image, typeof(byte[]));
                        m.Logo = output;
                    }
                    catch (Exception)
                    {


                    }
                    db.Manufactories.InsertOnSubmit(m);
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
        private void frmMan_Load(object sender, EventArgs e)
        {
            if (Manufactory != null)
            {
                edit = true;
                txtName.Text = Manufactory.ManufactoryName;
                txtInfo.Text = Manufactory.AddInfor;
                txtPhone.Text = Manufactory.Phone.ToString();
                txtAddress.Text = Manufactory.Address;
                try
                {
                    pbxPicture1.Image = ByteToImage(Manufactory.Logo.ToArray());
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                    pbxPicture1.Image = img;
                }
                catch (Exception ex)
                {


                }
            }
        }
    }
}
