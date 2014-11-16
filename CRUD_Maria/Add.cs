using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Maria
{
    public partial class Add : Form
    {
        private string username;
        private string password;
        private int identificaton;
        private string email;
        public Add()
        {
            InitializeComponent();
        }

        private void identification_Validated(object sender, EventArgs e)
        {
            try
            {
                identificaton = int.Parse(id.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter only int number");
            }
        }

        private void addData_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == "")
            {
                MessageBox.Show("Fill username field");
            }
            else if (pass.Text == "")
            {
                MessageBox.Show("Fill password field"); 
            }
            else if (emailBox.Text == "")
            {
                MessageBox.Show("Fill email field");
            }
            else
            {
                username = usernameBox.Text;
                password = pass.Text;
                email = emailBox.Text;
                Users user = new Users(username, password, identificaton, email);
                user.Add();
                MessageBox.Show("Sucess!");
                this.Close();
            }

        }

        private void clear_Click(object sender, EventArgs e)
        {
            usernameBox.Text = "";
            pass.Text = "";
            emailBox.Text = "";
            id.Text = "";
        }

    }
}
