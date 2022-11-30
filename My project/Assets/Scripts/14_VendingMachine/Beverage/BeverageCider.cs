using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCider : Beverage
{
    private void Start()
    {
        beverageName = "사이다";
        info = "투명한 설탕물";
        price = 1300;
    }

    public override void Drink()
    {
        Debug.Log("사이다 맛나네!");
    }
}
