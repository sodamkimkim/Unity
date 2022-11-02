using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HourTransform : MonoBehaviour
{
    float cosAlpha = 0f;
    float sinAlpha = 0f;

    Vector2 vX = new Vector2(1, 0);
    Vector2 vY = new Vector2(0, 1);

    public string GetCurrentHour()
    {
        string currentHour = DateTime.Now.ToString("HH");
        return currentHour;
    }

    void Start()
    {

        sinAlpha = Mathf.Sin(90 * Mathf.Deg2Rad); // 90µµ
        cosAlpha = Mathf.Cos(90 * Mathf.Deg2Rad); // 90µµ
        GetCurrentHour();

    }

    void Update()
    {
        string strCurrentHour = GetCurrentHour();
        int currentHour = Int32.Parse(strCurrentHour);
        if (currentHour >= 12)
        {
            currentHour = currentHour - 12;
        }
        float cosBeta = Mathf.Cos(-currentHour * 30 * Mathf.Deg2Rad);
        float sinBeta = Mathf.Sin(-currentHour * 30 * Mathf.Deg2Rad);

        transform.position = (vX * (cosAlpha * cosBeta - sinAlpha * sinBeta) * 12) + (vY * (sinAlpha * cosBeta + cosAlpha * sinBeta) * 12);
    }
}
