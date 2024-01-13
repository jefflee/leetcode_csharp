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

/// <summary>
///     https://leetcode.com/problems/reverse-bits/solutions/3813349/simple-c/
/// </summary>
internal class ReverseBitsShiftOperatorSolution
{
    public uint ReverseBits(uint n)
    {
        uint result = 0;

        for (var i = 0; i < 32; i++)
        {
            result <<= 1;
            result |= n & 1;
            n >>= 1;
        }

        return result;
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

    [TestCaseSource(typeof(TestCases))]
    public void ReverseBitsShiftOperatorSolutionTest(string n, uint expected)
    {
        var sut = new ReverseBitsShiftOperatorSolution();
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