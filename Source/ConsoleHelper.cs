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

        public static string PromptUserForString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static bool PrintOutSearchedBook(IEnumerable<Book> matches)
        {
            if (!matches.Any())
            {
                Console.WriteLine("Sorry, couldn't find what you were searching for");
                return false;
            }
            foreach (Book book in matches)
            {
                Console.WriteLine($"Found the following book: {book.Title} by {book.Author} released in {book.PublishedYear}");
            }
            return true;
        }
        public static People? WelcomeUser()
        {
            string firstName = PromptUserForString("Please enter your first name: ");
            string lastName = PromptUserForString("Please enter your last name: ");
            if (firstName != "" && lastName != "")
            {
                return new People(firstName, lastName);
            }
            return null;
        }
    }

}
