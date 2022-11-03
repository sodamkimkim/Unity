using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Needle : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)]
    private float angle = 0f;
    [SerializeField]
    private float radius = 1f;

    private void Update()
    {
        // 1�ʴ� ������ ����
        float angleOffset = 360f / 60f;
        float sec = Time.time % 60f;
        angle = sec * angleOffset;

        float x = Mathf.Cos(angle*(Mathf.PI/180f)) * radius; // 1���� * angle
        float y = Mathf.Sin(angle * (Mathf.Deg2Rad)) * radius;

        // ����ü Vector3 �����Ҵ�(new) -> C#������ ������ �ʿ� ����.
        transform.position = new Vector3(x, y, 0f);

        Debug.Log(Time.time);
        Debug.Log(DateTime.Now);
        Debug.Log(Int32.Parse(DateTime.Now.ToString("ss")) % 3600);
    }
}
