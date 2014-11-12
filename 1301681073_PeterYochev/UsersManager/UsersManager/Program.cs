using System;
using System.Windows.Forms;

namespace UsersManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin formLogin = new FormLogin();
            DialogResult loginResult = formLogin.ShowDialog();

            if (loginResult == DialogResult.OK)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
