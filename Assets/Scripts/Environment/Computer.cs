using Environment.Tasks;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private List<Task> taskList = new(); // Put your stack/queue here :)
        private GenericQueue<Task> taskQueue;

        private Task currenTask;

        private void Awake()
        {
            taskQueue = new GenericQueue<Task>();
            foreach (var task in taskList)
            {
                taskQueue.Enqueue(task);
            }
        }

        public void OnInteract()
        {
            if (taskQueue.Count > 0)
            {
                currenTask = taskQueue.Dequeue();
                currenTask.Execute();
            }
            else {
                Debug.Log("No more tasks to execute.");
            }
        }
    }
}
