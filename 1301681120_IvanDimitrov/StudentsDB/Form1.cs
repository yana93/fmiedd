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

namespace StudentsDB
{
    public partial class formLoading : Form
    {
        DBSheet dbForm = new DBSheet();

        public formLoading()
        {
            InitializeComponent();
            
        }

        private void formLoading_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbForm.Show();
        }

        private void formLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

    }
}
