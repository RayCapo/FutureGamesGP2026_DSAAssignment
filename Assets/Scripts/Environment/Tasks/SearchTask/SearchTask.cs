using System;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Search Task", menuName = "Scriptable Objects/Search Task")]
    public class SearchTask : Task
    {
        [SerializeField] 
        private string textToPrint = "This Task will Search for Personal information between two values";

        [SerializeField] WorkerData workerData;

        public override void Execute()
        {
            isCompleted = false;
            SearchTaskGUI.Instance.OpenGUI(this);

        }

        public override void Resume()
        {
            SearchTaskGUI.Instance.OpenGUI(this);
        }

        public void Search(int lowValue, int highValue)
        {
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            int firstIndex = FindFirstIndex(workerData.employees, lowValue);
            int lastIndex = FindLastIndex(workerData.employees, highValue);

            //Debug.Log("Employees: " + workerData.employees.Length);
            Debug.Log("Searching " + lowValue + " to " + highValue);
            Debug.Log("firstIndex = " + firstIndex + ", lastIndex = " + lastIndex);

            for (int i = firstIndex; i <= lastIndex; i++)
            {
                Debug.Log(workerData.employees[i].name + ": " + workerData.employees[i].lastEntranceInEngineRoom);
            }

            stopwatch.Stop();

            Debug.Log("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");

            Complete();
        }
        

        private int FindFirstIndex(WorkerData.Employee[] employees, int lowValue)
        {

            int low = 0;
            int high = employees.Length - 1;
            int result = employees.Length;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (GetAndConvertToYear(employees[mid]) >= lowValue)
                {
                    result = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return result;
        }
        private int FindLastIndex(WorkerData.Employee[] employees, int highValue)
        {
            int low = 0;
            int high = employees.Length - 1;
            int result = -1;

            while(low <= high)
            {
                int mid = low + (high - low) / 2;

                if (GetAndConvertToYear(employees[mid]) <= highValue)
                {
                    result = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return result;
        }

        private int GetAndConvertToYear(WorkerData.Employee employee)
        {
            //Returns the first 4 digits of the string as an integer, which is the year of the last entrance in the engine room
            return int.Parse(employee.lastEntranceInEngineRoom.Substring(0, 4));
        }   


    }





}

