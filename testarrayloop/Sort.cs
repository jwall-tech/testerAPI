using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestA
{
    internal class Sort
    {
        public static int[] SortSeq(int[] seq)
        {
            int temp;
            int[] arr = seq;
            for (int j = 0; j <= seq.Length - 2; j++)
            {
                for (int i = 0; i <= seq.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr;
        }
    }
}
