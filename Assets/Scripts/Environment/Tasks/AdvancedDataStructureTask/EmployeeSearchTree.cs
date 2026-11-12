
using UnityEngine;
using System.Collections.Generic;

public class EmployeeSearchTree
{
    
    private Node root;

    public void Build(List<WorkerData.Employee> sorted)
    {
        root = BuildTree(sorted, 0, sorted.Count - 1);
    }
    private Node BuildTree(List<WorkerData.Employee> sorted, int low, int high)
    {
        if (low > high) return null;

        int mid = (low + high) / 2;

        Node node = new Node(sorted[mid]);

        node.Left = BuildTree(sorted, low, mid - 1);
        node.Right = BuildTree(sorted, mid + 1, high);

        return node;
    }

    public List<WorkerData.Employee> Search(int minimumYear, int maximumYear, 
        int minimumMonth, int maximumMonth, int minimumDay, int maximumDay, int minimumHours, int maximumHours)
    {
        List<WorkerData.Employee> result = new();

        SearchTree(root, minimumYear, maximumYear, minimumMonth, maximumMonth, minimumDay, maximumDay, minimumHours, maximumHours, result);

        return result;
    }


    private void SearchTree(Node node, int minimumYear, int maximumYear, int minimumMonth, int maximumMonth, int minimumDay, int maximumDay, int minimumHours, int maximumHours, List<WorkerData.Employee> result)
    {
        if (node == null) return;
        SearchTree(node.Left, minimumYear, maximumYear, minimumMonth, maximumMonth, minimumDay, maximumDay, minimumHours, maximumHours, result);

        if(GetAndConvertToYearINT(node.Data) > minimumYear && GetAndConvertToYearINT(node.Data) < maximumYear)
        {
            result.Add(node.Data);
        }
        else if(GetAndConvertToYearINT(node.Data) == minimumYear || GetAndConvertToYearINT(node.Data) == maximumYear)
        {
            
            if(GetAndConvertToMonthINT(node.Data) > minimumMonth && GetAndConvertToMonthINT(node.Data) < maximumMonth)
            {
                result.Add(node.Data);
            }
            else if(GetAndConvertToMonthINT(node.Data) == minimumMonth || GetAndConvertToMonthINT(node.Data) == maximumMonth)
            {

                if (GetAndConvertToDayINT(node.Data) > minimumDay && GetAndConvertToDayINT(node.Data) < maximumDay)
                {
                    result.Add(node.Data);
                }
                else if(GetAndConvertToDayINT(node.Data) == minimumDay || GetAndConvertToDayINT(node.Data) == maximumDay)
                {
                    
                    if (GetAndConvertToHoursINT(node.Data) >= minimumHours && GetAndConvertToHoursINT(node.Data) < maximumHours)
                    {
                        result.Add(node.Data);
                    }
                }
            }
        }

        SearchTree(node.Right, minimumYear, maximumYear, minimumMonth, maximumMonth, minimumDay, maximumDay, minimumHours, maximumHours, result);
    }


    // Helper method to convert the year(int) from the lastEntranceInEngineRoom string
    private int GetAndConvertToYearINT(WorkerData.Employee employee)
    {
        return int.Parse(employee.lastEntranceInEngineRoom.Substring(0, 4));
    }
    private int GetAndConvertToMonthINT(WorkerData.Employee employee)
    {
        return int.Parse(employee.lastEntranceInEngineRoom.Substring(5, 2));
    }
    private int GetAndConvertToDayINT(WorkerData.Employee employee)
    {
        return int.Parse(employee.lastEntranceInEngineRoom.Substring(8, 2));
    }
    private int GetAndConvertToHoursINT(WorkerData.Employee employee)
    {
        return int.Parse(employee.lastEntranceInEngineRoom.Substring(11 , 2));
    }


}
