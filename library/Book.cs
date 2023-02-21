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
    public int PublishedYear { get; }
    public int Stock { get; set; }

    public Book(string title, string author, int published, int stock)
    {
        Title = title;
        Author = author;
        PublishedYear = published;
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

    public IEnumerable<Book> SearchAuthor(string key, List<Book> books)
    {
        return books.Where(b => b.Author.Equals(key, StringComparison.InvariantCultureIgnoreCase));
    }

    public IEnumerable<Book> SearchReleaseDate(string key, List<Book> books)
    {
        return books.Where(b => b.PublishedYear.ToString().Equals(key));
    }

    // Partial matching, multiple results
    // Abandon the binary search for now, return a list of books that match the title 
    // Class that manages the searches of books etc. 
    public IEnumerable<Book> SearchTitle(string key, List<Book> books)
    {
        return books.Where(b => b.Title.Equals(key, StringComparison.InvariantCultureIgnoreCase));
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

                if (books[j].PublishedYear > books[min].PublishedYear)
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
            Console.Write($"\n\tTitle: '{book.Title}' Author: {book.Author} Published: {book.PublishedYear}");
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
