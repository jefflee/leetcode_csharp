using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersWithSameConsecutiveDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] r = NumsSameConsecDiff(3, 7);

            Console.WriteLine(String.Join(",", r));
        }

        public static int[] NumsSameConsecDiff(int N, int K)
        {
            HashSet<int> set1 = new HashSet<int>();
            for (int i = 1; i < 10; i++)
            {
                set1.Add(i);
            }

            for (int i = 1; i < N; i++)
            {
                HashSet<int> set2 = new HashSet<int>();
                foreach (int item in set1)
                {
                    int d = item % 10;

                    if (d - K >= 0)
                    {
                        set2.Add(item * 10 + d - K);
                    }

                    if (d + K <= 9)
                    {
                        set2.Add(item * 10 + d + K);
                    }
                }

                set1 = set2;

            }

            if (N == 1)
            {
                set1.Add(0);
            }

            int[] ans = new int[set1.Count];
            int k = 0;
            foreach (int item in set1)
            {
                ans[k] = item;
                k++;
            }

            return ans;
        }
    }
}
