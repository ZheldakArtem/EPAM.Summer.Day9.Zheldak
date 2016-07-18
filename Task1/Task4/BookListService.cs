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
        }

        public List<Book> LoadBooks()
        {
            return _bookListStorage.LoadBooks();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            _bookListStorage.SaveBooks(_books);
        }

        public bool AddBook(Book book)
        {
            _books.Add(book);
            return true;
        }

        public bool RemoveBook(Book book)
        {
            _books.Remove(book);
            return true;
        }

        public Book FindBookByTag()
        {
            return null;
        }

        public void SortBookByTag()
        {
            
        }
    }
}
