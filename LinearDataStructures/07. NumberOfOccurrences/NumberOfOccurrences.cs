using System;
using System.Collections.Generic;
using System.Linq;

public class NumberOfOccurrences
{
    static void Main()
    {
        Console.Write("Enter number of elements to read: ");
        string line = Console.ReadLine();
        int N;
        while (!(int.TryParse(line, out N) && N > 0))
        {
            Console.Write("Please enter a positive integer: ");
            line = Console.ReadLine();
        }
        Console.WriteLine();

        int[] numbers = new int[N];
        for (int idx = 0; idx < N; idx++)
        {
            Console.Write("Enter number {0}: ", idx + 1);
            line = Console.ReadLine();
            while (!(int.TryParse(line, out numbers[idx]) && (numbers[idx] >= 0) && (numbers[idx] <= 1000)))
            {
                Console.Write("Please enter a positive integer between 0 and 1000: ");
                line = Console.ReadLine();
            }
            Console.WriteLine();
        }

        SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();

        for (int i = 0; i < N; i++)
        {
            if (!occurrences.Keys.Contains(numbers[i]))
            {
                occurrences.Add(numbers[i], 1);
            }
            else
            {
                occurrences[numbers[i]]++;
            }
        }

        foreach (KeyValuePair<int, int> pair in occurrences)
        {
            Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
        Console.WriteLine();
    }
}