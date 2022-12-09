using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle
{
    protected bool isReady = false;

    // # virtual - 자식이 재정의나 확장안했으면 부모거 쓴다.
    // 자식에서 재정의 되면 자식거를 쓴다.
    // => 재정의할 지 안할지는 자유.
    public virtual void EngineStart()
    {
        isReady = true;
        Debug.Log("Engine Start");
    }

    // # abstract method - 자식이 무조건 override해야한다.
    public abstract void Driving();
}
