using FinalAssignment_Algorithms.Structures;

namespace FinalAssignment_Algorithms.OOP
{
    internal class Queue<T>
    {
        // makes linked list to store the queue
        private LinkedList<T> list = new LinkedList<T>();


        // add to queue
        public void AddToTheQueue(T value){
            list.AddLast(value);
        }

        // remove from queue
        public T Dequeue(){
            return list.RemoveFirst();
        }


        public bool Empty_(){
            return list.Count == 0;
        }

        public LinkedList<T> GetOtherList()
        {
            return list;
        }

    }
}
