using System.Collections.Generic;

public static class GenericMergeSort
{
   static void Merge<T>(T[] array, int left, int middle, int right, IComparer<T> comparer)
    {

        
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        
        T[] tempLeftArray = new T[leftSize];
        T[] tempRightArray = new T[rightSize];

        
        int i; 
        int j;

        
        for (i = 0; i < leftSize; ++i)
            tempLeftArray[i] = array[left + i];

        //Högra arrayen
        for (j = 0; j < rightSize; ++j)
            tempRightArray[j] = array[middle + 1 + j];


        //Nollställer indexen för de 2 temporära arrayerna
        i = 0;
        j = 0;

        //k 
        int k = left;

        while(i < leftSize && j < rightSize)
        {
            if (comparer.Compare(tempLeftArray[i], tempRightArray[j]) <= 0)
            {
                array[k] = tempLeftArray[i];
                i++;
            }
            else
            {
                array[k] = tempRightArray[j];
                j++;
            }
            k++;
        }

        while(i < leftSize)
        {
            array[k] = tempLeftArray[i];
            i++;
            k++;
        }

        while(j < rightSize)
        {
            array[k] = tempRightArray[j];
            j++;
            k++;
        }


    }

    static void SortRange<T>(T[] array, int left, int right, IComparer<T> comparer)
    {
        if(left < right)
        {
            int middlePoint = left + (right - left) / 2;

            SortRange(array, middlePoint + 1, right, comparer);
            SortRange(array, left, middlePoint, comparer);

            Merge(array, left, middlePoint, right, comparer);

        }


    }

    public static void Sort<T>(T[] array, IComparer<T> comparer)
    {
        SortRange(array, 0, array.Length - 1, comparer);
    }


}
