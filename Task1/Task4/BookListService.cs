using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public BookListService(IBookListStorage bookListStorage)
        {
            _bookListStorage = bookListStorage;
            _books=new List<Book>();
        }
        /// <summary>
        /// Invoke BinaryBookListStorage's method LoadBooks
        /// </summary>
        /// <returns>Collection of books</returns>
        public List<Book> LoadBooks()
        {
            string storage;
            storage = ConfigurationManager.AppSettings["binary_storage"];
            if (storage =="true")
                return _bookListStorage.BinariDeserialize();

            return _bookListStorage.XMLDeserialize();
        }
        /// <summary>
        /// Invoke BinaryBookListStorage's method SaveBooks
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            string storage;
            storage = ConfigurationManager.AppSettings["binary_storage"];
            if (storage == "true")
                _bookListStorage.BinarySerialize(books);
            else
                _bookListStorage.XMLSerialize(books);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }
        /// <summary>
        /// Adding book to the collection
        /// </summary>
        /// <param name="book">The book wich you want to add.</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("The Argument has a null reference");
                throw new ArgumentNullException(nameof(book));
            }
            if (_books.Contains(book))
            {
                logger.Error("The collection contains book which you want to add");
                throw new ArgumentException(nameof(book));
            }
            _books.Add(book);
            logger.Info("The book added");
        }
        /// <summary>
        /// Adding book from the collection
        /// </summary>
        /// <param name="book">The book wich you want to add.</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("The Argument has a null reference");
                throw new ArgumentNullException(nameof(book));
            }
            if (!_books.Contains(book))
            {
                logger.Error("The collection don't contains book which you want to remove");
                throw new ArgumentException(nameof(book));
            }
            _books.Remove(book);
            logger.Info("The book removed");

        }
        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire.
        /// </summary>
        /// <param name="predicate">The delegate that defines the conditions of the element to search for</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type</returns>
        public Book FindBooksByTag(Predicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                logger.Error($"{nameof(predicate)} has null reference");
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(_books, null))
            {
                logger.Error($"{nameof(_books)} has a null reference");
                throw new ArgumentNullException();
            }
            return _books.Find(predicate);
        }
        /// <summary>
        /// Sorts the elements in the collection using the specified delegate.
        /// </summary>
        /// <param name="comparison">The delegate to use when comparing elements.</param>
        public void SortBooksByTag(Comparison<Book> comparison)
        {
            if (ReferenceEquals(comparison, null))
            {
                logger.Error($"{nameof(comparison)} has a null reference");
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(_books, null))
            {
                logger.Error($"{nameof(_books)} has a null reference");
                throw new ArgumentNullException();
            }
            logger.Info("The collection of Books sorted");
            _books.Sort(comparison);
        }
    }
}
