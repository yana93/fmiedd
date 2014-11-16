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
    public partial class frmEditUsers : Form
    {
        public frmEditUsers()
        {
            InitializeComponent();

            // TODO: This line of code loads data into the 'phoneBook.Phones' table. You can move, or remove it, as needed.
            this.phonesTableAdapter.Fill(this.dsPhoneBook.Phones);
            // TODO: This line of code loads data into the 'phoneBook.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.dsPhoneBook.Users);
        }

        private void AdjustControlsAvailability()
        {
            btnEditUser.Enabled = bsUsers.Current != null;
            btnDeleteUser.Enabled = bsUsers.Current != null;

            btnNewPhone.Enabled = bsUsers.Current != null;
            btnEditPhone.Enabled = bsPhones.Current != null;
            btnDeletePhone.Enabled = bsPhones.Current != null;
        }

        private void frmEditUsers_Load(object sender, EventArgs e)
        {
            

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            DataRowView newUser = (DataRowView)bsUsers.AddNew();

            frmUser frmEditUsers = new frmUser(newUser);
            DialogResult result = frmEditUsers.ShowDialog();

            if (result == DialogResult.OK)
            {
                bsUsers.EndEdit();
                usersTableAdapter.Update(dsPhoneBook);

                dsPhoneBook.Users.Clear();
                usersTableAdapter.Fill(dsPhoneBook.Users);
            }

            else
                bsUsers.CancelEdit();

            AdjustControlsAvailability();
        }

        private void bsUsers_CurrentChanged(object sender, EventArgs e)
        {
            if (this.bsUsers.Current == null)
            {
                return;
            }

            DataRowView user = (DataRowView)bsUsers.Current;
            String filter = "user_id = " + user["id"].ToString();

            bsPhones.Filter = filter;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (bsUsers.Current == null)
                return;

            DataRowView editUser = (DataRowView)bsUsers.Current;

            frmUser editForm = new frmUser(editUser);
            DialogResult result = editForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                bsUsers.EndEdit();
                usersTableAdapter.Update(dsPhoneBook);
            }
            else
                bsUsers.CancelEdit();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (bsUsers.Current == null)
                return;

            DialogResult result = MessageBox.Show(
                            "Delete user",
                            "Delete user",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bsUsers.RemoveCurrent();
                    usersTableAdapter.Update(dsPhoneBook);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Delete failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    bsUsers.CancelEdit();
                    dsPhoneBook.RejectChanges();
                }
            }

            AdjustControlsAvailability();
        }

        private void btnNewPhone_Click(object sender, EventArgs e)
        {
            if (bsUsers.Current == null)
                return;

            DataRowView user = (DataRowView)bsUsers.Current;
            DataRowView newPhone = (DataRowView)bsPhones.AddNew();
            newPhone["user_id"] = user["id"];

            frmPhone editForm = new frmPhone(newPhone);
            DialogResult result = editForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                bsPhones.EndEdit();
                phonesTableAdapter.Update(dsPhoneBook);  

                dsPhoneBook.Phones.Clear();
                phonesTableAdapter.Fill(dsPhoneBook.Phones);
            }
            else
                bsPhones.CancelEdit();

            AdjustControlsAvailability();
        }

        private void btnEditPhone_Click(object sender, EventArgs e)
        {
            if (bsPhones.Current == null)
                return;

            DataRowView newPhone = (DataRowView)bsPhones.Current;

            frmPhone editForm = new frmPhone(newPhone);
            DialogResult result = editForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                bsPhones.EndEdit();
                phonesTableAdapter.Update(dsPhoneBook);
            }
            else
                bsPhones.CancelEdit();
        }

        private void btnDeletePhone_Click(object sender, EventArgs e)
        {
            if (bsPhones.Current == null)
                return;

            DialogResult result = MessageBox.Show(
                            "Delete phone",
                            "Delete phone",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                bsPhones.RemoveCurrent();
                phonesTableAdapter.Update(dsPhoneBook);
            }

            AdjustControlsAvailability();
        }
    }
}
