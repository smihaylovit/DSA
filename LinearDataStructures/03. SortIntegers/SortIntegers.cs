using System;
using System.Collections.Generic;
using System.Linq;

class SortIntegers
{
    static void Main()
    {
        Console.WriteLine("Please enter in a single line a sequence of integers separated by an interval: ");
        string line = Console.ReadLine();
        string[] elements = line.Split(' ');

        List<int> list = new List<int>();
        foreach (string el in elements)
        {
            list.Add(int.Parse(el));
        }

        //using Sort()

        list.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int el in list)
        {
            Console.Write(el + " ");
        }

        //using Sort() with comparer

        //list.Sort((el1, el2) => el1.CompareTo(el2));
        //Console.WriteLine("The sorted list is:");
        //foreach (int el in list)
        //{
        //    Console.Write(el + " ");
        //}

        //using Orderby()

        //List<int> orderedList = list.OrderBy(element => element).ToList();
        //Console.WriteLine("The sorted list is:");
        //foreach (int el in orderedList)
        //{
        //    Console.Write(el + " ");
        //}

        Console.WriteLine();
    }
}