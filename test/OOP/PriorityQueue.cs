using FinalAssignment_Algorithms.Structures;
using System;

namespace FinalAssignment_Algorithms.OOP
{
    internal class PriorityQueue<T>
    {
        private LinkedList<(T value, int priority)> list = new LinkedList<(T, int)>();

        public void Enqueue(T value, int priority)
        {
            // low pri first
            var node = list.Head;

            if (node == null)
            {
                list.AddLast((value, priority));
                return;
            }

            LinkedListNode<(T, int)> previous_ = null;

            while (node != null && node.Value.priority <= priority)
            {
                previous_ = node;
                node = node.Next;
            }
            // before node
            if (previous_ == null)
            {
                LinkedListNode<(T, int)> newNode = new LinkedListNode<(T, int)>((value, priority));
                newNode.Next = list.Head;
                list.Head = newNode;

                if (list.Tail == null)
                    list.Tail = newNode;

                list.Count++;
            }
            else
            {
                LinkedListNode<(T, int)> newNode = new LinkedListNode<(T, int)>((value, priority));
                newNode.Next = previous_.Next;
                previous_.Next = newNode;
                if (newNode.Next == null)
                    list.Tail = newNode;
                list.Count++;
            }
        }

        public T Dequeue()
        {
            var result = list.RemoveFirst();
            return result.value;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public LinkedList<(T value, int priority)> GetList()
        {
            return list;
        }
    }
}
