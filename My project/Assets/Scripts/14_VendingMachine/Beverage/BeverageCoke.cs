using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCoke : Beverage
{
    private void Start()
    {
        beverageName = "�ݶ�";
        info = "���ִ� ������";
        price = 1500;
    }

    public override void Drink()
    {
        Debug.Log("�ݶ� ������!");
    }
}
