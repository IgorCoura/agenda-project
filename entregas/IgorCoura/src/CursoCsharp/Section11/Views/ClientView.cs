using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section11.Views
{
    public class ClientView
    {
        public void Run()
        {
            Console.WriteLine("");
             
        }

        private string Option()
        {
            Console.WriteLine("1 - Register client.");
            Console.WriteLine("2 - Update client.");
            Console.WriteLine("3 - Remove client.");
            return Console.ReadLine() ?? "";
        }
    }
}
