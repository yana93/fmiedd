using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1_Dafinka.Service;

namespace Task1_Dafinka
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AuthenticationService.AuthenticateUser(tbUsername.Text, tbPass.Text);
            if (AuthenticationService.LoggedUser != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
