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
        // todo: not completed.

        static void Main(string[] args)
        {
            int[] A = new int[] {6, 0, 8, 2, 1, 5};
            Console.WriteLine(MaxWidthRamp(A)); // 4

            A = new int[] {9, 8, 1, 0, 1, 9, 4, 0, 4, 1};
            Console.WriteLine(MaxWidthRamp(A)); // 7

            A = new int[] {1, 2, 1};
            Console.WriteLine(MaxWidthRamp(A)); // 2

            A = new int[] {1, 0};
            Console.WriteLine(MaxWidthRamp(A)); // 0

            A = new int[] {2, 1, 3};
            Console.WriteLine(MaxWidthRamp(A)); // 2

            A = new int[] {0, 1};
            Console.WriteLine(MaxWidthRamp(A)); // 1

            A = new int[] {2, 2, 1};
            Console.WriteLine(MaxWidthRamp(A)); // 1
        }

        public static int MaxWidthRamp(int[] A)
        {
            int n = A.Length;
            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = i;
            }

            Array.Sort(b, (i, j) => ((int) A[i]).CompareTo(A[j]));

            int ans = 0;
            int m = n;
            foreach (int i in b)
            {
                ans = Math.Max(ans, i - m);
                m = Math.Min(m, i);
            }

            return ans;
        }

        public static int MaxWidthRamp_Mine(int[] A)
        {
            if (A == null || A.Length < 1)
            {
                return 0;
            }

            int slidingWindowLength = A.Length - 1;
            int maxWidthRamp = 0;

            while (maxWidthRamp == 0 && slidingWindowLength > 0)
            {

                for (int k = 0; k + slidingWindowLength < A.Length; k++)
                {
                    if (A[k] <= A[k + slidingWindowLength])
                    {
                        maxWidthRamp = slidingWindowLength;
                        break;
                    }
                }

                slidingWindowLength--;
            }

            return maxWidthRamp;
        }
    }
}
