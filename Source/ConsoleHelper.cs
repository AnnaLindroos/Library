using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal static class ConsoleHelper
    {
        public static string SearchBy()
        {
            Console.WriteLine("Would you like to search for a book by...");
            Console.WriteLine("[1] Title");
            Console.WriteLine("[2] Author");
            Console.WriteLine("[3] Release Date");

            return Console.ReadLine();
        }
    }

}
