using library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class BookRepositoryTests
    {
        // Public voids, all methods
        // Try to be explicit about things, like "I expect one book to be in my list for now". Writing multiple tests for the same method.
        [Test]
        public void AddBookWorks()
        {
            // Arrange: create classes that are needed for this test (bookrepository in this case)
            BookRepository bookRepository = new BookRepository();
            // Act: Doing the thing that I'm testing - our act in this case is calling the Addbook function
            bookRepository.AddBook("bajs", "hej", 2015, 2, 1);
            // Assert: Verifying thet my expectation is correct - assuring that reality matches what I'm expecting, there are many different ways of doing this
            /* OPTION 1:*/ Assert.AreEqual(1, bookRepository.books.Count);
            // OPTION 2: Assert.That(bookrepository.books, Has.Count.EqualTo(1));
            // OPTION 3: Assert.That(bookrepository.books.Count, Is.EqualTo(1));
        }

        // Write some tests around search for title, split into different tests:  

        [Test]
        public void SearchTitleNoBooks()
        {
            // Test 1: When i call searchbytitle and there are no books, i should get an empty collection (IEnumaerable) back
            BookRepository bookRepository = new BookRepository();

            bookRepository.AddBook("bajs", "hej", 2015, 2, 1);

            IEnumerable<Book> booksBack = bookRepository.SearchByTitle("xzpsp");

            Assert.Zero(booksBack.Count());
        }

        [Test]
        public void SearchTitleOneBook()
        {
            // Test 2: when i search for a title and there is a book, i get back a collection with a single book in it (with the RIGHT book in it back!)
            BookRepository bookRepository = new BookRepository();

            bookRepository.AddBook("The Fellowship of the Ring", "J.R.R. Tolkien", 1954, 3, 2);
            bookRepository.AddBook("bajs", "hej", 2015, 2, 1);

            // IEnumerable<Book> booksBack = bookRepository.SearchTitle("fellow");
            IEnumerable<Book> booksBack = bookRepository.SearchByTitle("Fellow");

            Assert.AreEqual(1, booksBack.Count());

            foreach (Book book in booksBack)
            {
                Assert.AreEqual("The Fellowship of the Ring", book.Title);
            }
        }

        // Test 3: case insensitivíty, verifying that the method is case insentive. 
        [Test]
        public void SearchTitleCaseInsensitivity()
        {
            BookRepository bookRepository = new BookRepository();

            bookRepository.AddBook("The Fellowship of the Ring", "J.R.R. Tolkien", 1954, 3, 2);

            IEnumerable<Book> booksBack = bookRepository.SearchByTitle("fellow");

            foreach (Book book in booksBack)
            {
                Assert.AreEqual("The Fellowship of the Ring", book.Title);
            }
        }

        // Test 4: when there are multiple books and i search for a title, (for ex ring and 3 books have that word in it)
        // i get a collection with however many those books are (with the RIGHT books in it)

        [Test]
        public void SearchTitleMultipleBooks()
        {
            BookRepository bookRepository = new BookRepository();

            Book book = new Book("Shirt", "Meg", 2023, 1, 1);

            bookRepository.AddBook(book);
            bookRepository.AddBook("i own a shirt", "Bob", 2022, 1, 2);
            bookRepository.AddBook("wow cool shirt dude", "Dave", 2020, 1, 3);
            bookRepository.AddBook("look at my sweater", "Kyle", 2021, 1, 4);

            Book[] booksBack = bookRepository.SearchByTitle("shirt").ToArray();

            Assert.AreEqual(3, booksBack.Length);

            Assert.AreEqual(book, booksBack[0]);
        }
    }



}
