using System;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Gather Json Task", menuName = "Scriptable Objects/Gather Json Task")]
    public class GatherJsonTask : Task
    {
        [SerializeField] 
        private string textToPrint = "This Task will Gather Personal information";

        [SerializeField]
        private TextAsset json;
        [SerializeField]
        private WorkerData workerData;

        public override void Execute()
        {
            isCompleted = false;

            GatherJsonTaskGUI.Instance.OpenGUI(this);
        }

        public override void Resume()
        {
            GatherJsonTaskGUI.Instance.OpenGUI(this);
        }

        public void SendData()
        {

            WorkerData.Employee[] jsonData = JsonUtility.FromJson<WorkerData.EmployeesArray>(json.text)?.employees;

            if (jsonData == null) return;

            workerData.employees = jsonData;

            Complete();
        }

    }





}

