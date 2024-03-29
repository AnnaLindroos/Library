﻿using library;
using System.Reflection.Metadata;
using System.Xml.Serialization;

List<People> people = new List<People>();

BookRepository bookRepository = new BookRepository();

bookRepository.AddBook("The Boy in the Striped Pyjamas", "John Boyne", 2006, 1, 1);
bookRepository.AddBook("The Fellowship of the Ring", "J.R.R. Tolkien", 1954, 3, 2);
bookRepository.AddBook("Know Why the Caged Bird Sings", "Maya Angelou", 1969, 1, 3);
bookRepository.AddBook("East of Eden", "John Steinbeck", 1952, 1, 4);
bookRepository.AddBook("The Hunger Games", "Suzanne Collins", 2008, 2, 5);

Console.WriteLine("Welcome to the library! Please register an account:");
People user = ConsoleHelper.WelcomeUser();

while (user == null)
{
    user = ConsoleHelper.WelcomeUser();
}

people.Add(user);

bool on = true;
while (on)
{
    string choice = ConsoleHelper.PrintMainMenu();

    switch (choice)
    {
        case "1":
            bookRepository.PrintBooks();
            break;

        case "2":
            string selectedSearch = ConsoleHelper.PrintSearchByMenu();
            switch (selectedSearch)
            {
                case "1":
                    Console.WriteLine("Please enter the title of the book: ");
                    string title = Console.ReadLine();
                    IEnumerable<Book> matchesTitle = bookRepository.SearchByTitle(title);
                    ConsoleHelper.PrintOutSearchedBook(matchesTitle);
                    break;

                case "2":
                    Console.WriteLine("Please enter the author of the book: ");
                    string author = Console.ReadLine();
                    IEnumerable<Book> matchesAuthor = bookRepository.SearchByAuthor(author);
                    ConsoleHelper.PrintOutSearchedBook(matchesAuthor);
                    break;

                case "3":
                    Console.WriteLine("Please enter in which year the book was published");
                    int.TryParse(Console.ReadLine(), out int releaseDate);
                    IEnumerable<Book> matchesReleaseDate = bookRepository.SearchByReleaseDate(releaseDate);
                    ConsoleHelper.PrintOutSearchedBook(matchesReleaseDate);
                    break;

                default:
                    Console.WriteLine("Please select a number between 1 and 3");
                    break;
            }
            Console.ReadLine();
            break;

        case "3":
            string titleOfBookToBorrow = ConsoleHelper.PromptUserForBookTitleToBorrow();
            IEnumerable<Book> matchingBookTitles = bookRepository.SearchByTitle(titleOfBookToBorrow);

            while (matchingBookTitles.Count() != 1)
            {
                titleOfBookToBorrow = ConsoleHelper.PromptUserForBookTitleToBorrow();
                matchingBookTitles = bookRepository.SearchByTitle(titleOfBookToBorrow);
            }

            var matchingBook = matchingBookTitles.First();

            if (matchingBook.BookInStock() == true)
            {
                Console.WriteLine($"Found the following book: {matchingBook.Title} by {matchingBook.Author} released in {matchingBook.PublishedYear}.");
                string answer = ConsoleHelper.PromptUserForString("Is this the book you want to borrow?");
                if (answer.Contains("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    user.BorrowBook(matchingBook);
                    Console.WriteLine("Rental succeeded!");
                    bookRepository.CheckOutBookDecreaseStock(matchingBook);
                }
                break;
            }
            else
            {
                matchingBook.BackInStock(people);
                break;
            }

        case "4":
            Console.WriteLine("Please select which book to return: ");
            user.PrintOutBorrowedBooks();
            int.TryParse(Console.ReadLine(), out int chosenBook);
            Loan bookToReturn = user.BorrowedBooks.ElementAt(chosenBook - 1);
            user.ReturnBook(bookToReturn);
            bookRepository.ReturnBookIncreaseStock(bookToReturn.Book);
            Console.WriteLine("Thank you, come again");
            break;

        case "5":
            if (user.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("You have no borrowed books!");
            }
            else
            {
                Console.WriteLine("Your borrowed books are the following...");
                user.PrintOutBorrowedBooks(); 
            }
            break;

        default:
            break;
    }
    Console.ReadLine();
}