using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Book;

namespace Task4
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private readonly string _filePath;

        public BinaryBookListStorage(string filePath)
        {
            _filePath = filePath;
        }
        /// <summary>
        /// Method load books in List
        /// </summary>
        /// <returns>Collection of books</returns>
        public List<Book> LoadBooks()
        {
            var listBooks=new List<Book>();
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(_filePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        Book book = new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(),
                            reader.ReadInt32(), reader.ReadInt32());

                        listBooks.Add(book);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (FileLoadException e)
            {
                throw;
            }
            catch (IOException e)
            {
                throw;
            }
            catch (ArgumentNullException e)
            {
                throw;
            }
    
            return listBooks;
        }
        /// <summary>
        /// Save the collection of books in the file
        /// </summary>
        /// <param name="books"></param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(_filePath, FileMode.OpenOrCreate)))
                {
                    foreach (Book book in books)
                    {
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Genre);
                        writer.Write(book.Publication);
                        writer.Write(book.Pages);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (IOException e)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
