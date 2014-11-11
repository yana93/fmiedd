using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformationSystemCRUDWinForms
{
    public partial class FrmUpdateStudent : Form
    {
        DB_Access dba = new DB_Access();

        public FrmUpdateStudent()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string RegNo = txtRegNo.Text;
            txtFname.Text = dba.ReturnStudentData("RegNo", "Students", RegNo, "Fname");
            txtLname.Text = dba.ReturnStudentData("RegNo", "Students", RegNo, "Lname");
            txtPhoneNo.Text = dba.ReturnStudentData("RegNo", "Students", RegNo, "Phone");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dba.update_students(txtRegNo.Text, txtFname.Text, txtLname.Text, txtPhoneNo.Text);
            MessageBox.Show("Successfully updated");
        }
    }
}
