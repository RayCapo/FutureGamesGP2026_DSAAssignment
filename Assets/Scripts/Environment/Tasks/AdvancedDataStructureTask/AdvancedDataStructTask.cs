using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

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

        public void SortAndBuildTree()
        {
            List<WorkerData.Employee> employeesList = new List<WorkerData.Employee>(workerData.employees);

            employeeSearchTree = new EmployeeSearchTree();
            employeeSearchTree.Build(employeesList);

            Complete();
        }
        

    }





}

