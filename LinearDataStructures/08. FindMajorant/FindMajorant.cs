using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FindMajorant
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
            while (!(int.TryParse(line, out numbers[idx])))
            {
                Console.Write("Please enter an integer: ");
                line = Console.ReadLine();
            }
            Console.WriteLine();
        }

        Console.Write("{" + String.Join(", ", numbers) + "} -> ");

        int majMinOccurs = N / 2 + 1;

        /*Solution 1 - Predicates*/

        List<int> numbersList = numbers.ToList<int>();
        Set<int> numbersSet = new Set<int>();

        numbersSet.AddMany(numbersList);

        try
        {
            int majorant = numbersSet.First(setElement => (numbersList.FindAll(
                listElement => listElement == setElement).Count >= majMinOccurs));
            Console.WriteLine(majorant);
        }
        catch
        {
            Console.WriteLine("No majorant!");
        }

        Console.WriteLine();

        /*Solution 2 - Dictionary*/

        //Dictionary<int, int> occurrences = new Dictionary<int, int>();

        //for (int i = 0; i < N; i++)
        //{
        //    if (!occurrences.Keys.Contains(numbers[i]))
        //    {
        //        occurrences.Add(numbers[i], 1);
        //    }
        //    else
        //    {
        //        occurrences[numbers[i]]++;
        //    }
        //}

        //bool hasMajorant = false;

        //foreach (KeyValuePair<int, int> pair in occurrences)
        //{
        //    if (pair.Value >= majMinOccurs)
        //    {
        //        Console.WriteLine(pair.Key);
        //        hasMajorant = true;
        //        break;
        //    }
        //}

        //if (!hasMajorant)
        //{
        //    Console.WriteLine("No majorant!");
        //}

        //Console.WriteLine();
    }
}