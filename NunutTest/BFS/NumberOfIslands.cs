using System.Collections;

namespace LeetCodeNUnitTest.BFS;

/// <summary>
///     https://leetcode.com/problems/number-of-islands/description/
///     200. Number of Islands
///     Solution
///     https://leetcode.com/problems/number-of-islands/solutions/3890934/simple-c-solution/
///     https://www.youtube.com/watch?v=VSuR2ti-_Xg
/// </summary>
internal class NumberOfIslandsSolution
{
    private int nc;
    private int nr;


    public int NumIslands(char[][] grid)
    {
        nr = grid.Length;
        nc = grid[0].Length;

        var totalIsland = 0;

        for (var i = 0; i < nr; i++)
        {
            for (var j = 0; j < nc; j++)
            {
                if (grid[i][j] == '1')
                {
                    totalIsland++;
                    FindIsland(grid, i, j);
                }
            }
        }

        return totalIsland;
    }

    private void FindIsland(char[][] grid, int i, int j)
    {
        if (isValidCell(grid, i, j))
        {
            grid[i][j] = '0'; // Mark as visited <- This is the key
            FindIsland(grid, i + 1, j); // Visit cell below
            FindIsland(grid, i - 1, j); // Visit cell above
            FindIsland(grid, i, j + 1); // Visit cell on the right
            FindIsland(grid, i, j - 1); // Visit cell on the left
        }
    }

    private bool isValidCell(char[][] grid, int i, int j)
    {
        return i >= 0 && i < nr && j >= 0 && j < nc && grid[i][j] == '1';
    }
}

internal class NumberOfIslandsTest
{
    [TestCaseSource(typeof(TestCases))]
    public void NumberOfIslandsSolutionTest(char[][] grid, int expected)
    {
        var sut = new NumberOfIslandsSolution();
        var output = sut.NumIslands(grid);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                new[]
                {
                    new[] { '1', '1', '1', '1', '0' },
                    new[] { '1', '1', '0', '1', '0' },
                    new[] { '1', '1', '0', '0', '0' },
                    new[] { '0', '0', '0', '0', '0' }
                },
                1
            };
            yield return new object?[]
            {
                new[]
                {
                    new[] { '1', '1', '0', '0', '0' },
                    new[] { '1', '1', '0', '0', '0' },
                    new[] { '0', '0', '1', '0', '0' },
                    new[] { '0', '0', '0', '1', '1' }
                },
                3
            };
        }
    }
}