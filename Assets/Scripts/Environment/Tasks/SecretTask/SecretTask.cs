using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Secret Task", menuName = "Scriptable Objects/Secret Task")]
    public class SecretTask : Task
    {
        [SerializeField] int[] secretArray = { 8, 2, 1, 3, 9 };

        
        public override void Execute()
        {
            
            isCompleted = false;
            PrintList(secretArray);
            Loop(secretArray);
            PrintList(secretArray);
        }

        public override void Resume()
        {
            
        }

        private void PrintList(int[] array)
        {
            Debug.Log(string.Join(" ", array));


        }
        private void Loop(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                IterateCompare(array);
            }
        }

        private void IterateCompare(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                Compare(secretArray, i);
            }
        }

        private void Compare(int[] array, int index)
        {
            //Guard
            if (index < 0 || index + 1 >= array.Length)
            {
                Debug.Log("Guard activate");
                return;
            }

            //Swap the numbers if right index is lower than the right
            if (array[index + 1] < array[index])
            {
                int temporary = array[index];

                array[index] = array[index + 1];
                array[index + 1] = temporary;

            }

            Debug.Log(string.Join(" ", secretArray));
            
        }

    }
}

