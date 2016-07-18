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
        /// <summary>
        /// The Method finds frequency of words in the text
        /// </summary>
        /// <param name="pathFile">The file path</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetFrequency(string pathFile)
        {
            char[] buffer = new char[100000];
            var result = new Dictionary<string, int>();
            string temp = string.Empty;

            using (var fileStream = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    int sizeRead;
                    while ((sizeRead = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var strLine = new string(buffer);
                        temp += (strLine[0] != ' ' ? " " : "") + strLine;
                        temp = DeletePunctuation(new[] { '.', ',', ':', '?', '!' }, temp);
                        var arrayWords = temp.Split(' ');

                        for (int i = 0; i < arrayWords.Length ; i++)
                        {
                            if (!result.ContainsKey(arrayWords[i]))
                            {
                                result.Add(arrayWords[i], 1);
                            }
                            else
                            {
                                result[arrayWords[i]]++;
                            }
                            
                            temp = arrayWords[arrayWords.Length - 1];
                        }
                        
                        if (!result.ContainsKey(arrayWords[arrayWords.Length - 1]))
                        {
                            result.Add(arrayWords[arrayWords.Length - 1], 1);
                        }
                        else
                        {
                            result[arrayWords[arrayWords.Length - 1]]++;
                        }

                    }
                }
            }
            return result;
        }

        private static string DeletePunctuation(char[] arraySymbol, string text)
        {

            for (int i = 0; i < arraySymbol.Length; i++)
            {
                text = text.Replace(arraySymbol[i].ToString(), "");
            }
            return text.Trim();
        }
    }
}
