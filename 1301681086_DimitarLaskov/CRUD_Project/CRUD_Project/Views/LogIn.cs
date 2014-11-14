using CRUD_Project.Controllers;
using CRUD_Project.Models;
using CRUD_Project.View;
using CRUD_Project.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Project.View
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {

            ControllerUser ctr1 = new ControllerUser();
            int userId = ctr1.LoginAuthentication(textBoxUsername.Text, textBoxPassword.Text);

            if (userId > 0)
            {
                this.Hide();
                Main form2 = new Main();
                form2.LoggedUser(userId);
                form2.mainForm = this;
                form2.Show();
            }
            else
            {
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.PreviousForm = this;
            this.Hide();
            register.Show();
        }

    }
}
