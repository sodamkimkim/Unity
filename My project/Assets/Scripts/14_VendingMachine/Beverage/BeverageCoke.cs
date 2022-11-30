using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCoke : Beverage
{
    private void Start()
    {
        beverageName = "콜라";
        info = "맛있는 검정물";
        price = 1500;
    }

    public override void Drink()
    {
        Debug.Log("콜라 맛나네!");
    }
}
