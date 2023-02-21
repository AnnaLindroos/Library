using library;
using System.Reflection.Metadata;
using System.Xml.Serialization;

Book book = new Book("The Hunger Games", "Suzanne Collins", 2008, 2);

People person = new People("Anna", "Lindroos", null);

List<Book> books = new List<Book>();

List<People> people = new List<People>();

books.Add(book);
books.Add(new Book("The Boy in the Striped Pyjamas", "John Boyne", 2006, 1));
books.Add(new Book("The Fellowship of the Ring", "J.R.R. Tolkien", 1954, 3));
books.Add(new Book(" Know Why the Caged Bird Sings", "Maya Angelou", 1969, 1));
books.Add(new Book("East of Eden", "John Steinbeck", 1952, 1));

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
            book.PrintBooks(books);
            break;

        case "2":
            string selectedSearch = book.SearchBy(books);
            switch (selectedSearch)
            {
                case "1":
                    Console.WriteLine("Please enter the title of the book: ");
                    string title = Console.ReadLine();
                    book.OrderByTitle(books);
                    int indexTitle = book.BinarySearchTitle(title, books);
                    if (indexTitle != -1)
                    {
                        Console.WriteLine($"Found the following book: {books[indexTitle].Title} by {books[indexTitle].Author} released in {books[indexTitle].Published}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter the author of the book: ");
                    string author = Console.ReadLine();
                    book.OrderByAuthor(books);
                    int indexAuthor = book.BinarySearchTitle(author, books);
                    if (indexAuthor != -1)
                    {
                        Console.WriteLine($"Found the following book: {books[indexAuthor].Title} by {books[indexAuthor].Author} released in {books[indexAuthor].Published}");
                    }
                    break;
                case "3":
                    Console.WriteLine("Please enter in which year the book was published");
                    book.OrderByReleaseDate(books);
                    string releaseDate = Console.ReadLine();
                    book.OrderByReleaseDate(books);
                    int indexReleaseDate = book.BinarySearchReleaseDate(releaseDate, books);
                    if (indexReleaseDate != -1)
                    {
                        Console.WriteLine($"Found the following book: {books[indexReleaseDate].Title} by {books[indexReleaseDate].Author} released in {books[indexReleaseDate].Published}");
                    }
                    break;
                default:
                    Console.WriteLine("Please select a number between 1 and 3");
                    break;
            }
            break;

        case "3":
            Console.Write("Please enter the title of the book you want to borrow: ");
            string borrow = Console.ReadLine();
            book.OrderByTitle(books);
            int index = book.BinarySearchTitle(borrow, books);
            if (book.BookInStock(books, index) == true)
            {
                person.BorrowBook(borrow, books, user);
            }
            else
            {
                Console.WriteLine("The book is out of stock...");
                book.BackInStock(books[index].Title, people, user);
            }
            break;

        case "4":
            Console.Write("Please enter the title of the book you want to return: ");
            string leave = Console.ReadLine();
            person.ReturnBook(leave, books, user);
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