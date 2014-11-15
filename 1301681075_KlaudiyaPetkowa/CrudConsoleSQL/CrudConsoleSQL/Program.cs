using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsoleSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Login log = new Login();
            log.SystemLogin();

            Table table = new Table();
            table.uTable();

            Console.ReadKey(true);
        }
    }
}
