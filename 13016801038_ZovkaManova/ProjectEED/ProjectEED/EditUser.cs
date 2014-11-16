using ProjectEED.Entity;
using ProjectEED.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEED
{
    public partial class EditUser : Form
    {

        public User user;
        public void SetUser(User user)
        {
            this.user = user;
        }
        public User Get()
        {
            return this.user;
        }

        public EditUser()
        {

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
             UsersRepository repo = new UsersRepository();

                if (txtUsername.Text == "")
                {
                    MessageBox.Show("The textbox can't be empty!");
                }
                else
                {
                    user.Username = txtUsername.Text.TrimEnd();
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("The textbox can't be empty!");
                }
                else
                {
                    user.Password = txtPassword.Text.TrimEnd();
                }
                if (txtFirstname.Text == "")
                {
                    MessageBox.Show("The textbox can't be empty!");
                }
                else
                {
                    user.Firstname = txtFirstname.Text.TrimEnd();
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("The textbox can't be empty!");
                }
                else
                {
                    user.Email = txtEmail.Text.TrimEnd();
                }
                if (txtLastname.Text == "")
                {
                    MessageBox.Show("The textbox can't be empty!");
                }
                else
                {
                    user.Lastname = txtLastname.Text.TrimEnd();
                }
                repo.Update(user);
            
       
            ManageUsers mngUsers = new ManageUsers();
            this.Hide();
            mngUsers.Show();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            if(user!=null)
            {
                txtUsername.Text = user.Username.TrimEnd();
                txtPassword.Text = user.Password.TrimEnd();
                txtFirstname.Text = user.Firstname.TrimEnd();
                txtLastname.Text = user.Lastname.TrimEnd();
                txtEmail.Text = user.Email.TrimEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageUsers mngUsers = new ManageUsers();
            mngUsers.Show();
        }
    }
}
