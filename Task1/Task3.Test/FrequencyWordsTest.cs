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
        [TestCase("wf", ExpectedResult = 1)]
        public Dictionary<string, int> GetFrequencyTest(string sf)
        {
            // var diPath = AppDomain.CurrentDomain.BaseDirectory;
            string s = sf;
            var result = GetFrequency(@"E:\TestFile1.txt");

            return result;
        }
    }
}
