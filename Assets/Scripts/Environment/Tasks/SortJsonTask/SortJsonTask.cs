using System;
using UnityEngine;
using System.Collections.Generic;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Sorting Json Task", menuName = "Scriptable Objects/Sorting Json Task")]
    public class SortJsonTask : Task
    {
        [SerializeField] WorkerData workerData;

        public override void Execute()
        {
            isCompleted = false;

            //SortData();

            SortJsonTaskGUI.Instance.OpenGUI(this);
        }

        public override void Resume()
        {
            SortJsonTaskGUI.Instance.CloseGUI();
        }


        //Sorting the Workerdata by lastEntranceInEngineRoom
        public void SortData()
        {
            //Variabeln lastEntrace håller regeln som vi skapar
            IComparer<WorkerData.Employee> lastEntrance = 
            Comparer<WorkerData.Employee>.Create((a, b) => a.lastEntranceInEngineRoom.CompareTo(b.lastEntranceInEngineRoom));

            GenericMergeSort.Sort(workerData.employees, lastEntrance);


            //foreach (WorkerData.Employee employee in workerData.employees)
            //{
            //    Debug.Log(employee.name + ": " + employee.lastEntranceInEngineRoom);
            //}
            Complete();
        }



    }





}

