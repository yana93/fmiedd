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
    public partial class frmUser : Form
    {
        private DataRowView _row;

        public frmUser(DataRowView row)
        {
            InitializeComponent();

            _row = row;
            if (Convert.ToInt32(_row["id"]) > 0)
            {
                this.Text = "Edit User";
                this.tbFirstName.Text = Convert.ToString(_row["first_name"]);
                this.tbLastName.Text = Convert.ToString(_row["last_name"]);
                this.tbEmail.Text = Convert.ToString(_row["email"]);
            }
            else
                this.Text = "New User";

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _row["first_name"] = tbFirstName.Text;
            _row["last_name"] = tbLastName.Text;
            _row["email"] = tbEmail.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
