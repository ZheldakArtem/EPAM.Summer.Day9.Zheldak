using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{/// <summary>
 /// The class contein a method to binary search
 /// </summary>

    public static class BinarySearch
    {

        private static int BinSearch<T>(T[] array, int left, int right, T seekingElement, Comparison<T> comparisonFunc)
        {
            if (array == null)
                throw new ArgumentException("Array is null");

            if (array.Length == 0)
                return -1;

            if (seekingElement == null)
                throw new ArgumentException("Element is null");

            int middle = (left + right) / 2;

            if (comparisonFunc(array[middle], seekingElement) == 0)
            {
                return middle;
            }

            if (left == right)
            {
                return -1;
            }

            if (comparisonFunc(array[middle], seekingElement) == -1)
            {
                return BinSearch(array, middle + 1, right, seekingElement, comparisonFunc);
            }


            return BinSearch(array, left, middle - 1, seekingElement, comparisonFunc);
        }
        /// <summary>
        ///  Searches a range of elements in the sorted array
        /// </summary>
        /// <param name="array">The collection whose elements should be find</param>
        /// <param name="seekingElement">The element</param>
        /// <param name="comparisonFunc">The delegate wich represents the method that compares two objects of the same type.</param>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <returns></returns>
        public static int Search<T>(T[] array, T seekingElement, Comparison<T> comparisonFunc)
        {
            if (array.Length != 0)
            {
                return BinSearch(array, 0, array.Length - 1, seekingElement, comparisonFunc);
            }
            return -1;
        }
    }
}
