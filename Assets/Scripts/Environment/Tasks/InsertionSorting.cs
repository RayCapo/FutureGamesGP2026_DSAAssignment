using System;
using UnityEngine;
using System.Collections.Generic;

public class InsertionSorting
{
    
    public static void InsertionSort<T>(T[] arr, IComparer<T> comp)
    {
        int n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            T key = arr[i];
            int j = i - 1;

            while(j >= 0 && comp.Compare(arr[j], key) > 0)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;

        }
    }

    static void PrintArray<T>(T[] arr)
    {
        Debug.Log(string.Join(" ", arr));
    }



}
