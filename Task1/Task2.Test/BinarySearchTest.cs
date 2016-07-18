using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task2.BinarySearch;

namespace Task2.Test
{
    [TestFixture]
    public class BinarySearchTest
    {
        [TestCaseSource(typeof(DataSource),nameof(DataSource.GetDataWithIntValue))]
        public int GetIndexSearchItemWithIntegerArray(int[] array,int search)
        {
            var comparer=new TestComparer<int>();

            return Search(array, search, comparer.SomeCompare);
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.GetDataWithDoubleValue))]
        public int GetIndexSearchItemWithDoubleArray(double[] array, double search)
        {
            var comparer = new TestComparer<double>();
            List<int> d=new List<int>();
            Comparison<>
            return Search(array, search, comparer.SomeCompare);
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.GetDataWithIncorrectValue))]
        public int GetIndexSearchItemWithincorrectArray(double[] array, double search)
        {
            var comparer = new TestComparer<double>();

            return Search(array, search, comparer.SomeCompare);
        }
    }

    public static class DataSource
    {
        public static IEnumerable GetDataWithIntValue
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3).Returns(2);
                yield return new TestCaseData(new int[] { -1, -2, -3, 4, 5, 6, 7 }, 4).Returns(3);
                yield return new TestCaseData(new int[] { -4, -3, -2, -1, 0, 5, 6, 7 }, 0).Returns(4);
            }
        }

        public static IEnumerable GetDataWithDoubleValue
        {
            get
            {
                yield return new TestCaseData(new double[] { 1.3, 2.4, 3.7, 4.4, 5.2, 6.3, 7.2 }, 5.2).Returns(4);
                yield return new TestCaseData(new double[] { -1.0, -2.2, -3.7, 4.1, 5.2, 6.8, 7.9 }, 4.1).Returns(3);
                yield return new TestCaseData(new double[] { -4.1, -3.4, -2.2, -1.9, 0, 5.1, 6.8, 7.3 }, -3.4).Returns(1);
            }
        }
        public static IEnumerable GetDataWithIncorrectValue
        {
            get
            {
                yield return new TestCaseData(new double[] { 1.3, 2.4, 3.7, 4.4, -5.2, 6.3, 7.2 }, 5.2).Returns(-1);
                yield return new TestCaseData(new double[] { -1.0, -2.2, -3.7, 4.1, 5, 6.8, 7.9 }, -1).Returns(-1);
                yield return new TestCaseData(new double[] { -4.1, -3.4, -2.2, -1.9, 0, 5.1, 6.8, 7.3 }, 10).Returns(-1);
            }
        }
    }

}
