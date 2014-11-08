using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B.DataClass;
namespace B
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public void GeneratorNewGame()
        {
            
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            
            
            AuthenticationService.AuthenticateUser(tbUsername.Text, tbPassword.Text);

            if (AuthenticationService.LoggedUser == null)
            {
                tbUsername.BackColor = Color.IndianRed;
                tbPassword.BackColor = Color.IndianRed;
            }

            else
            {               
                this.Hide();                                //change
                Sudoku formSudoku = new Sudoku();
                formSudoku.Show();
                formSudoku.Activate();
            }
        }

        private void btNewAccount_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddAccount addForm = new AddAccount();
            addForm.Owner = this;
            addForm.Show();
            addForm.Focus();
        }
    }
}
