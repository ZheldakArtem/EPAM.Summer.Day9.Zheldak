using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task_Book;

namespace Task4
{
    public class BookListService
    {
        private readonly IBookListStorage _bookListStorage;
        private readonly List<Book> _books;
        public BookListService(IBookListStorage bookListStorage)
        {
            _bookListStorage = bookListStorage;
            _books = LoadBooks();
        }
        /// <summary>
        /// Invoke BinaryBookListStorage's method LoadBooks
        /// </summary>
        /// <returns>Collection of books</returns>
        public List<Book> LoadBooks()
        {
            return _bookListStorage.LoadBooks();
        }
        /// <summary>
        /// Invoke BinaryBookListStorage's method SaveBooks
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            _bookListStorage.SaveBooks(books);
        }
        /// <summary>
        /// Add book to the collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            if (_books.Contains(book))
            {
                return false;
            }
            _books.Add(book);
            return true;
        }

        public bool RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            if (_books.Contains(book))
            {
                _books.Remove(book);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire.
        /// </summary>
        /// <param name="books">Collection of books</param>
        /// <param name="predicate">The delegate that defines the conditions of the element to search for</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type</returns>
        public Book FindBooksByTag(List<Book> books, Predicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null) || ReferenceEquals(books, null))
            {
                throw new ArgumentNullException();
            }
            return books.Find(predicate);
        }
        /// <summary>
        /// Sorts the elements in the collection using the specified delegate.
        /// </summary>
        /// <param name="books">Collection of books</param>
        /// <param name="comparison">The delegate to use when comparing elements.</param>
        public void SortBooksByTag(List<Book> books, Comparison<Book> comparison)
        {
            if (ReferenceEquals(comparison, null) || ReferenceEquals(books, null))
            {
                throw new ArgumentNullException();
            }
            books.Sort(comparison);
        }
    }
}
