using System;
using System.Collections;
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
        [TestCaseSource(typeof(DataSource), nameof(DataSource.GetDataPath))]
        public void GetFrequencyTest(string filePuth,Dictionary<string,int> result)
        {
            Dictionary<string,int> dic= GetFrequency(filePuth);
            
           CollectionAssert.AreEqual(dic,result);
        }
    }

    public static class DataSource
    {
        public static IEnumerable GetDataPath
        {
            get
            {
                yield return new TestCaseData(@"E:\TestFile1.txt",new Dictionary<string, int>()
                {
                    {"I", 1},
                    {"am", 1},
                    {"say", 1},
                    {"a", 1 },
                    { "student", 1 },
                    { "that", 1 },
                 
                });


            }
        }
    }
}