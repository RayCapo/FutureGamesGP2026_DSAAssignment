using Environment.Tasks;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private List<Task> taskList = new(); // Put your stack/queue here :)
        private Queue<Task> taskQueue;

        private Task currenTask;



        private void Awake()
        {
            taskQueue = new Queue<Task>(taskList);      
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
