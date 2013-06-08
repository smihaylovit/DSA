using System;
using System.Collections.Generic;

class ReverseIntegers
{
    static void Main()
    {
        Console.WriteLine("Please enter number of integers N: ");
        int N  = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter integer elements of the stack: ");
        Stack<int> elements = new Stack<int>();
        for (int i = 0; i < N; i++)
        {
            Console.Write("Element {0}: ", i + 1);
            int element = int.Parse(Console.ReadLine());
            elements.Push(element);
        }
        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(elements.Pop());
        }
    }
}