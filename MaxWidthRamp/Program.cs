using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxWidthRamp
{
    class Program
    {
        // https://leetcode.com/problems/maximum-width-ramp/

        static void Main(string[] args)
        {
            int[] A = new int[] { 6, 0, 8, 2, 1, 5 };
            Console.WriteLine(MaxWidthRamp(A)); // 4

            A = new int[] { 9, 8, 1, 0, 1, 9, 4, 0, 4, 1 };
            Console.WriteLine(MaxWidthRamp(A)); // 7

            A = new int[] { 1, 2, 1 };
            Console.WriteLine(MaxWidthRamp(A)); // 2

            A = new int[] { 1, 0 };
            Console.WriteLine(MaxWidthRamp(A)); // 0

            A = new int[] { 2, 1, 3 };
            Console.WriteLine(MaxWidthRamp(A)); // 2

        }

        public static int MaxWidthRamp(int[] A)
        {
            if (A == null || A.Length < 1)
            {
                return 0;
            }

            int j = 0;
            int maxWidthRamp = 0;

            SortedList<int, int> sl = new SortedList<int, int>();
            for (int i = 0; i < A.Length; i++)
            {


                if (!sl.ContainsKey(A[i]))
                {
                    sl.Add(A[i], i);
                }
            }

            while (j < A.Length)
            {

                for (int k = 0; k < sl.Count && sl.Keys[k] <= A[j]; k++)
                {
                    if (j - sl.Values[k] > maxWidthRamp)
                    {
                        maxWidthRamp = j - sl.Values[k];
                    }
                }
                j++;
            }

            return maxWidthRamp;
        }
    }
}
