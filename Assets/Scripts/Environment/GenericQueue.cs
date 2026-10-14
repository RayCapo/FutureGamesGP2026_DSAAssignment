using System.Collections.Generic;


namespace Environment
{
    public class GenericQueue<T> {

        private List<T> queue;

        public int Count => queue.Count;
        public GenericQueue() {
            queue = new List<T>();
        }

        public void Enqueue(T InNewElement) {
            queue.Add(InNewElement);
        }

        public T Dequeue() {
            if(queue.Count == 0) {
                throw new System.InvalidOperationException("Queue is empty.");
            }

            T element = queue[0];
            queue.RemoveAt(0);
            return element;
        }

        public T Peek() {
            if(queue.Count == 0) {
                throw new System.InvalidOperationException("Queue is empty. No Peek available.");
            }

            return queue[0];
        }

        public void Clear() {
            queue.Clear();
        }

    }

}
 
