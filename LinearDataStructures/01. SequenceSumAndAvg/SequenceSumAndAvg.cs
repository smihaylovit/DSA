using System;
using System.Collections.Generic;

class SequenceSumAndAvg
{
    static void Main()
    {
        Console.WriteLine("Please enter in a single line a sequence of positive integers separated by an interval: ");
        string line = Console.ReadLine();
        string[] elements = line.Split(' ');
        
        List<int> list = new List<int>();
        foreach (string el in elements)
        {
            list.Add(int.Parse(el));
        }

        int sum = 0;
        foreach (int el in list)
        {
            sum += el;
        }

        double avg = sum / list.Count;

        Console.WriteLine("The sum of the sequence elements is: {0}", sum);
        Console.WriteLine("The average of the sequence elements is: {0}", avg);
    }
}