using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle
{
    protected bool isReady = false;

    // # virtual - �ڽ��� �����ǳ� Ȯ��������� �θ�� ����.
    // �ڽĿ��� ������ �Ǹ� �ڽİŸ� ����.
    // => �������� �� �������� ����.
    public virtual void EngineStart()
    {
        isReady = true;
        Debug.Log("Engine Start");
    }

    // # abstract method - �ڽ��� ������ override�ؾ��Ѵ�.
    public abstract void Driving();
}
