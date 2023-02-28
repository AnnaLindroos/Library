using library;
using System.Reflection.Metadata;
using System.Xml.Serialization;

People person = new People("Anna", "Lindroos", null);

List<People> people = new List<People>();

BookRepository bookRepository = new BookRepository();

bookRepository.AddBook("The Boy in the Striped Pyjamas", "John Boyne", 2006, 1);
bookRepository.AddBook("The Fellowship of the Ring", "J.R.R. Tolkien", 1954, 3);
bookRepository.AddBook(" Know Why the Caged Bird Sings", "Maya Angelou", 1969, 1);
bookRepository.AddBook("East of Eden", "John Steinbeck", 1952, 1);
bookRepository.AddBook("The Hunger Games", "Suzanne Collins", 2008, 2);

Console.WriteLine("Welcome to the library! Please register an account:");
Console.Write("Please enter your first name: ");
string firstName = Console.ReadLine();
Console.Write("Please enter your last name: ");
string lastName = Console.ReadLine();

while (person.RegisterUser(firstName, lastName) == false)
{
    Console.WriteLine("Please enter a first and last name");
}

People user = new People(firstName, lastName, null);

//if (user.CheckUser(user, people) == false)
//{
    people.Add(user);
//}
/* else
{
    Console.WriteLine("Sorry someone with that name already exists and Anna wants to spend time on other issues atm");
}  */

bool on = true;
while (on)
{
    Console.Clear();
    Console.WriteLine("[1] Browse the library");
    Console.WriteLine("[2] Search for a book");
    Console.WriteLine("[3] Loan a book");
    Console.WriteLine("[4] Return a book");
    Console.WriteLine("[5] View your borrowed books");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            bookRepository.PrintBooks();
            break;

        case "2":
            string selectedSearch = ConsoleHelper.SearchBy();
            switch (selectedSearch)
            {
                case "1":
                    // FÖRSÖK HITTA ETT SÄTT ATT TA REDA PÅ OM MATCHESTITLE ÄR TOM ELLER INTE,
                    // ISNULLOREMPTY? ELLER == NULL? (FÖRMODLIGEN INTE; VID DEBUG ÄR DEN INTE NULL MEN DEN HAR INGA VÄRDEN)
                    Console.WriteLine("Please enter the title of the book: ");
                    string title = Console.ReadLine();
                    IEnumerable<Book> matchesTitle = bookRepository.SearchTitle(title);
                    if (!matchesTitle.Any())
                    {
                        Console.WriteLine("Sorry, couldn't find what you were searching for");
                        break;
                    }
                    else
                    { 
                        foreach (Book booktitles in matchesTitle)
                        {
                            Console.WriteLine($"Found the following book: {booktitles.Title} by {booktitles.Author} released in {booktitles.PublishedYear}");
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter the author of the book: ");
                    string author = Console.ReadLine();
                    IEnumerable<Book> matchesAuthor = bookRepository.SearchAuthor(author);
                    if (!matchesAuthor.Any())
                    {
                        Console.WriteLine("Sorry, couldn't find what you were searching for");
                        break;
                    }
                    else
                    {
                        foreach (Book bookauthors in matchesAuthor)
                        {
                            Console.WriteLine($"Found the following book: {bookauthors.Title} by {bookauthors.Author} released in {bookauthors.PublishedYear}");
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Please enter in which year the book was published");
                    int.TryParse(Console.ReadLine(), out int releaseDate);
                    IEnumerable<Book> matchesReleaseDate = bookRepository.SearchReleaseDate(releaseDate);
                    if (!matchesReleaseDate.Any())
                    {
                        Console.WriteLine("Sorry, couldn't find what you were searching for");
                        break;
                    }
                    else
                    {
                        foreach (Book bookReleaseDates in matchesReleaseDate)
                        {
                            Console.WriteLine($"Found the following book: {bookReleaseDates.Title} by {bookReleaseDates.Author} released in {bookReleaseDates.PublishedYear}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Please select a number between 1 and 3");
                    break;
            }
            Console.ReadLine();
            break;

        case "3":
            Console.Write("Please enter the title of the book you want to borrow: ");
            string borrow = Console.ReadLine();
            IEnumerable<Book> matchingTitles = bookRepository.SearchTitle(borrow);
            /* if (book.BookInStock(books, index) == true)
            {
                person.BorrowBook(borrow, books, user);
            }
            else
            {
                Console.WriteLine("The book is out of stock...");
                book.BackInStock(books[index].Title, people, user);
            } */
            break;

        case "4":
            Console.Write("Please enter the title of the book you want to return: ");
            string leave = Console.ReadLine();
            person.ReturnBook(leave, bookRepository.books, user);
            break;

        case "5":
            if (user.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("You have no borrowed books!");
            }
            else
            {
                Console.WriteLine("Your borrowed books are the following...");
                foreach (Loan loanedBook in user.BorrowedBooks)
                {
                    Console.WriteLine(loanedBook.TitleOfBook);
                }
            }
            break;

        default:
            break;
    }
    Console.ReadLine();
}