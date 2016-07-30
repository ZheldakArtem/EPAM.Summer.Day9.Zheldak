using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NLog;
using Task_Book;

namespace Task4
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private readonly string _filePath;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public BinaryBookListStorage(string filePath = @"..\")
        {
            _filePath = filePath;
        }
        /// <summary>
        /// Method load books in List
        /// </summary>
        /// <returns>Collection of books</returns>
        public List<Book> LoadBooks()
        {
            var listBooks = new List<Book>();
            try
            {
                logger.Info("Loading books");
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
                logger.Error("File not found");
                throw;
            }
            catch (FileLoadException e)
            {
                logger.Error(e, "The File can't loaded");
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e, "I/O error occurs");
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Parameter has a null reference");
                throw;
            }
            logger.Info("Loaded books");
            return listBooks;
        }
        /// <summary>
        /// Save the collection of books in the file
        /// </summary>
        /// <param name="books">The book collection</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                logger.Info("Saving books");
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
                logger.Error(e, "The File can't loaded");
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e, "I/O error occurs");
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Parameter has a null reference");
                throw;
            }
            logger.Info("Books saved");
        }

        /// <summary>
        /// Deserialize book from xml file
        /// </summary>
        /// <returns>Collection of books</returns>
        public List<Book> XMLDeserialize()
        {
            var ds = new DataContractSerializer(typeof(List<Book>));
            List<Book> h;
            using (Stream s = File.OpenRead(_filePath + "person.xml"))
                h = (List<Book>)ds.ReadObject(s);

            return h;
        }

        /// <summary>
        ///  Xml Searilization of book
        /// </summary>
        /// <param name="books">The collection of books</param>
        public void XMLSerialize(IEnumerable<Book> books)
        {
            var ds = new DataContractSerializer(typeof(IEnumerable<Book>));
            using (Stream s = File.Create(_filePath + "person.xml"))
                ds.WriteObject(s, books);
        }

        /// <summary>
        /// Deserialize book from binary file
        /// </summary>
        /// <returns>Collection of books</returns>
        public List<Book> BinariDeserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = File.OpenRead(_filePath + "book.bin"))
                return (List<Book>)formatter.Deserialize(s);
        }

        /// <summary>
        ///  Binary Searilization of book
        /// </summary>
        /// <param name="books">The collection of book</param>
        public void BinarySerialize(IEnumerable<Book> books)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = File.Create(_filePath + "book.bin"))
                formatter.Serialize(s, books);
        }
    }
}
