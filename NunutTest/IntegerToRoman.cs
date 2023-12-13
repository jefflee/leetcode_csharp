using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeNUnitTest
{
    /// <summary>
    ///     https://leetcode.com/problems/integer-to-roman/
    /// </summary>
    public class IntegertoRoman
    {
        public string IntToRoman(int num)
        {
            var result = string.Empty;

            do
            {
                if (num >= 1000)
                {
                    num -= 1000;
                    result += "M";
                }
                else if (num >= 900)
                {
                    num -= 900;
                    result += "CM";
                }
                else if (num >= 500)
                {
                    num -= 500;
                    result += "D";
                }
                else if (num >= 400)
                {
                    num -= 400;
                    result += "CD";
                }
                else if (num >= 100)
                {
                    num -= 100;
                    result += "C";
                }
                else if (num >= 90)
                {
                    num -= 90;
                    result += "XC";
                }
                else if (num >= 50)
                {
                    num -= 50;
                    result += "L";
                }
                else if (num >= 40)
                {
                    num -= 40;
                    result += "XL";
                }
                else if (num >= 10)
                {
                    num -= 10;
                    result += "X";
                }
                else if (num >= 9)
                {
                    num -= 9;
                    result += "IX";
                }
                else if (num >= 5)
                {
                    num -= 5;
                    result += "V";
                }
                else if (num >= 4)
                {
                    num -= 4;
                    result += "IV";
                }
                else if (num >= 1)
                {
                    num -= 1;
                    result += "I";
                }
            } while (num > 0);

            return result;
        }
    }

    public class IntegerToRomanTests
    {
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        public void Test(int num, string roman)
        {
            var convert = new IntegertoRoman();
            var val = convert.IntToRoman(num);

            val.Should().Be(roman);
        }
    }
}