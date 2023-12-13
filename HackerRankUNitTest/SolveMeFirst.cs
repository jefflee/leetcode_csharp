namespace HackerRankUNitTest;

/// <summary>
///     https://www.hackerrank.com/challenges/solve-me-first/problem?isFullScreen=true
/// </summary>
internal class SolveMeFirstSolution
{
    public static int SolveMeFirst(int a, int b)
    {
        // Hint: Type return a+b; below  
        return a + b;
    }
}

public class SolveMeFirstTests
{
    [TestCase(2, 3, 5)]
    [TestCase(100, 1000, 1100)]
    public void SolveMeFirst_GetSum_WhenGiveTwoValues(int a, int b, int expected)
    {
        var sum = SolveMeFirstSolution.SolveMeFirst(a, b);
        sum.Should().Be(expected);
    }
}