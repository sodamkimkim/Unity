using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Transform : MonoBehaviour
{
 public string GetCurrentDate()
    {
        string currentDate = DateTime.Now.ToString();
        Debug.Log(currentDate);
        return currentDate;
    }

    private void Start()
    {
        GetCurrentDate();
    }
    private void Update()
    {
        GetCurrentDate();
    }
}

