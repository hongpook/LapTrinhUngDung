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
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }

        private void tmLoad_Tick(object sender, EventArgs e)
        {
            pgbLoad.Value++;
            if (pgbLoad.Value == 100)
            {
                tmLoad.Enabled = false;
                this.Hide();
                frmConfig frmC = new frmConfig();
                frmC.Show();
            }
        }

        private void frmLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
