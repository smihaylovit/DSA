using System;
using System.Collections.Generic;

namespace LinkedQueueNS
{
    public class LinkedQueueMain
    {
        static void Main()
        {
            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();

            LinkedQueue<string> anotherLinkedQueue = new LinkedQueue<string>(
                new List<string> { "pesho", "gosho", "sasho", "misho" });

            Console.WriteLine(anotherLinkedQueue);
            Console.WriteLine("First: " + anotherLinkedQueue.First.Value);
            Console.WriteLine("Last: " + anotherLinkedQueue.Last.Value);
            Console.WriteLine();

            linkedQueue.Enqueue(15);
            linkedQueue.Enqueue(20);
            Console.WriteLine(linkedQueue);

            linkedQueue.Enqueue(50);
            linkedQueue.Enqueue(100);
            Console.WriteLine(linkedQueue);

            anotherLinkedQueue.Dequeue();
            Console.WriteLine(anotherLinkedQueue);

            linkedQueue.Dequeue();
            Console.WriteLine(linkedQueue);

            Console.WriteLine(linkedQueue.Peek());

            anotherLinkedQueue.Clear();
            Console.WriteLine(anotherLinkedQueue.Count == 0 && anotherLinkedQueue.First == null && anotherLinkedQueue.Last == null);
        }
    }
}
