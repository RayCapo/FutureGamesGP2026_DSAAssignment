using Unity.VisualScripting;
using UnityEngine;
using static WorkerData;

public class Test : MonoBehaviour
{
    
    string text = "ABCEDFGA";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int A = CountA();
        Debug.Log("Number of A's: " + A);
    }

    int CountA()
    {
        int A = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'A') A++;
        }
        return A;
    }
}
