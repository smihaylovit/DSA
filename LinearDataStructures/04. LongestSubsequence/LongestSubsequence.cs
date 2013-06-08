using System;
using System.Collections.Generic;

namespace LongestEqualSubsequence
{
    public class LongestSubsequence
    {
        public static void Main()
        {
            Console.WriteLine("Please enter in a single line a sequence of integers separated by an interval: ");
            string line = Console.ReadLine();
            string[] elements = line.Split(' ');

            List<int> seq = new List<int>();
            foreach (string el in elements)
            {
                seq.Add(int.Parse(el));
            }

            Console.Write("Longest equal subsequence is: ");
            Console.WriteLine(String.Join(" ", GetLongestEqualSubseq(seq)));
        }

        public static List<int> GetLongestEqualSubseq(List<int> seq)
        {   
            if (seq.Count == 0 || seq.Count == 1)
            {
                return seq;
            }
            
            int currentSeqCount = 1;
            int currentSeqStartIndex = 0;
            int longestSeqCount = 1;
            int longestSeqStartIndex = 0;

            while (currentSeqStartIndex < seq.Count - 1)
            {
                while ((currentSeqStartIndex + currentSeqCount < seq.Count) &&
                    (seq[currentSeqStartIndex] == seq[currentSeqStartIndex + currentSeqCount]))
                {
                    currentSeqCount++;
                }

                if (currentSeqCount > longestSeqCount)
                {
                    longestSeqCount = currentSeqCount;
                    longestSeqStartIndex = currentSeqStartIndex;
                }

                currentSeqCount = 1;
                currentSeqStartIndex += currentSeqCount;
            }

            return seq.GetRange(longestSeqStartIndex, longestSeqCount);
        }
    }
}