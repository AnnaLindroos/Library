using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library;

public class People
{
    public string FirstName { get; }
    public string LastName { get; }
    public List<Loan> BorrowedBooks { get; private set; }

    public People(string firstName, string lastName, List<Loan> borrowedBooks)
    {
        FirstName = firstName;
        LastName = lastName;
        BorrowedBooks = borrowedBooks;
    }

    public void BorrowBook(Book book)
    {
        Loan loan = new Loan(book, DateTime.Now.AddDays(30));
        BorrowedBooks.Add(loan);
    }

    public string TitleBorrowBook()
    {
        Console.Write("Please enter the title of the book you want to borrow: ");
        return Console.ReadLine();
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

    public People ? WelcomeUser()
    {
        Console.Write("Please enter your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Please enter your last name: ");
        string lastName = Console.ReadLine();

        if (firstName != "" && lastName != "")
        {
            return new People(firstName, lastName, new List<Loan>()); ;
        }
        return null;
    }

    public void PrintOutBorrowedBooks()
    {
        for (int i = 0; i < BorrowedBooks.Count; i++)
        {
            Console.WriteLine($"[{i + 1}]: {BorrowedBooks[i].Book.Title}");
        }
    }
}


