using Project_111.Model;
using Project_111.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111
{
    class App
    {
        public void Start()
        {
            LogScreen example = new LogScreen();
            example.Login();
        }

        public void FistPage()
        {
            StartPage Page = new StartPage();
            Page.FistPage();
        }


        UsersModels users = new UsersModels();
    }
}
