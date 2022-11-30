using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageStrawberryMilk : Beverage
{
    private void Start()
    {
        beverageName = "µþ±â¿ìÀ¯";
        info = "µþ±âÇâ ¿ìÀ¯";
        price = 1000;
    }

    public override void Drink()
    {
        Debug.Log("µþ±â¿ìÀ¯ ¸À³ª´Ù!");
    }
}
