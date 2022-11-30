using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructExample : MonoBehaviour
{
    // Function Call Overhead
    [System.Serializable]
    public struct SStruct
    {
        //private int sInt;
        //public int SInt { get { return sInt; } }
        public int sInt { get; set; }
        public float sFloat;
        public bool sBool;

        public SStruct(
            int _sInt, float _sFloat, bool _sBool)
        {
            sInt = _sInt;
            sFloat = _sFloat;
            sBool = _sBool;
        }
        public void SFunc() {
            Debug.Log("Struct Function! : " + sInt);
        }
    }

    [System.Serializable]
    public class CClass
    {
        [SerializeField]
        private int cInt = 0;
        public int CInt {
            get { return cInt; }
            set { cInt = value; }
        }
        public CClass()
        {
            cInt = 10;
        }
        public void CFunc() {
            Debug.Log("Class Function! : " + cInt);
        }
    }


    [SerializeField]
    private SStruct sStruct = new SStruct();
    [SerializeField]
    private CClass cClass = new CClass();
    [SerializeField]
    private MeshRenderer mr = null;
    public int iValue;


    private void Start()
    {
        // Value Type
        SStruct s = new SStruct();
        //SStruct s = new SStruct { sInt = 10 };
        s.sInt = 100;
        ChangeValue(s);
        s.SFunc();

        // Reference Type
        CClass c = new CClass();
        c.CInt = 200;
        ChangeValue(c);
        c.CFunc();

        int value = 0;
        //ChangeValue(ref value);
        ChangeValue(out value);
        Debug.Log("value: " + value);
    }

    // Call-By-Value
    private void ChangeValue(SStruct _s)
    {
        _s.sInt = 500;
    }

    // Call-By-Reference
    private void ChangeValue(CClass _c)
    {
        _c.CInt = 600;
    }

    //private void ChangeValue(ref int _value)
    //{
    //    _value = 1000;
    //}

    private void ChangeValue(out int _value)
    {
        _value = 2000;
    }

    private void ChangePosition(Vector3 _pos)
    {
        _pos.x = 100f;
    }

    private void ChangePosition(Transform _tr)
    {
        _tr.position =
            new Vector3(100f, 0f, 0f);
    }
}
