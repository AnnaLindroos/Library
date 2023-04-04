using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal static class ConsoleHelper
    {
        public static string PrintSearchByMenu()
        {
            Console.WriteLine("Would you like to search for a book by...");
            Console.WriteLine("[1] Title");
            Console.WriteLine("[2] Author");
            Console.WriteLine("[3] Release Date");

            return Console.ReadLine();
        }

        public static string PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("[1] Browse the library");
            Console.WriteLine("[2] Search for a book");
            Console.WriteLine("[3] Loan a book");
            Console.WriteLine("[4] Return a book");
            Console.WriteLine("[5] View your borrowed books");

            return Console.ReadLine();
        }

        public static string PromptUserForBookTitleToBorrow()
        {
            Console.Write("Please enter the title of the book you want to borrow: ");
            return Console.ReadLine();
        }

        public static People? WelcomeUser()
        {
            Console.Write("Please enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Please enter your last name: ");
            string lastName = Console.ReadLine();

            if (firstName != "" && lastName != "")
            {
                return new People(firstName, lastName);
            }
            return null;
        }
    }

}
