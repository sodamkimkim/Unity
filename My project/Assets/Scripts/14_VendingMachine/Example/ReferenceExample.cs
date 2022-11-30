using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceExample : MonoBehaviour
{
    public struct SStruct
    {
        public int i;
        public SStruct(int _i) { i = _i; }
    }

    private void Start()
    {
        SStruct[] structs =
        {
            new SStruct(1),
            new SStruct(2),
            new SStruct(3)
        };

        ChangeWithArray(structs);
        Debug.Log("structs[0]: " + structs[0].i);
        Debug.Log("structs[1]: " + structs[1].i);
        Debug.Log("structs[2]: " + structs[2].i);
    }

    private void ChangeWithArray(SStruct[] _structs)
    {
        _structs[0].i = 100;
        ChangeWithRef(ref _structs[1]);
        ChangeWithNew(ref _structs[2]);
    }

    private void ChangeWithRef(ref SStruct _struct)
    {
        _struct.i = 200;
    }

    private void ChangeWithNew(ref SStruct _struct)
    {
        SStruct newStruct = _struct;
        newStruct.i = 300;
    }
}
