using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new Int32[] { 2, 7, 11, 15 };
            int target = 9;

            TwoSum_solutions1(nums, target);

            //TwoSum_solution3(nums, target);
            
        }

        public static int[] TwoSum_solution3(int[] nums, int target)
        {

            Dictionary<int, int> dic = new Dictionary<int, int>(1000);

            for (int k = 0; k < nums.Length; k++)
            {
                int complement = target - nums[k];
                if (dic.ContainsKey(complement) == true)
                {
                    return new int[] { dic[complement], k };
                }
                dic[nums[k]] = k;
            }

            return new int[2];
        }

        public static int[] TwoSum_solutions1(int[] nums, int target)
        {

            int[] resultAry = new int[2];

            for (int j = 0; j < nums.Length; j++)
            {

                for (int k = 0; k < nums.Length; k++)
                {
                    if (j == k)
                    {
                        continue;
                    }
                    if ((nums[j] + nums[k]) == target)
                    {
                        resultAry[0] = j;
                        resultAry[1] = k;
                        return resultAry;
                    }
                }
            }

            return resultAry;
        }
    }
}
