using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCRUD1301681007_3attempt
{
    public partial class frmPhone : Form
    {
        private DataRowView _row;

        public frmPhone(DataRowView row)
        {
            InitializeComponent();

            _row = row;
            this.tbPhones.Text = Convert.ToString(_row["phones"]);
        }

        private void lblPhones_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _row["phones"] = this.tbPhones.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
