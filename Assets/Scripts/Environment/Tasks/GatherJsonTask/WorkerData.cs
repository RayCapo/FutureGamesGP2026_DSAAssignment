using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkerData", menuName = "Scriptable Objects/WorkerData")]
public class WorkerData : ScriptableObject
{

    //Information of one employee
    [Serializable]
    public class Employee
    {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom;
        public string TimeSpentInEngineRoom; //This one isnt implemented yet
    }


    //Used for the JsonUtility
    [Serializable]
    public class EmployeesArray
    {
        public Employee[] employees;
    }


    //The stored data
    public Employee[] employees;

    


}
