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

        private static int BinSearch<T>(T[] array, int left, int right, T seekingElement) where T : IComparable<T>
        {
            if (array == null)
                throw new ArgumentException("Array is null");

            if (array.Length == 0)
                return -1;

            if (seekingElement == null)
                throw new ArgumentException("Element is null");

            int middle = (left + right) / 2;

            if (array[middle].CompareTo(seekingElement) == 0)
            {
                return middle;
            }

            if (left == right)
            {
                return -1;
            }

            if (array[middle].CompareTo(seekingElement) == -1)
            {
                return BinSearch(array, middle + 1, right, seekingElement);
            }

            return BinSearch(array, left, middle - 1, seekingElement);
        }

        public static int Search<T>(T[] array, T seekingElement) where T : IComparable<T>
        {
            if (array.Length != 0)
            {
                return BinSearch(array, 0, array.Length - 1, seekingElement);
            }
            return -1;
        }
    }
}
