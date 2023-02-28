using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class BookRepository
    {
        public List<Book> books = new List<Book>();

        public IEnumerable<Book>? SearchAuthor(string key)
        {
            IEnumerable<Book> matchesAuthor = books.Where(b => b.Author.Contains(key));
            return matchesAuthor;
        }

        public IEnumerable<Book>? SearchReleaseDate(int key)
        {
            IEnumerable<Book> matchesReleaseDate = books.Where(b => b.PublishedYear == key);
            return matchesReleaseDate;
        }

        public IEnumerable<Book>? SearchTitle(string key)
        {
            IEnumerable<Book> matchesTitle = books.Where(b => b.Title.Contains(key, StringComparison.InvariantCultureIgnoreCase));
            return matchesTitle;
        }

        public bool BookInStock(int key)
        {
            if (books[key].Stock > 0)
            {
                return true;
            }
            return false;
        }
        public void PrintBooks()
        {
            foreach (Book book in books)
            {
                Console.Write($"\n\tTitle: '{book.Title}' Author: {book.Author} Published: {book.PublishedYear}");
            }
        }

        public void AddBook(string title, string author, int published, int stock)
        {
            books.Add(new Book(title, author, published, stock));
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
