using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

    private void Update()
    {
        transform.localScale =  Vector3.one *3*  (Mathf.Abs(Mathf.Sin(Time.time)/5+2));
    }
}
