using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library;

internal class People
{
    public string FirstName { get; }
    public string LastName { get; }
    public List<Loan>? BorrowedBooks { get; private set; }

    public People(string firstName, string lastName, List<Loan> borrowedBooks)
    {
        FirstName = firstName;
        LastName = lastName;
        BorrowedBooks = borrowedBooks;
    }

    public bool BorrowBook(string bookTitle, List<Book> books, People user)
    {
        foreach (Book book in books)
        {
            if (bookTitle.Equals(book.Title, StringComparison.InvariantCultureIgnoreCase))
            {
                Loan loan = new Loan(book.Title, DateTime.Now.AddDays(30));
                user.BorrowedBooks.Add(loan);
                book.Stock--;
                return true;
            }
        }
        Console.WriteLine("Couldn't find the book you were searching for");
        return false;
    }

    public void ReturnBook(string bookTitle, List<Book> books, People user)
    {
        foreach (Loan loanedBook in user.BorrowedBooks)
        {
            if (bookTitle.Equals(loanedBook.TitleOfBook, StringComparison.InvariantCultureIgnoreCase))
            {
                user.BorrowedBooks.Remove(loanedBook);

                foreach (Book book in books)
                {
                    if (bookTitle.Equals(book.Title, StringComparison.InvariantCultureIgnoreCase))
                    {
                        book.Stock++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please re-enter the title of the book");
            }
        }
    }

    public bool CheckUser(People user, List<People> people)
    {
        foreach (People person in people)
        {
            if (person.FirstName.Equals(user.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                person.LastName.Equals(user.LastName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public bool RegisterUser(string firstName, string lastName)
    {
        if (firstName != "" && lastName != "")
        {
            return true;
        }
        return false;
    }
}


