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
    public partial class FrmDeleteStudent : Form
    {
        DB_Access dba = new DB_Access();

        public FrmDeleteStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete selected student?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (dba.DeleteUsers(cmbStudentName.Text))
                {
                    MessageBox.Show("Studnet Successfully Deleted!");
                    FillStudentNameList();
                }
                else
                {
                    MessageBox.Show("Error Deleting the Student. Please try again!");
                }
            }   
        }
        public void FillStudentNameList()
        {
            DataTable tb1 = dba.FillStudentsList();
            cmbStudentName.ValueMember = "Fname";
            cmbStudentName.DisplayMember = "studentname";
            cmbStudentName.DataSource = tb1;
        }

        private void FrmDeleteStudent_Load(object sender, EventArgs e)
        {
            FillStudentNameList();
        }
    }
}
