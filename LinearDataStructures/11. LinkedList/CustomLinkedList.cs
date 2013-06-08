using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedListNS
{
    public class CustomLinkedList<T>
    {
        private int count;

        private ListItem<T> head;

        public int Count 
        {
            get
            {
                return this.count;
            }
        }

        public ListItem<T> First
        {
            get
            {
                return this.head;
            }
        }

        public ListItem<T> Last
        {
            get
            {
                if (this.head == null)
                {
                    return null;
                }

                return this.head.Previous;
            }
        }

        public CustomLinkedList()
        {
        }

        public CustomLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null!");
            }
            foreach (T element in collection)
            {
                this.AddLast(element);
            }
        }

        private void InsertItemBefore(ListItem<T> listItem, ListItem<T> newListItem)
        {
            newListItem.Next = listItem;
            newListItem.Previous = listItem.Previous;
            listItem.Previous.Next = newListItem;
            listItem.Previous = newListItem;
            this.count++;
        }

        private void InsertItemToEmptyList(ListItem<T> newListItem)
        {
            newListItem.Next = newListItem;
            newListItem.Previous = newListItem;
            this.head = newListItem;
            this.count++;
        }

        private void RemoveItem(ListItem<T> listItem)
        {
            if (listItem.Next != listItem)
            {
                listItem.Next.Previous = listItem.Previous;
                listItem.Previous.Next = listItem.Next;
                if (this.head == listItem)
                {
                    this.head = listItem.Next;
                }
            }
            else
            {
                this.head = null;
            }

            listItem.Next = null;
            listItem.Previous = null;
            this.count--;
        }

        public ListItem<T> AddFirst(T value)
        {
            ListItem<T> listItem = new ListItem<T>(value);
            
            if (this.head != null)
            {
                this.InsertItemBefore(this.head, listItem);
                this.head = listItem;
            }
            else
            {
                this.InsertItemToEmptyList(listItem);
            }

            return listItem;
        }

        public ListItem<T> AddLast(T value)
        {
            ListItem<T> listItem = new ListItem<T>(value);

            if (this.head != null)
            {
                this.InsertItemBefore(this.head, listItem);
            }
            else
            {
                this.InsertItemToEmptyList(listItem);
            }

            return listItem;
        }

        public void Clear()
        {
            ListItem<T> nextItem = this.head;

            while (nextItem != null)
            {
                ListItem<T> listItem = nextItem;
                nextItem = nextItem.Next;
                listItem.Next = null;
                listItem.Previous = null;
            }

            this.head = null;
            this.count = 0;
        }

        public void Remove(ListItem<T> listItem)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException("List item is null!");
            }
            this.RemoveItem(listItem);
        }

        public void RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }
            this.RemoveItem(this.head);
        }

        public void RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }
            this.RemoveItem(this.head.Previous);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            ListItem<T> nextItem = this.head;
            do
            {
                result.AppendLine(String.Format("(Value: {0}, Next: {1}, Prev: {2}) -> ",
                    nextItem.Value, nextItem.Next.Value, nextItem.Previous.Value));
                nextItem = nextItem.Next;
            }
            while (nextItem != this.head);
            result.Length -= 6;
            result.AppendLine();
            result.AppendLine(String.Format("Count: {0}", this.Count));

            return result.ToString();
        }
    }
}
