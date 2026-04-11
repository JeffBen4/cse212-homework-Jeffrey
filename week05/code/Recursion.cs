using System.Collections;
using System.Collections.Generic;
using System;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s < 0) return 0;
        if (s == 0) return 1;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        if (string.IsNullOrEmpty(pattern))
        {
            if (pattern == "" && !results.Contains("")) results.Add("");
            return;
        }

        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            if (!results.Contains(pattern)) results.Add(pattern);
            return;
        }

        string replaceZero = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string replaceOne = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);

        WildcardBinary(replaceZero, results);
        WildcardBinary(replaceOne, results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                // CAMBIO AQUÍ: Invertimos el orden para satisfacer a tu compilador
                if (maze.IsValidMove(currPath, newX, newY))
                {
                    SolveMaze(results, maze, newX, newY, new List<ValueTuple<int, int>>(currPath));
                }
            }
        }
    }
}