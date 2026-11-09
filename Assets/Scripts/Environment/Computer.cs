using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {

        [SerializeField] GameObject[] computerLights;
        [SerializeField] TMP_Text computerText;
        [SerializeField] bool enableStack;
        [SerializeField] List<Task> taskList = new();
        public Task currentTask;
        [SerializeField] private GenericQueue<Task> taskQueue;
        [SerializeField] private GenericStack<Task> taskStack;



        private void Awake()
        {

            if (enableStack)
            {
                taskStack = new GenericStack<Task>();
            }
            else
            {
                taskQueue = new GenericQueue<Task>();
            }

            foreach (Task task in taskList)
            {
                if (enableStack)
                    taskStack.Push(task);
                else
                    taskQueue.Enqueue(task);

            }
        }

        public void OnInteract()
        {

            if (currentTask != null && !currentTask.isCompleted)
            {
                currentTask.Resume();
                //Debug.Log(taskQueue.Peek().ToString());
                Debug.Log("Current task is not completed yet. Please complete it before proceeding to the next task.");
                return;
            }

            if (taskQueue.Count > 0 || taskStack.Count > 0)
            {
                //Debug.Log(taskQueue.Peek().ToString());
                currentTask = (enableStack)? taskStack.Pop(): taskQueue.Dequeue();
                currentTask.taskCompleted += OnTaskCompleted;
                currentTask.Execute();
            }
            else
            {
                Debug.Log("No more tasks to execute.");
            }
        }

        private void OnTaskCompleted(Task currentTask)
        {
            currentTask.taskCompleted -= OnTaskCompleted;

            foreach(GameObject light in computerLights)
            {
                if (!light.activeSelf)
                {
                    light.SetActive(true);
                    break;
                }
            }
        }


    }

    



}
