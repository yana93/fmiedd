using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.View
{
    class StartPage
    {
        public void FistPage()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to my application!");
            Console.WriteLine("To continue press any key or ESC to exit");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Escape)
            {
                Environment.Exit(1);
            }
            Console.Clear();
        }
    }
}
