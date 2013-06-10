using System;

namespace CustomStackNS
{
    public class CustomStack<T>
    {
        private const int defaultCapacity = 4;

        private T[] array;

        private int capacity;

        private int count;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public CustomStack()
        {
            this.capacity = defaultCapacity;
            this.array = new T[capacity];
            this.count = 0;
        }

        public CustomStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity cannot be less than one!");
            }
            this.array = new T[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public void Clear()
        {
            Array.Clear(this.array, 0, this.count);
            this.count = 0;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.array[this.Count - 1];
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            T poped = this.array[this.Count - 1];
            this.array[this.Count - 1] = default(T);
            this.count--;

            return poped;
        }

        public void Push(T item)
        {
            if (this.Count + 1 <= this.Capacity)
            {
                this.array[this.Count] = item;
            }
            else
            {
                this.capacity *= 2;
                T[] newArray = new T[capacity];
                Array.Copy(this.array, newArray, this.Count);
                newArray[this.Count] = item;
                this.array = newArray;
            }

            this.count++;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.array[this.Count - i - 1];
            }

            return array;
        }

        public void TrimExcess()
        {
            int length = this.array.Length;
            if (this.Count < length)
            {
                T[] array = new T[this.Count];
                Array.Copy(this.array, array, this.Count);
                this.array = array;
            }
        }

        public override string ToString()
        {
            return String.Join(", ", this.ToArray());
        }
    }
}
