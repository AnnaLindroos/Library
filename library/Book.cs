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

}
