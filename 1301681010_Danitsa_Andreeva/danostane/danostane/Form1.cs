using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace danostane
{
    public partial class Form1 : Form
    {
        static int id_main = 0;
        static OleDbDataReader dr = null;
        static OleDbCommand cmd = new OleDbCommand();
        static OleDbConnection cn = new OleDbConnection();
        static string txtdelete = "";
        static string txtupdate = "";
        public Form1()
        {
            InitializeComponent();
            cn.ConnectionString = @"Provider=SQLNCLI11;Data Source=PAVEL-PC\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Users";
            cmd.Connection = cn;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Insert(cn, cmd);
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }
        public static void Cud(String u, OleDbConnection cn, OleDbCommand cmd)
        {
            try
            {
                cn.Open();
                cmd.CommandText = u;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                MessageBox.Show(e.Message.ToString());
            }
        }
        public void Read(OleDbConnection cn, OleDbCommand cmd, OleDbDataReader dr)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            try
            {
                string q = "select * from users";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr[0].ToString());
                        listBox2.Items.Add(dr[1].ToString());
                        listBox3.Items.Add(dr[2].ToString());
                        listBox4.Items.Add(dr[3].ToString());
                        id_main = Convert.ToInt32(dr[0]);
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Read(cn, cmd, dr);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            txtdelete = listBox1.SelectedItem.ToString();
            Delete(cn, cmd);
        }
        public void Delete(OleDbConnection cn, OleDbCommand cmd)
        {
            string u = "delete from Users where id='" + txtdelete + "'";
            Cud(u, cn, cmd);
            Read(cn, cmd, dr);
        }
        public void Update(OleDbConnection cn, OleDbCommand cmd)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string u="update Users set username='"+username+"',password='"+password+"',email='"+email+"' where id='"+txtupdate+"'";
            Cud(u, cn, cmd);
            Read(cn, cmd, dr);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            txtupdate=listBox1.SelectedItem.ToString();
            Update(cn, cmd);
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        public void Insert(OleDbConnection cn, OleDbCommand cmd)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            id_main += 1;
            string u = "INSERT INTO Users (id, username, password, email) VALUES ('" + id_main + "','" + username.ToString() + "','" + password.ToString() + "','" + email.ToString() + "')";
            Cud(u, cn, cmd);
            Read(cn, cmd, dr);
        }
    }
}
