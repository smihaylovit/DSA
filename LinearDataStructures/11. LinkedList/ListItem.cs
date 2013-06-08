using System;

namespace CustomLinkedListNS
{
    public class ListItem<T>
    {
        private T item;

        private ListItem<T> next;

        private ListItem<T> prev;

        public T Value
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public ListItem<T> Next
        {
            get
            {
                if (this.next == null)
                {
                    return null;
                }

                return this.next;
            }
            internal set
            {
                this.next = value;
            }
        }

        public ListItem<T> Previous
        {
            get
            {
                if (this.prev == null)
                {
                    return null;
                }

                return this.prev;
            }
            internal set
            {
                this.prev = value;
            }
        }

        public ListItem(T value)
        {
            this.Value = value;
        }
    }
}
