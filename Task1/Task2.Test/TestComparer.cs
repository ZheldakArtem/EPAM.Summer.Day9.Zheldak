using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Test
{
    public class TestComparer<T> where T : IComparable<T>
    {
        public int SomeCompare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}
