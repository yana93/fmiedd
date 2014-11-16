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
using System.IO;

namespace StudentsDB
{

    public partial class DBSheet : Form
    {
        SqlCommandBuilder sqlcmb;
        SqlConnection dataConnect = new SqlConnection(@"Data Source=INVICTUS\MSSQLDATABASES;Initial Catalog=STUDENTS;Integrated Security=True");
        AddNewUser add = new AddNewUser();

        public DBSheet()
        {
            InitializeComponent();
        }

        private void DBSheet_Load(object sender, EventArgs e)
        {
        }
        private void DBSheet_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentsDS.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.studentsDS.Users);
            this.statusLabel.Text = "Currently, we have: " + dataGridView2.RowCount.ToString() + " student(s) in our system!";

        }

        #region MENU ITEMS
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add.Show();
            this.Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcmb = new SqlCommandBuilder();
                this.usersTableAdapter.Update(this.studentsDS.Users);
                MessageBox.Show("Information Update!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export();
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, Administrator! This is a new tool for handling a database information of a students. It's still in beta version, so if u found a new bug or exploit, feel free to contact with us by e-mail : gfx.furriouss@gmail.com! \n \n FTD Corp. © ", "Information about StudentsDB v0.1", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region DELETE REGION
        private void menuDelete_Click(object sender, EventArgs e)
        {
            Delete();
            this.usersTableAdapter.Update(this.studentsDS.Users);
        }

        private void Delete()
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                this.usersTableAdapter.Update(this.studentsDS.Users);
            }
        }
        #endregion

        #region OTHER FUNCTIONS
        void Export()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\exportedData\current_data.txt");

            try
            {
                string sLine = "";

                for (int r = 0; r <= dataGridView2.Rows.Count - 1; r++)
                {
                    for (int c = 0; c <= dataGridView2.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dataGridView2.Rows[r].Cells[c].Value;
                        if (c != dataGridView2.Columns.Count - 1)
                        {
                            sLine = sLine + "|";
                        }
                    }
                    file.WriteLine(sLine);
                    sLine = "";
                }

                file.Close();
                System.Windows.Forms.MessageBox.Show("Exportlete.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }
        private void DBSheet_FormClosing(object sender, FormClosingEventArgs a)
        {
            a.Cancel = true;
            this.Hide();
        }
        #endregion


    }
        
}

