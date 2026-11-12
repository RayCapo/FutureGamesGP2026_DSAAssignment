
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "AdvancedDataStruct Task", menuName = "Scriptable Objects/AdvancedDataStruct Task")]
    public class AdvancedDataStructTask : Task
    {
        [SerializeField] private WorkerData workerData;
        private EmployeeSearchTree employeeSearchTree;

        public override void Execute()
        {
            isCompleted = false;

            employeeSearchTree = null; // Reset the search tree before building it

            AdvancedDataStructTaskGUI.Instance.OpenGUI(this);
        }

        public override void Resume()
        {
            AdvancedDataStructTaskGUI.Instance.OpenGUI(this);
        }

        public void SortBuildAndSearch(int minimumYear, int maximumYear, int minimumMonth, int maximumMonth, int minimumDay, int maximumDay, int minimumHours, int maximumHours)
        {

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if(employeeSearchTree == null)
            {
                //Create a list of employees from the array (copy)
                List<WorkerData.Employee> employeesList = new List<WorkerData.Employee>(workerData.employees);

                //Create a new instance of the EmployeeSearchTree and build the tree with the sorted list
                employeeSearchTree = new EmployeeSearchTree();


                //Build the tree with the sorted list
                employeeSearchTree.Build(employeesList);
            }

            List<WorkerData.Employee> result = employeeSearchTree.Search(minimumYear, maximumYear, minimumMonth, maximumMonth, minimumDay, maximumDay, minimumHours, maximumHours);

            //Debug.Log("Employees found between " + minimumYear + " and " + maximumYear + ": " + result.Count);

            foreach (WorkerData.Employee employee in result)
            {
                Debug.Log(JsonUtility.ToJson(employee));
            }

            stopwatch.Stop();

            Debug.Log("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
            Debug.Log("Time taken: " + stopwatch.ElapsedTicks + " ticks");


            Complete();
        }
        

    }





}

