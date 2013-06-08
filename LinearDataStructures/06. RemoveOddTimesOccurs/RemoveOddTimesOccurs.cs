using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

class RemoveOddTimesOccurs
{
    static void Main()
    {
        Console.WriteLine("Please enter in a single line a sequence of integers separated by an interval: ");
        string line = Console.ReadLine();
        string[] elements = line.Split(' ');

        List<int> seq = new List<int>();
        foreach (string el in elements)
        {
            seq.Add(int.Parse(el));
        }

        Set<int> set = new Set<int>();
        set.AddMany(seq);

        set.RemoveAll(setElement => (seq.FindAll(seqElement => seqElement == setElement).Count % 2 == 1));

        seq.RemoveAll(seqElement => !set.Contains(seqElement));

        Console.WriteLine("The new sequence with removed elements that occur odd number of times is: ");
        Console.WriteLine(String.Join(" ", seq));
    }
}