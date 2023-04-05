using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library;

public class People
{
    public string FirstName { get; }
    public string LastName { get; }
    public List<Loan> BorrowedBooks { get; private set; }

    public People(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        BorrowedBooks = new List<Loan>();
    }

    public People(string Hej)
    {

    }

    public void BorrowBook(Book book)
    {
        Loan loan = new Loan(book, DateTime.Now.AddDays(30));
        BorrowedBooks.Add(loan);
    }

    public void ReturnBook(Loan loan)
    {
        BorrowedBooks.Remove(loan);
    }

    public bool CheckUser(List<People> people)
    {
        foreach (People person in people)
        {
            if (person.FirstName.Equals(FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                person.LastName.Equals(LastName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public void PrintOutBorrowedBooks()
    {
        for (int i = 0; i < BorrowedBooks.Count; i++)
        {
            Console.WriteLine($"[{i + 1}]: {BorrowedBooks[i].Book.Title}");
        }
    }
}


