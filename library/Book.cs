using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library;

internal class Book
{
    public string Title { get; }
    public string Author { get; }
    public int Published { get; }
    public int Stock { get; set; }

    public Book(string title, string author, int published, int stock)
    {
        Title = title;
        Author = author;
        Published = published;
        Stock = stock;
    }

    public void BackInStock(string booktitle, List<People> people, People user)
    {
        List<Loan> rentedCopies = new List<Loan>();

        foreach (People person in people)
        {
            foreach (Loan book in person.BorrowedBooks)
            {
                if (booktitle.Equals(book.TitleOfBook, StringComparison.InvariantCultureIgnoreCase))
                {
                    rentedCopies.Add(book);
                }
            }
        }
        int fastest = 0;
        for (int i = 1; i < rentedCopies.Count; i++)
        {
            if (rentedCopies[fastest].LengthOfLoan.CompareTo(rentedCopies[i].LengthOfLoan) < 0)
            {
                fastest = i;
            }
        }

        Console.WriteLine($"One copy of the book will be back on {fastest}....");
    }

    public int BinarySearchAuthor(string key, List<Book> books)
    {
        int first = 0;
        int last = books.Count - 1;

        while (first <= last)
        {
            int middle = (first + last) / 2;

            if (key.CompareTo(books[middle].Author) > 0)
            {
                first = middle + 1;
            }
            else if (key.CompareTo(books[middle].Author) < 0)
            {
                last = middle - 1;
            }
            else
            {
                return middle;
            }
        }
        Console.WriteLine("Couldn't find what you were searching for");
        return -1;
    }

    public int BinarySearchReleaseDate(string key, List<Book> books)
    {
        int first = 0;
        int last = books.Count - 1;

        while (first <= last)
        {
            int middle = (first + last) / 2;

            if (key.CompareTo(books[middle].Published) > 0)
            {
                first = middle + 1;
            }
            else if (key.CompareTo(books[middle].Published) < 0)
            {
                last = middle - 1;
            }
            else
            {
                return middle;
            }
        }
        Console.WriteLine("Couldn't find what you were searching for");
        return -1;
    }

    // Partial matching, case insensitivity, multiple results
    // Class that manages the searches of books etc. 
    public int BinarySearchTitle(string key, List<Book> books)
    {
        int first = 0;
        int last = books.Count - 1;

        while (first <= last)
        {
            int middle = (first + last) / 2;

            if (string.Compare(key, books[middle].Title, true) > 0)
            {
                first = middle + 1;
            }
            else if (string.Compare(key, books[middle].Title, true) < 0)
            {
                last = middle - 1;
            }
            else
            {
                return middle;
            }
        }
        Console.WriteLine("Couldn't find what you were searching for");
        return -1;
    }

    public bool BookInStock(List<Book> books, int key)
    {
        if (books[key].Stock > 0)
        {
            return true;
        }
        return false;
    }

    public void OrderByAuthor(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = (i + 1); j < books.Count; j++)
            {
                int min = i;

                if (books[j].Author.CompareTo(books[min].Author) < 0)
                {
                    min = j;
                }

                if (min != i)
                {
                    Book temp = books[min];
                    books[min] = books[i];
                    books[i] = temp;
                }
            }
        }
    }

    public void OrderByReleaseDate(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = (i + 1); j < books.Count; j++)
            {
                int min = i;

                if (books[j].Published > books[min].Published)
                {
                    min = j;
                }

                if (min != i)
                {
                    Book temp = books[min];
                    books[min] = books[i];
                    books[i] = temp;
                }
            }
        }
    }

    public void OrderByTitle(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = (i + 1); j < books.Count; j++)
            {
                int min = i;

                if (books[j].Title.CompareTo(books[min].Title) < 0)
                {
                    min = j;
                }

                if (min != i)
                {
                    Book temp = books[min];
                    books[min] = books[i];
                    books[i] = temp;
                }
            }
        }
    }

    public void PrintBooks(List<Book> books)
    {
        foreach (Book book in books)
        {
            Console.Write($"\n\tTitle: '{book.Title}' Author: {book.Author} Published: {book.Published}");
        }
    }

    public string SearchBy(List<Book> books)
    {
        Console.WriteLine("Would you like to search for a book by...");
        Console.WriteLine("[1] Title");
        Console.WriteLine("[2] Author");
        Console.WriteLine("[3] Release Date");

        return Console.ReadLine();
    }

}
