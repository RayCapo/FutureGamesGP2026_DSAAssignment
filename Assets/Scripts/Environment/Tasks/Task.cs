using UnityEngine;
using System;
using Unity.VisualScripting;

namespace Environment.Tasks
{
    public abstract class Task : ScriptableObject
    {
        public bool isCompleted { get; protected set; }
        public abstract void Execute();

        public event Action<Task> taskCompleted;

        protected void Complete()
        {
            Debug.Log("Completed: " + this.name);
            isCompleted = true;
            taskCompleted?.Invoke(this);
        }

        public virtual void Resume()
        {
            Execute();
        }


    }
}
