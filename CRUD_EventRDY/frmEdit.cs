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
    public partial class frmEdit : Form
    {
        public static string register = null;
        public static string selecteditemUsers = null;
        public static string selecteditemNames = null;
        public static string selecteditemPass = null;
        public static string selecteditemEmail = null;

        public frmEdit()
        {
            InitializeComponent();

            if (selecteditemUsers != null && selecteditemNames != null && selecteditemPass != null && selecteditemEmail != null)
            {
                tbUsr.Text = selecteditemUsers;
                tbNames.Text = selecteditemNames;
                tbPass.Text = selecteditemPass;
                tbEmail.Text = selecteditemEmail;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = @"Data Source=..\..\UsersLOG.sdf";

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update UsersDBLOG set username='" + tbUsr.Text + "', names ='" + tbNames.Text + "', password='"+tbPass.Text+"', email='"+tbEmail.Text+"' where username='"+selecteditemUsers+"';";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Record successfuly edited, click Read button to refresh!");
            this.Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
