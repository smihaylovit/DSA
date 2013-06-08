using System;
using System.Collections.Generic;
using System.Linq;

public class SequenceMembers
{
    static void Main()
    {
        Console.Write("Enter first element of the sequence S1: ");
        string line = Console.ReadLine();
        int S1;
        while (!int.TryParse(line, out S1))
        {
            Console.Write("Please enter an integer: ");
            line = Console.ReadLine();
        }
        Console.WriteLine();

        Console.Write("Enter number of the first sequence elements to be printed: ");
        line = Console.ReadLine();
        int N;
        while (!(int.TryParse(line, out N) && (N > 0)))
        {
            Console.Write("Please enter a positive integer: ");
            line = Console.ReadLine();
        }
        Console.WriteLine();

        Queue<int> sequence = new Queue<int>(N);

        sequence.Enqueue(S1);

        int index = 0;
        int currentElement = sequence.ElementAt(index);
        int counter = 1;
        while (counter < N)
        {
            sequence.Enqueue(currentElement + 1);
            sequence.Enqueue(2 * currentElement + 1);
            sequence.Enqueue(currentElement + 2);
            index++;
            currentElement = sequence.ElementAt(index);
            counter += 3;
        }

        Console.WriteLine("First {0} members of the sequence are: ", N);
        Console.WriteLine(String.Join(" ", sequence.Take(N)));
        Console.WriteLine();
    }
}