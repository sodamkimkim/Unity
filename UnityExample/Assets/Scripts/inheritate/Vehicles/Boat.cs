using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Vehicle
{
    // virtual method ÀçÁ¤ÀÇ´Â ÀÚÀ¯ÀÎµ¥ ¿©±â¼­´Â ÇØÁÜ.
    public override void EngineStart()
    {
        //ÀÚ½Ä²¨ ¸ÕÀú ÂïÈ÷°í 
        // ºÎ¸ð²¨ ÂïÈ÷´Ï±î 
        // Pumping -> Engine Start ³ª¿È
        Debug.Log("Pumping");
        base.EngineStart();
    }
    public override void Driving()
    {
        Debug.Log("Driving Boat");
    }
}
