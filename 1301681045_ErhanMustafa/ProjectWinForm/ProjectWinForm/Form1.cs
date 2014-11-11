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


namespace ProjectWinForm
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=PC-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            loadlist();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbid.Text != "" & tbname.Text != "" & tbpass.Text != "" & tbemail.Text != "")
            {
                cn.Open();
                cmd.CommandText = "insert into users (id, username, password, email) values('" + tbid.Text + "', '" + tbname.Text + "', '" + tbpass.Text + "','" + tbemail.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("Record Inserted", "CRUD");
                cn.Close();
                tbid.Text = "";
                tbname.Text = "";
                tbpass.Text = "";
                tbemail.Text = "";

                loadlist();

            }
        } 
        private void loadlist()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
          

            cn.Open();
            cmd.CommandText = "select * from users";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    listBox2.Items.Add(dr[1].ToString());
                    listBox3.Items.Add(dr[2].ToString());
                    listBox4.Items.Add(dr[3].ToString());
                  
                }
            }
            cn.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                listBox3.SelectedIndex = l.SelectedIndex;
                listBox4.SelectedIndex = l.SelectedIndex;
                tbid.Text = listBox1.SelectedItem.ToString();
                tbname.Text = listBox2.SelectedItem.ToString();
                tbpass.Text = listBox3.SelectedItem.ToString();
                tbemail.Text = listBox4.SelectedItem.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbid.Text != "" & tbname.Text != "" & tbpass.Text != "" & tbemail.Text != "")
            {
                cn.Open();
                cmd.CommandText = "delete from users where id ='" + tbid.Text + "'and username='" + tbname.Text + "'and password='" + tbpass.Text + "'and email='" + tbemail.Text + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record Deleted", "CRUD");
                loadlist();
                tbid.Text = "";
                tbname.Text = "";
                tbpass.Text = "";
                tbemail.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbid.Text != "" & tbname.Text != "" & tbpass.Text != "" & tbemail.Text != ""& listBox1.SelectedIndex!=-1  )
            {
                cn.Open();
                cmd.CommandText = "update users set id ='" + tbid.Text + "', username='" + tbname.Text + "', password='" + tbpass.Text + "', email='" + tbemail.Text + "'where id ='" + listBox1.SelectedItem.ToString() + "'and username='" + listBox2.SelectedItem.ToString() + "'and password='" + listBox3.SelectedItem.ToString() + "'and email='" + listBox4.SelectedItem.ToString() + "'";
               // cmd.CommandText = "update users set id ='" + tbid.Text + "','" + tbname.Text + "','" + tbpass.Text + "','" + tbemail.Text + "' where id ='" + listBox1.SelectedItem.ToString() + "'and username='" + listBox2.SelectedItem.ToString() + "'and password='" + listBox3.SelectedItem.ToString() + "'and email='" + listBox4.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record Updated", "CRUD");
                loadlist();
                tbid.Text = "";
                tbname.Text = "";
                tbpass.Text = "";
                tbemail.Text = "";
            }
        }
       
    }
}
