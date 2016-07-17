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
        [TestCase(@"E:\TestFile1.txt", ExpectedResult = 2)]
        public Dictionary<string,int> GetFrequencyTest(string pathFile)
        {


            return null;
        }
    }
}
