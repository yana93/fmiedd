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

namespace CRUDWindowsFormsSQL
{
    public partial class Form1 : Form
    {
        // Connection with SQL Server
        SqlConnection connection = new SqlConnection(@"Data Source=STEFAN-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            command.Connection = connection;
            loadlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Insert button 
            if (txtusername.Text != "" & txtpassword.Text != "" & txtemail.Text != "")
            {
                connection.Open();
                command.CommandText = "INSERT INTO users(username, password, email) VALUES ('" + txtusername.Text + "', '" + txtpassword.Text + "', '" + txtemail.Text + "')";
                command.ExecuteNonQuery();
                command.Clone();
                MessageBox.Show("Record inserted!");
                connection.Close();
                txtusername.Text = "";
                txtpassword.Text = "";
                txtemail.Text = "";
                loadlist();
            }
        }
        private void loadlist()
        {
            // View list query
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            connection.Open();
            command.CommandText = "SELECT * FROM users";
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[1].ToString());
                    listBox2.Items.Add(dr[2].ToString());
                    listBox3.Items.Add(dr[3].ToString());
                }
            }
            connection.Close();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // View list
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1) {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                listBox3.SelectedIndex = l.SelectedIndex;
                txtusername.Text = listBox1.SelectedItem.ToString();
                txtpassword.Text = listBox2.SelectedItem.ToString();
                txtemail.Text = listBox3.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Button for Delete
            if (txtusername.Text != "" & txtpassword.Text != "" & txtemail.Text != "")
            {
                connection.Open();
                command.CommandText = "DELETE FROM users WHERE username='"+txtusername.Text+"' and password='"+txtpassword.Text+"' and email='"+txtemail.Text+"'";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Record deleted!");
                loadlist();
                txtusername.Text = "";
                txtpassword.Text = "";
                txtemail.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Button for Update
            if (txtusername.Text != "" && txtpassword.Text != "" & txtemail.Text != "" & listBox1.SelectedIndex!=-1)
            {
                connection.Open();
                command.CommandText = "UPDATE users SET username='"+txtusername.Text+"', password='"+txtpassword.Text+"', email='"+txtemail.Text+"' WHERE username='"+listBox1.SelectedItem.ToString()+"' and password='"+listBox2.SelectedItem.ToString()+"' and email= '"+listBox3.SelectedItem.ToString()+"'";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Record updated!");
                loadlist();
                txtusername.Text = "";
                txtpassword.Text = "";
                txtemail.Text = "";
            }
        }
    }
    }