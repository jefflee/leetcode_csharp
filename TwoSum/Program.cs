using System.Collections.Generic;

namespace TwoSum
{
    /// <summary>
    ///     https://leetcode.com/problems/two-sum/description/
    ///     1. Two Sum
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            var target = 9;

            TwoSum_solutions1(nums, target);

            //TwoSum_solution3(nums, target);
        }

        public static int[] TwoSum_solution3(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>(1000);

            for (var k = 0; k < nums.Length; k++)
            {
                var complement = target - nums[k];
                if (dic.ContainsKey(complement))
                {
                    return new[] { dic[complement], k };
                }

                dic[nums[k]] = k;
            }

            return new int[2];
        }

        public static int[] TwoSum_solutions1(int[] nums, int target)
        {
            var resultAry = new int[2];

            for (var j = 0; j < nums.Length; j++)
            {
                for (var k = 0; k < nums.Length; k++)
                {
                    if (j == k)
                    {
                        continue;
                    }

                    if (nums[j] + nums[k] == target)
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