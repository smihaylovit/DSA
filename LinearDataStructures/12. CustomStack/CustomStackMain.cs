using System;
using System.Collections.Generic;

namespace CustomStackNS
{
    public class CustomStack
    {
        static void Main()
        {
            CustomStack<int> customStack = new CustomStack<int>();

            CustomStack<int> anotherStack = new CustomStack<int>(20);

            Console.WriteLine(customStack.Capacity);
            Console.WriteLine(anotherStack.Capacity);
            Console.WriteLine();

            Console.WriteLine(customStack.Count);
            Console.WriteLine(anotherStack.Count);
            Console.WriteLine();

            customStack.Push(15);
            customStack.Push(20);
            customStack.Push(3);

            Console.WriteLine(customStack);
            Console.WriteLine(customStack.Count);
            Console.WriteLine(customStack.Capacity);
            Console.WriteLine(customStack.Peek());
            Console.WriteLine();

            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack);
            Console.WriteLine();

            customStack.Push(35);
            customStack.Push(40);
            customStack.Push(50);
            Console.WriteLine(customStack);
            Console.WriteLine(customStack.Count);
            Console.WriteLine(customStack.Capacity);
            Console.WriteLine();

            //Check result with debugger
            customStack.TrimExcess();
            customStack.Clear();
        }
    }
}
