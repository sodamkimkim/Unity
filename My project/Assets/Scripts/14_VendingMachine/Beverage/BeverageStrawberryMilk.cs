using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageStrawberryMilk : Beverage
{
    private void Start()
    {
        beverageName = "�������";
        info = "������ ����";
        price = 1000;
    }

    public override void Drink()
    {
        Debug.Log("������� ������!");
    }
}
