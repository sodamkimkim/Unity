using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SecondTransform : MonoBehaviour
{



    float cosAlpha = 0f;
    float sinAlpha = 0f;
    float beta = 0f;

    Vector2 vX = new Vector2(1, 0);
    Vector2 vY = new Vector2(0, 1);

    public string GetCurrentSec()
    {
        string currentSec = DateTime.Now.ToString("ss");
        return currentSec;
    }
    private void Start()
    {

        sinAlpha = Mathf.Sin(90f);
        cosAlpha = Mathf.Cos(90f);
        GetCurrentSec();
    }


    private void Update()
    {
        string strCurrentSec = GetCurrentSec();
        int currentSec = Int32.Parse(strCurrentSec);
        beta = -currentSec * 6f / 60;
        /*
    B ( �������� ��) :  hour�� 30��, min�� 6��, sec�� 6��
    a(���� ��) : 90��
    */

        // (x cosB - y sin B, y cosB + x sin B)
        // x : cos a, y: sin a
        // (cos a * cos B - sin a * sin B, sin a * cosB + cos a * sin B)
        Debug.Log(currentSec);
        Debug.Log(beta);
        float cosBeta = Mathf.Cos(beta);
        float sinBeta = Mathf.Sin(beta);
        float radian = Mathf.PI * 2f;
        //transform.position = (vX * (cosAlpha * cosBeta - sinAlpha * sinBeta) * radian) + (vY * (sinAlpha * cosBeta + cosAlpha * sinBeta) * radian);
        transform.position = (vX * cosBeta * radian) + (vY * sinBeta * radian);
    }

}
