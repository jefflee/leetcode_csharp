using System.Collections;

namespace LeetCodeNUnitTest.Backtracking;

/// <summary>
///     https://leetcode.com/problems/word-ladder/description/
///     127. Word Ladder
///     Solution
///     https://leetcode.com/problems/word-ladder/solutions/3206330/c-bfs/
/// </summary>
internal class WordLadderSolution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (wordList.IndexOf(endWord) == -1) return 0;
        var set = CreateInitalList(beginWord, wordList);
        var rs = 2;
        if (set.Contains(endWord))
        {
            return rs;
        }

        var dic = CreateDictionaryForLadder(wordList);
        var visited = new HashSet<string>();
        while (set.Count > 0)
        {
            rs++;
            visited.UnionWith(set);
            var set2 = new HashSet<string>();
            foreach (var item in set)
            {
                for (var j = 0; j < dic[item].Count; j++)
                {
                    if (!visited.Contains(dic[item][j]))
                    {
                        if (dic[item][j] == endWord) return rs;
                        set2.Add(dic[item][j]);
                    }
                }
            }

            set = set2;
        }

        return 0;
    }

    private Dictionary<string, List<string>> CreateDictionaryForLadder(IList<string> wordList)
    {
        var rs = new Dictionary<string, List<string>>();
        for (var i = 0; i < wordList.Count; i++)
        {
            var list = new List<string>();
            foreach (var item in rs)
            {
                if (isOneCharDifferent(wordList[i], item.Key))
                {
                    item.Value.Add(wordList[i]);
                    list.Add(item.Key);
                }
            }

            rs.Add(wordList[i], list);
        }

        return rs;
    }

    private HashSet<string> CreateInitalList(string s, IList<string> wordList)
    {
        var rs = new HashSet<string>();
        for (var i = 0; i < wordList.Count; i++)
        {
            if (isOneCharDifferent(s, wordList[i]))
            {
                rs.Add(wordList[i]);
            }
        }

        return rs;
    }

    private bool isOneCharDifferent(string str1, string str2)
    {
        var diffCount = 0;
        for (var i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                diffCount++;
            }

            if (diffCount > 1)
            {
                return false;
            }
        }

        return diffCount == 1;
    }
}

internal class WordLadderTest
{
    [TestCaseSource(typeof(TestCases))]
    public void WordLadderSolutionTest(string beginWord, string endWord, IList<string> wordList, int expected)
    {
        var sut = new WordLadderSolution();
        var output = sut.LadderLength(beginWord, endWord, wordList);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
                { "hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" }, 5 };
            yield return new object?[]
                { "hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log" }, 0 };
            yield return new object?[]
                { "hot", "dog", new List<string> { "hot", "dog" }, 0 };
            yield return new object?[]
                { "hot", "dog", new List<string> { "hot", "dog", "dot" }, 3 };
        }
    }
}