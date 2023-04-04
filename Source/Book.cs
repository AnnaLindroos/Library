using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library;

public class Book
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

    public bool BookInStock()
    {
        if (Stock > 0)
        {
            return true;
        }
        return false;
    }

    public void BackInStock(List<People> people)
    {
        List<Loan> rentedCopies = new List<Loan>();

        foreach (People person in people)
        {
            foreach (Loan loan in person.BorrowedBooks)
            {
                if (Title.Equals(loan.Book.Title, StringComparison.InvariantCultureIgnoreCase))
                {
                    rentedCopies.Add(loan);
                }
            }
        }
        int fastest = 0;
        for (int i = 1; i < rentedCopies.Count; i++)
        {
            if (rentedCopies[fastest].DueDate.CompareTo(rentedCopies[i].DueDate) < 0)
            {
                fastest = i;
            }
        }
        Console.WriteLine($"Sorry, book is out of stock! One copy of the book will be back on {rentedCopies[fastest].DueDate}....");
    }

}
