using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCRUD1301681007_3attempt
{
    public partial class frmMain : Form
    {
        private SqlDbType connection;

        public frmMain()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditUsers frmEditUsers = new frmEditUsers();
            frmEditUsers.MdiParent = this;
            frmEditUsers.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
