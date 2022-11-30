using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    [SerializeField]
    private int[] arr = { 1, 2, 3 };
    [SerializeField]
    private int[] newArr = new int[5];
    [SerializeField]
    private int[] nullArr = null;

    private void Start()
    {
        Debug.Log("arr Length: " + arr.Length);
        Debug.Log("arr[0]: " + arr[0]);
        ChangeArrayValue(arr);
        Debug.Log("Change arr[0]: " + arr[0]);

        // Shallow Copy
        // Deep Copy
        int[] copyArr = arr;
        arr.Clone();

        // Range Based for Statement
        foreach (int i in arr)
            Debug.Log(i);

        for (int i = 0; i < arr.Length; ++i)
            Debug.Log(arr[i]);
    }

    private void ChangeArrayValue(int[] _arr)
    {
        _arr[0] = 100;
    }
}
