using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EmployeeSearchTree : MonoBehaviour
{
    
    private Node root;

    public void Build(List<WorkerData.Employee> sorted)
    {
        root = BuildTree(sorted, 0, sorted.Count - 1);
    }

    public List<WorkerData.Employee> Search(int minimumYear, int maximumYear)
    {
        List<WorkerData.Employee> result = new List<WorkerData.Employee>();
        SearchTree(root, minimumYear, maximumYear, result);
        return result;
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

    private void SearchTree(Node node, int minimumYear, int maximumYear, List<WorkerData.Employee> result)
    {
        if (node == null) return;

        SearchTree(node.Left, minimumYear, maximumYear, result);

        if(GetAndConvertToYear(node.Data) >= minimumYear && GetAndConvertToYear(node.Data) <= maximumYear)
        {
            result.Add(node.Data);
        }

        SearchTree(node.Right, minimumYear, maximumYear, result);
    }


    // Helper method to convert the year(int) from the lastEntranceInEngineRoom string
    private int GetAndConvertToYear(WorkerData.Employee employee)
    {
        return int.Parse(employee.lastEntranceInEngineRoom.Substring(0, 4));
    }
}
