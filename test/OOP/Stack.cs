using FinalAssignment_Algorithms.Structures;

namespace FinalAssignment_Algorithms.OOP
{
    internal class Stack<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public void Push(T value)
        {
            list.AddLast(value);
        }

        public T Pop()
        {
            return list.RemoveLast();
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public LinkedList<T> GetList()
        {
            return list;
        }
    }
}
