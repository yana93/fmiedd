using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentsDB
{

    public partial class AddNewUser : Form
    {
        SqlConnection dataConnect = new SqlConnection(@"Data Source=INVICTUS\MSSQLDATABASES;Initial Catalog=STUDENTS;Integrated Security=True");
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.studentsDS.Users);
        }
        private void add_FormClosing(object sender, FormClosingEventArgs c)
        {
            c.Cancel = true;
            this.Hide();
            DBSheet db = new DBSheet();
            db.Show();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try 
            { 
                dataConnect.Open();
                SqlCommand dbCommand = new SqlCommand("INSERT INTO Users (username, password, email)" + "VALUES( @username, @password, @email)", dataConnect);
                dbCommand.Parameters.AddWithValue("@username", tbUser.Text);
                dbCommand.Parameters.AddWithValue("@password", tbPass.Text);
                dbCommand.Parameters.AddWithValue("@email", tbEmail.Text);
                SqlDataReader sqlReader = dbCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    Console.WriteLine("{0}" + tbUser.Text + "{1}" + tbPass.Text + "{2}" + tbEmail.Text, sqlReader.GetSqlValue(0), sqlReader.GetSqlString(1), sqlReader.GetSqlValue(2));
                };
                MessageBox.Show("Gratz! You just add a new student!");

                this.usersTableAdapter.Fill(this.studentsDS.Users);

                sqlReader.Close();
                dataConnect.Close();
                this.Close();
            }
            catch (SqlException c)
            {
                Console.WriteLine("Error {0}", c.Errors[0].Message);
            }

            finally
            {
                
                dataConnect.Close();
            }


                if (tbUser.Text == "")
                {
                    MessageBox.Show("You must enter a valid username!");
                }

                else if (tbUser.Text.Contains('@') || tbUser.Text.Contains('#') || tbUser.Text.Contains('!')
                         || tbUser.Text.Contains('$') || tbUser.Text.Contains('%') || tbUser.Text.Contains('*'))
                    {
                        MessageBox.Show("This username is invalid! It contains one of these restricted symbols [!,@,#,$,%,&,*]! Please enter a correct username!");
                    }

                else if (tbPass.Text == "")
                    {
                        MessageBox.Show("You must enter a valid password!");
                    }

                else if (tbEmail.Text == "")
                    {
                        MessageBox.Show("You must enter a valid email!");
                    }
                        
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUser.Clear();
            tbPass.Clear();
            tbEmail.Clear();
        }

    }
}
