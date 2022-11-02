using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HourTransform : MonoBehaviour
{
    float cosAlpha = 0f;
    float sinAlpha = 0f;
    float beta = 0f;

    Vector2 vX = new Vector2(1, 0);
    Vector2 vY = new Vector2(0, 1);

    public string GetCurrentHour()
    {
        string currentHour = DateTime.Now.ToString("HH");
        return currentHour;
    }

    void Start()
    {

        sinAlpha = Mathf.Sin(90f);
        cosAlpha = Mathf.Cos(90f);
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
        beta = -currentHour * 30f;

        //sinTheta = Mathf.Sin(theta) * Mathf.Cos(90f) - Mathf.Cos(theta) * Mathf.Sin(90f);
        // cosTheta = Mathf.Cos(theta) * Mathf.Cos(90f) + Mathf.Sin(theta) * Mathf.Sin(90f);

        //transform.position = vX * cosTheta * Mathf.PI * 2 + vY * sinTheta * Mathf.PI * 2;
        /*        Debug.Log(currentHour);
                Debug.Log("theta : " + theta);
                Debug.Log("cos : " + cosTheta);
                Debug.Log("sin " + sinTheta);
                Debug.Log(transform.position);*/
        float cosBeta = Mathf.Cos(beta);
        float sinBeta = Mathf.Sin(beta);
        float radian = Mathf.PI * 2f;
        //transform.position = (vX * (cosAlpha * cosBeta - sinAlpha * sinBeta) * radian) + (vY * (sinAlpha * cosBeta + cosAlpha * sinBeta) * radian);
        transform.position = (vX * cosBeta * radian) + (vY * sinBeta * radian);

    }
}
