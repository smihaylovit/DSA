using System;
using System.Collections.Generic;
using System.Linq;

public class ShortestSequence
{
    static void Main()
    {
        const int functionsNumber = 3;

        Console.Write("Enter number N: ");
        string line = Console.ReadLine();
        int N;
        while (!int.TryParse(line, out N))
        {
            Console.Write("Please enter an integer: ");
            line = Console.ReadLine();
        }
        Console.WriteLine();

        Console.Write("Enter number M: ");
        line = Console.ReadLine();
        int M;
        while (!int.TryParse(line, out M))
        {
            Console.Write("Please enter an integer: ");
            line = Console.ReadLine();
        }
        Console.WriteLine();

        Queue<List<int>> sequence = new Queue<List<int>>();

        sequence.Enqueue(new List<int> { N });

        int listCounter = 1;
        List<int> currentList = sequence.ElementAt(0);

        while (!currentList.Contains(M))
        {
            List<int> newList = new List<int>();

            foreach (int element in currentList)
            {
                newList.Add(element + 1);
                newList.Add(element + 2);
                newList.Add(element * 2);
            }

            sequence.Dequeue();
            sequence.Enqueue(newList);
            listCounter++;
            currentList = sequence.ElementAt(0);
        }

        Console.WriteLine("The shortest sequences of operations are: ");

        for (int i = 0; i < currentList.Count; i++)
        {
            if (currentList[i] == M)
            {
                int currentIndex = i;
                List<int> result = new List<int>();

                result.Add(M);

                for (int idx = 1; idx < listCounter - 1; idx++)
                {
                    if (currentIndex % 3 == 2)
                    {
                        result.Add(result[idx - 1] / 2);
                    }
                    else if (currentIndex % 3 == 1)
                    {
                        result.Add(result[idx - 1] - 2);
                    }
                    else
                    {
                        result.Add(result[idx - 1] - 1);
                    }

                    currentIndex /= functionsNumber;
                }

                result.Add(N);
                result.Reverse();

                Console.WriteLine(String.Join("->", result));
            }
        }

        Console.WriteLine();
    }
}