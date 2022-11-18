using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCider : Beverage
{
    private void Start()
    {
        beverageName = "사이다";
        info = " 투명한 설탕물";
        price = 800;
    }

    public override void Drink()
    {
        throw new System.NotImplementedException();
    }
}
