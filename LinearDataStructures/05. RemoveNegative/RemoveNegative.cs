using System;
using System.Collections.Generic;

public class RemoveNegative
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

        seq.RemoveAll(element => element < 0);
        
        Console.WriteLine("The new sequence with removed negative numbers is: ");
        Console.WriteLine(String.Join(" ", seq));
    }
}