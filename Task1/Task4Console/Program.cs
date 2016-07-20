using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Task_Book;
using Task4;
using static System.Console;
namespace Task4Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IBookListStorage bookListStorage = new BinaryBookListStorage(@"E:\Books.bin");
            BookListService bookService = new BookListService(bookListStorage);
            List<Book> book = new List<Book>();
            bookService.AddBook(new Book("Artem", "Read life", "Dram", 1995, 20001));
            bookService.AddBook(new Book("Pasha", "Rooby", "Mult", 1225, 200));
            bookService.AddBook(new Book("Dima", "C++", "ut", 1955, 29001));
            bookService.AddBook(new Book("Olga", "Phyton", "Drh", 1933, 20001));
            bookService.AddBook(new Book("Petr", "The everest", "Ddh", 2015, 4001));
            bookService.AddBook(new Book("oleg", "The football", "Dramju", 342, 1241));
            Book findBook = bookService.FindBooksByTag((a) => a.Author == "Artem");
            bookService.SortBooksByTag((a, b) => a.Publication.CompareTo(b.Publication));


            ReadKey();

        }
    }
}
