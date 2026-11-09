using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Environment
{
    [Serializable]
    public class GenericQueue<T>
    {

        [SerializeField] private List<T> queue;

        public int Count => queue.Count;
        public GenericQueue()
        {
            queue = new List<T>();
        }

        public void Enqueue(T InNewElement)
        {
            queue.Add(InNewElement);
        }

        public T Dequeue()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T element = queue[0];
            queue.RemoveAt(0);
            return element;
        }

        public T Peek()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty. No Peek available.");
            }

            return queue[0];
        }

        public void Clear()
        {
            queue.Clear();
        }

    }

    [Serializable]
    public class GenericStack<T>
    {

        [SerializeField] private List<T> stack;

        public int Count => stack.Count;
        public GenericStack()
        {
            stack = new List<T>();
        }

        public void Push(T InNewElement)
        {
            stack.Add(InNewElement);
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                throw new System.InvalidOperationException("Queue is empty.");
            }


            T element = stack[Count - 1];
            stack.RemoveAt(Count - 1);
            return element;
        }

        public T Peek()
        {
            if (stack.Count == 0)
            {
                throw new System.InvalidOperationException("Queue is empty. No Peek available.");
            }

            return stack[Count - 1];
        }

        public void Clear()
        {
            stack.Clear();
        }

    }
}

