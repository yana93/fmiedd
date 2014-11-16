using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using B.DataClass;
using System.Windows.Forms;

namespace B
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
           if(!(tbUsername.Text==""))
           {
               if(!(tbPassword.Text==""))
               {
                   UserRepository.AddUser(tbUsername.Text, tbPassword.Text);
                   //MessageBox.Show("Successfully added user");
                   tbPassword.Text = String.Empty;
                   tbUsername.Text = String.Empty;
                   this.Owner.Show();
                   this.Owner.Enabled = true;
                   this.Hide();
               }
               lbPassword.ForeColor = Color.IndianRed;
           }
           lbUsername.ForeColor = Color.IndianRed;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            tbPassword.Text = String.Empty;
            tbUsername.Text = String.Empty;
            this.Owner.Show();
            this.Owner.Enabled = true;
            this.Hide();
        }
    }
}
