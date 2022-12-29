using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void DestroyCallback();
    private DestroyCallback destroyCallback = null;
    private HpBarHolder hpBarHolder = null;
    public void Init(Vector3 _pos, DestroyCallback _destroyCallback, HpBarHolder _hpBarHolder)
    {
        transform.position = _pos;
        destroyCallback = _destroyCallback;
        hpBarHolder = _hpBarHolder;
        hpBarHolder.SetPosition(_pos);
    }
    
} // end of class 
