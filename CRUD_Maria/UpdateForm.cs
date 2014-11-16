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
    public partial class UpdateForm : Form
    {
        private int id { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private int identificaton { get; set; }
        private string email { get; set; }
        private Users user;
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItem != null)
            {
                usernameBox.Enabled = true;
                pass.Enabled = true;
                emailBox.Enabled = true;
                identificationBox.Enabled = true;
                done.Enabled = true;

            }
            else
            {
                MessageBox.Show("Select user from the list box");
            }


        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDataSet.UserData' table. You can move, or remove it, as needed.
            this.userDataTableAdapter.Fill(this.usersDataSet.UserData);
            // TODO: This line of code loads data into the 'usersDataSet.UserData' table. You can move, or remove it, as needed.
            this.userDataTableAdapter.Fill(this.usersDataSet.UserData);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItem != null)
            {
                id = int.Parse(usersList.SelectedValue.ToString());
                user = new Users(id);
                user.Delete();
                MessageBox.Show("Record deleted");
                this.Close();
            }
            else
            {
                MessageBox.Show("Select user from the list box");
            }
          
        }

        private void done_Click(object sender, EventArgs e)
        {
            if(usernameBox.Text=="")
            {
                MessageBox.Show("The field username must be filled");
            }
            else if(pass.Text=="")
            {
                MessageBox.Show("The field pass must be filled");
            }
            else if(emailBox.Text=="")
            {
                MessageBox.Show("The field email must be filled");
            }
            else if(identificationBox.Text=="")
            {
                MessageBox.Show("The field identification must be filled");
            }
            else
            {
                username = usernameBox.Text;
                email = emailBox.Text;
                password = pass.Text;
                identificaton = int.Parse(identificationBox.Text);
                id = int.Parse(usersList.SelectedValue.ToString());
                user = new Users();
                user.Update(id, username, password, identificaton, email);
                MessageBox.Show("Update sucsessfull!");
                this.Close();
            }
        }

        private void identificationBox_Validated(object sender, EventArgs e)
        {
            try
            {
                identificaton = int.Parse(identificationBox.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Ënter only int number");
            }
        }

    }
}
