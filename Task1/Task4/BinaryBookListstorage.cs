using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Book;

namespace Task4
{
    public class BinaryBookListstorage : IBookListStorage
    {
        private readonly string _fileName;

        public BinaryBookListstorage(string fileName)
        {
            _fileName = fileName;
        }

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
