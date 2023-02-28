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
            BookRepository bookrepository = new BookRepository();
            // Act: Doing the thing that I'm testing - our act in this case is calling the Addbook function
            bookrepository.AddBook("bajs", "hej", 2015, 2);
            // Assert: Verifying thet my expectation is correct - assuring that reality matches what I'm expecting, there are many different ways
            // OPTION 1: Assert.AreEqual(1, bookrepository.books.Count);
            // OPTION 2: Assert.That(bookrepository.books, Has.Count.EqualTo(1));
            // OPTION 3: Assert.That(bookrepository.books.Count, Is.EqualTo(1));
        }
    }

    // Write some tests around search for title, split into different tests:
    // Test 1: When iu call searchbytitle and there are no books, i should get an empty collection (IEnumaerable) back
    // Test 2: when i search for a title and ther is a book, i get back a collection with a single book in it (with the RIGHT book in it back!)
    // Test 3: case insensitivoty, verifying thet the method is case ionsentive. 
    // Test 4: whem there are multiple books and i search for a title, (for ex ring and 3 books have that word in it) i get a collection with however many those books are (with the RIGHT books in it)
}
