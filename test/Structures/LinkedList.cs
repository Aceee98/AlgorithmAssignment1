using System;

namespace FinalAssignment_Algorithms.Structures
{
    internal class LinkedList<T>
    {
        public LinkedListNode<T> Head;
        public LinkedListNode<T> Tail;
        public int Count;

        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Head == null)
                throw new Exception("List empty");

            T value = Head.Value;
            Head = Head.Next;
            Count--;

            if (Head == null)
                Tail = null;

            return value;
        }

        public T RemoveLast()
        {
            if (Head == null)
                throw new Exception("List empty");

            if (Head == Tail)
            {
                T value = Head.Value;
                Head = Tail = null;
                Count--;
                return value;
            }

            LinkedListNode<T> current = Head;

            while (current.Next != Tail)
                current = current.Next;

            T value2 = Tail.Value;
            current.Next = null;
            Tail = current;
            Count--;

            return value2;
        }
    }
}
