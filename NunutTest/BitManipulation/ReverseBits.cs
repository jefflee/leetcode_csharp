using System.Collections;

namespace LeetCodeNUnitTest.BitManipulation;

/// <summary>
///     https://leetcode.com/problems/reverse-bits/description/
///     190. Reverse Bits
/// </summary>
internal class ReverseBitsSolution
{
    public uint ReverseBits(uint n)
    {
        var bitString = Convert.ToString(n, 2).PadLeft(32, '0').ToCharArray();

        for (int i = 0, j = 31; i < 16; i++, j--)
        {
            (bitString[i], bitString[j]) = (bitString[j], bitString[i]);
        }

        return Convert.ToUInt32(new string(bitString), 2);
    }
}

internal class ReverseBitsTest
{
    [TestCaseSource(typeof(TestCases))]
    public void ReverseBitsSolutionTest(string n, uint expected)
    {
        var sut = new ReverseBitsSolution();
        var output = sut.ReverseBits(Convert.ToUInt32(n, 2));
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { "00000010100101000001111010011100", (uint)964176192 };
            yield return new object?[] { "11111111111111111111111111111101", 3221225471 };
        }
    }
}