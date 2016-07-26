using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Book;

namespace Task4
{
    public interface IBookListStorage
    {
        List<Book> LoadBooks();
        void SaveBooks(IEnumerable<Book> books);
        List<Book> XMLDeserialize();
        void XMLSerialize(IEnumerable<Book> books);
        List<Book> BinariDeserialize();
        void BinarySerialize(IEnumerable<Book> books);

    }
}
