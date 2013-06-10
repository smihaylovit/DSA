using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedQueueNS
{
    public class LinkedQueue<T> : IEnumerable<T>, IEnumerable
    {
        private LinkedList<T> linkedList;

        public int Count
        {
            get
            {
                return this.linkedList.Count;
            }
        }

        public LinkedListNode<T> First
        {
            get
            {
                return this.linkedList.First;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return this.linkedList.Last;
            }
        }

        public LinkedQueue()
        {
            this.linkedList = new LinkedList<T>();
        }

        public LinkedQueue(IEnumerable<T> collection)
        {
            this.linkedList = new LinkedList<T>(collection);
        }

        public void Clear()
        {
            this.linkedList.Clear();
        }

        public void Enqueue(T item)
        {
            this.linkedList.AddLast(item);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked queue is empty!");
            }

            return this.linkedList.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked queue is empty!");
            }

            T item = this.linkedList.First.Value;
            this.linkedList.RemoveFirst();

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "Empty queue!";
            }

            StringBuilder result = new StringBuilder();

            LinkedListNode<T> nextItem = this.First;
            while (nextItem != null)
            {
                result.Append(String.Format("(Value: {0}, ", nextItem.Value));
                result.Append("Next: ");
                if (nextItem.Next != null)
                {
                    result.Append(String.Format("{0}, ", nextItem.Next.Value));
                }
                else
                {
                    result.Append("null, ");
                }
                result.Append("Prev: ");
                if (nextItem.Previous != null)
                {
                    result.Append(String.Format("{0}) -> ", nextItem.Previous.Value));
                }
                else
                {
                    result.Append("null) -> ");
                }
                result.AppendLine();
                nextItem = nextItem.Next;
            }

            result.Length -= 6;
            result.AppendLine();
            result.AppendLine(String.Format("Count: {0}", this.Count));

            return result.ToString();
        }
    }
}