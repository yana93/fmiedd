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
    public partial class FrmViewStudents : Form
    {
        DB_Access dba = new DB_Access();

        public FrmViewStudents()
        {
            InitializeComponent();
        }

        private void FrmViewStudents_Load(object sender, EventArgs e)
        {
            DataSet ds = dba.FillStudentGrid("SELECT * FROM Students", "Students");
            dgvStudentData.DataSource = ds.Tables["Students"].DefaultView;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
