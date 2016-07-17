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

        public static Dictionary<string, int> GetFrequency(string pathFile)
        {
            char[] buffer = new char[16];
            var result = new Dictionary<string, int>();
           
            using (var fileStream = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                   
                    while (( streamReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var arrayWords = DeletePunctuation(new[]{'.',',',':','?','!'}, new string(buffer)).Split(' ');
                        for (int i = 0; i < arrayWords.Length; i++)
                        {
                            if (!result.ContainsKey(arrayWords[i]))
                            {
                                result.Add(arrayWords[i],1);
                            }
                            else
                            {
                                result[arrayWords[i]]++;
                            }
                        }
                        
                    }
                }
            }
            return result;
        }

        private static string DeletePunctuation(char[] arraySymbol,string text)
        {
            
            for (int i = 0; i < arraySymbol.Length; i++)
            {
              text=text.Replace(arraySymbol[i].ToString(),"");
            }
            return text.Trim();
        }
    }
}
