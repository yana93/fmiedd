using CRUD_Project.Controllers;
using CRUD_Project.View;
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

namespace CRUD_Project.Views
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public Form PreviousForm
        {
            get;
            set;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            this.Close();
            LogIn form1 = new LogIn();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControllerUser ctr1 = new ControllerUser();

            if (textBoxUsername.Text.Length <= 0 || textBoxPass.Text.Length <= 0 || textBoxEmail.Text.Length <= 0)
            {
                MessageBox.Show("Empty fields are not allowed!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTextBoxes();
                return;
            }

            if (ctr1.Register(textBoxUsername.Text, textBoxPass.Text, textBoxEmail.Text))
            {
                MessageBox.Show("You have been registered to our system successfully!", "Registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                PreviousForm.Show();
            }
            else
            {
                MessageBox.Show("This username is not avaliable!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                
                
        }

        private void ClearTextBoxes()
        {
            textBoxUsername.Clear();
            textBoxPass.Clear();
            textBoxEmail.Clear();
        }

    }
}
