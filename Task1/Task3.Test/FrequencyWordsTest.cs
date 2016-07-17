using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task3.FrequencyWords;

namespace Task3.Test
{
    [TestFixture]
    public class FrequencyWordsTest
    {
        [Test]
        public Dictionary<string,int> GetFrequencyTest(string pathFile)
        {
           // var diPath = AppDomain.CurrentDomain.BaseDirectory;
            
            var result = GetFrequency(@"E:\TestFile1.txt");
        
            return result;
        }
    }
}
