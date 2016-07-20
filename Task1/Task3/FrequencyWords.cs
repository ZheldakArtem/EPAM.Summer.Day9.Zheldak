using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class FrequencyWords
    {
        private const int BUFFERSIZE = 64;
        /// <summary>
        /// The Method finds frequency of words in the text
        /// </summary>
        /// <param name="pathFile">The file path</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetFrequency(string pathFile)
        {
            char[] buffer = new char[BUFFERSIZE];
            var result = new Dictionary<string, int>();
            string temp = string.Empty;

            using (var fileStream = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    int sizeRead;

                    while ((sizeRead = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        BufferProcessing(buffer, ref result, sizeRead, temp);
                    }
                }
            }
            return result;
        }

        private static void BufferProcessing(char[] buffer, ref Dictionary<string, int> result, int sizeRead, string temp)
        {
            temp = temp.Replace('\0', ' ');

            if (buffer[sizeRead - 1] == ' ')
            {
                buffer[sizeRead - 1] = '\0';
            }

            var strLine = new string(buffer);
            temp += strLine;
            temp = DeletePunctuation(new[] { '.', ',', ':', '?', '!' }, temp);

            var arrayWords = temp.Split(' ');

            for (int i = 0; i < arrayWords.Length - 1; i++)
            {
                if (!result.ContainsKey(arrayWords[i]))
                {
                    result.Add(arrayWords[i], 1);
                }
                else
                {
                    result[arrayWords[i]]++;
                }
            }
            temp = arrayWords[arrayWords.Length - 1];
            if (sizeRead != buffer.Length)
            {
                if (!result.ContainsKey(arrayWords[arrayWords.Length - 1]))
                {
                    result.Add(arrayWords[arrayWords.Length - 1], 1);
                }
                else
                {
                    result[arrayWords[arrayWords.Length - 1]]++;
                }
            }
            BufClear(buffer);
        }

        private static void BufClear(char[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = '\0';
            }
        }

        private static string DeletePunctuation(char[] arraySymbol, string text)
        {

            for (int i = 0; i < arraySymbol.Length - 1; i++)
            {
                text = text.Replace(arraySymbol[i].ToString(), "");
            }
            return text.Trim();
        }
    }
}
