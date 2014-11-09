using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _1301681029_NikolaiValkov_project
{
    public partial class Form1 : Form
    {

        private void crudFunc(string zaqvka)
        {
            SqlConnection sqlc = new SqlConnection(@"Data Source=НИКСАН-PC\SQLEXPRESS;Initial Catalog=users :);Integrated Security=True");
            try
            {
                sqlc.Open();
                statusLbl.Text = "Connection state succesfully";
                SqlCommand cmd = sqlc.CreateCommand();
                cmd.CommandText = zaqvka;
                try
                {
                    cmd.ExecuteNonQuery();
                    statusLbl.Text = "Record inserted successfully!";
                    sqlc.Close();
                }
                catch (Exception le)
                {
                    MessageBox.Show(le.Message);
                    statusLbl.Text = "Record fail!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void reader()
        {
            listBox1.Items.Clear();
            //Data Source=НИКСАН-PC\SQLEXPRESS;Initial Catalog=c-sharp-project;Integrated Security=True"
            //Data Source=НИКСАН-PC\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
            SqlConnection sqlc = new SqlConnection(@"Data Source=НИКСАН-PC\SQLEXPRESS;Initial Catalog=users :);Integrated Security=True");
            try
            {
                sqlc.Open();
                statusLbl.Text = "Connection state succesfully";
                SqlCommand cmd = sqlc.CreateCommand();
                cmd.CommandText = @"SELECT ID, NAME, ADDRESS, PASSWORD from Table_1";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listBox1.Items.Add(id.ToString() + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3));
                }
                reader.Close();
                try
                {
                    cmd.ExecuteNonQuery();
                    statusLbl.Text = "Readed successfully!";
                    sqlc.Close();
                }
                catch (Exception le)
                {
                    MessageBox.Show(le.Message);
                    statusLbl.Text = "Can't read!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reader();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //crudFunc("Insert into Table_1( [ID],[NAME],[ADDRESS],[PASSWORD] ) values('" + Convert.ToInt32(txtId.Text) + "','" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtPass.Text + "')");
            if (txtId.Text == null && txtUserName.Text == null && txtPass.Text == null && txtEmail.Text == null)
            {
                statusLbl.Text = "Не сте попълнили някое поле!";
            }
            else
            {
                int isInteger;
                if (int.TryParse(txtId.Text, out isInteger))
                {
                    if (txtUserName.Text.Length < 50 && txtPass.Text.Length < 50 && txtEmail.Text.Length < 50)
                    {
                        crudFunc("Insert into Table_1( [ID],[NAME],[ADDRESS],[PASSWORD] ) values('" + Convert.ToInt32(txtId.Text) + "','" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtPass.Text + "')");
                        statusLbl.Text = "Записът е успешен!";
                        reader();
                    }
                    else
                    {
                        statusLbl.Text = "Error";
                    }
                }
                else
                {
                    statusLbl.Text = "ID-то полето не е число!";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selecteditem = listBox1.SelectedItem.ToString();
                string selectedItemId = selecteditem.Substring(0, selecteditem.IndexOf(" "));
                if (selectedItemId != "")
                {
                    crudFunc(@"Delete from Table_1 WHERE (ID='" + selectedItemId + "')");
                    statusLbl.Text = "Записът е изтрит успешно!";
                    reader();
                }
                else
                {
                    statusLbl.Text = "Не сте избрали запис!";
                }
            }
            else
            {
                statusLbl.Text = "Не сте избрали запис!";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == null && txtPass.Text == null && txtEmail.Text == null)
            {
                statusLbl.Text = "Не сте попълнили някое поле!";
            }
            else
            {
                string selecteditem = listBox1.SelectedItem.ToString();
                string selectedItemId = selecteditem.Substring(0, selecteditem.IndexOf(" "));
                if (listBox1.SelectedItem != null)
                {
                    if (txtUserName.Text.Length < 50 && txtPass.Text.Length < 50 && txtEmail.Text.Length < 50)
                    {
                        crudFunc(@"Update Table_1 
                        SET NAME ='" + txtUserName.Text + "',ADDRESS='" + txtEmail.Text + "', PASSWORD='" + txtPass.Text + "'WHERE (ID='" + selectedItemId + "')");
                        statusLbl.Text = "Ъпдейта е успешен!";
                        reader();
                    }
                    else
                    {
                        statusLbl.Text = "Error";
                    }
                }
                else
                {
                    statusLbl.Text = "Не сте избрали запис за update!";
                }
            }
        }
    }
}
