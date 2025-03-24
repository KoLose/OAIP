using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = "true";
            if (a == "true")
            {
                string b = a.GetType().Name;
                Console.WriteLine(b);
            }
        }
    }
}
