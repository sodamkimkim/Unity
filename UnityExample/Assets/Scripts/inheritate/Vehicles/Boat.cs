using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Vehicle
{
    // virtual method �����Ǵ� �����ε� ���⼭�� ����.
    public override void EngineStart()
    {
        //�ڽĲ� ���� ������ 
        // �θ� �����ϱ� 
        // Pumping -> Engine Start ����
        Debug.Log("Pumping");
        base.EngineStart();
    }
    public override void Driving()
    {
        Debug.Log("Driving Boat");
    }
}
