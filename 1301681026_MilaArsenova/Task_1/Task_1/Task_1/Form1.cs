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

namespace Task_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'taskDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.taskDataSet.Users);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection mysqlcon = new SqlConnection("Server=USER-PC\\SQLEXPRESS; Database=Task; Integrated Security=true; Persist Security Info=false;");
            mysqlcon.Open();

            while (idBox.Text != "" && usernameBox.Text != "" && passwordBox.Text != "" && emailBox.Text != "")
            {
                SqlCommand mysqlcom = new SqlCommand("INSERT INTO [Task].[dbo].[Users] (ID, Username, Password, Email)" + "VALUES(@ID, @Username, @Password, @Email)", mysqlcon);


                mysqlcom.Parameters.Add("@ID", idBox.Text);
                mysqlcom.Parameters.Add("@Username", usernameBox.Text);
                mysqlcom.Parameters.Add("@Password", passwordBox.Text);
                mysqlcom.Parameters.Add("@Email", emailBox.Text);



                SqlDataReader mysqldr = mysqlcom.ExecuteReader();

                while (mysqldr.Read())
                {
                    Console.WriteLine("{0}" + idBox.Text + "{1}" + usernameBox.Text + "{2}" + passwordBox.Text + "{3}" + emailBox.Text, mysqldr.GetSqlValue(0), mysqldr.GetSqlString(1), mysqldr.GetSqlValue(2), mysqldr.GetString(3));
                }


                label5.Text = "You inserted a new row!";


                mysqldr.Close();
                mysqlcon.Close();

            }

            if (idBox.Text == "")
            {
                MessageBox.Show("You must to enter your id!");
            }

            else
                if (usernameBox.Text == "")
                {
                    MessageBox.Show("You must to enter your username!");
                }
            
                else
                    if (usernameBox.Text.Contains('@') || usernameBox.Text.Contains('#') || usernameBox.Text.Contains('!')
                         || usernameBox.Text.Contains('$') || usernameBox.Text.Contains('%') || usernameBox.Text.Contains('*'))
                    {
                        MessageBox.Show("This username is incorrect! Please enter a correct username!");
                    }

                else
                    if (passwordBox.Text == "")
                    {
                        MessageBox.Show("You must to enter your password!");
                    }
                        
                    else
                        if (passwordBox.Text.Contains('@') || passwordBox.Text.Contains('#') || passwordBox.Text.Contains('!')
                            || passwordBox.Text.Contains('$') || passwordBox.Text.Contains('%') || passwordBox.Text.Contains('*'))
                        {
                            MessageBox.Show("Your password is incorrect! Please enter a correct password!");
                        }

                    else
                        if (emailBox.Text == "")
                        {
                            MessageBox.Show("You must to enter your email!");
                        }
                        

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection mysecondsqlcon = new SqlConnection("Server=USER-PC\\SQLEXPRESS; Database=Task; Integrated Security=true; Persist Security Info=false;");
            mysecondsqlcon.Open();


            SqlCommand mysecondsqlcommand = new SqlCommand("DELETE " + "FROM [Task].[dbo].[Users]" + "WHERE Username=@Username", mysecondsqlcon);
            mysecondsqlcommand.Parameters.Add("@Username", usernameBox.Text);


            SqlDataReader mysecondsqldr = mysecondsqlcommand.ExecuteReader();

            while (mysecondsqldr.Read())
            {
                Console.WriteLine("{0}" + idBox.Text + "{1}" + usernameBox.Text + "{2}" + passwordBox.Text + "{3}" + emailBox.Text, mysecondsqldr.GetSqlValue(0), mysecondsqldr.GetSqlString(1), mysecondsqldr.GetSqlValue(2), mysecondsqldr.GetString(3));
            }


            label5.Text = "You deleted a row!";

            mysecondsqldr.Close();
            mysecondsqlcon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection mythirdsqlcon = new SqlConnection("Server=USER-PC\\SQLEXPRESS; Database=Task; Integrated Security=true; Persist Security Info=false;");
            mythirdsqlcon.Open();


            SqlCommand mythirdsqlcommand = new SqlCommand("UPDATE [Task].[dbo].[Users]" + "SET Password='boyzone'" + "WHERE Username=@Username", mythirdsqlcon);
            mythirdsqlcommand.Parameters.Add("@Username", usernameBox.Text);
          
          
            SqlDataReader mythirdsqldr = mythirdsqlcommand.ExecuteReader();


            while (mythirdsqldr.Read())
            {

                Console.WriteLine("{0}" + idBox.Text + "{1}" + usernameBox.Text + "{2}" + passwordBox.Text + "{3}" + emailBox.Text, mythirdsqldr.GetSqlValue(0), mythirdsqldr.GetSqlString(1), mythirdsqldr.GetSqlValue(2), mythirdsqldr.GetString(3));
            }

            label5.Text = "You updated a column!";

            mythirdsqldr.Close();
            mythirdsqlcon.Close();
        }

    
        private void label5_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}
