using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDD_111_1082.Presentation;
using System.Threading;

namespace EDD_111_1082
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Title = "C-Mail 2014 © Iva Tsoneva";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();

            StartView sview = new StartView();

            Console.ReadKey(true);
        }
    }
}
