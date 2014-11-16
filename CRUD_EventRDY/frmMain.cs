using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace CRUD_EventRDY
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tsbCreate_Click(object sender, EventArgs e)
        {
            frmCreate frmCreate = new frmCreate();
            frmCreate.Show();
        }

        private void tsbRead_Click(object sender, EventArgs e)
        {
            listboxUsers.Items.Clear();
            listboxPass.Items.Clear();
            listboxNames.Items.Clear();
            listboxEmail.Items.Clear();
            SqlCeConnection conn = new SqlCeConnection();
            conn.ConnectionString = @"Data Source=..\..\UsersLOG.sdf";
            string sqlQuery = "SELECT * FROM UsersDBLOG";
            SqlCeCommand cmd = new SqlCeCommand(sqlQuery, conn);
            conn.Open();
            SqlCeDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                listboxUsers.Items.Add(rd.GetValue(0).ToString());
                listboxNames.Items.Add(rd.GetValue(1).ToString());
                listboxPass.Items.Add(rd.GetValue(2).ToString());
                listboxEmail.Items.Add(rd.GetValue(3).ToString());
            }
            conn.Close();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            frmEdit frmEdit = new frmEdit();
            if (listboxUsers.SelectedIndex==-1)
            {
                MessageBox.Show("You need to select a record first, if no records click Read button!");
            }else frmEdit.Show();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (listboxUsers.SelectedIndex != -1)
            {
                SqlCeConnection sqlConnection1 = new SqlCeConnection();
                sqlConnection1.ConnectionString = @"Data Source=..\..\UsersLOG.sdf";

                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from UsersDBLOG where username='" + listboxUsers.SelectedItem.ToString() + "';";
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                if (listboxUsers.SelectedIndex != -1)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfuly deleted, click button Read to refresh!");
                }
                else MessageBox.Show("Select username to delete!", "Error!");
            }
            else MessageBox.Show("Please select username!");
        }

        private void listboxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxNames.SelectedIndex = listboxUsers.SelectedIndex;
            listboxPass.SelectedIndex = listboxUsers.SelectedIndex;
            listboxEmail.SelectedIndex = listboxUsers.SelectedIndex;

            frmEdit.selecteditemUsers = listboxUsers.SelectedItem.ToString();
            frmEdit.selecteditemPass = listboxPass.SelectedItem.ToString();
            frmEdit.selecteditemNames = listboxNames.SelectedItem.ToString();
            frmEdit.selecteditemEmail = listboxEmail.SelectedItem.ToString();
        }
    }
}
