using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class ComponentTest : MonoBehaviour
{
    private Rigidbody rb = null;
    private Transform[] trs = null;

    private void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        if (rb == null)
        {
            //Debug.LogError("Rigidbody is null!!");
            rb = GetComponent<Rigidbody>();
        }

        trs = GetComponentsInChildren<Transform>();
        Debug.Log("trs Length: " + trs.Length);
        for (int i = 0; i < trs.Length; ++i)
            Debug.Log(i + ": " + trs[i].name);

        Transform childTr =
            GetComponentInChildren<Transform>();
        Debug.Log("childTr: " + childTr.name);

        Capsule capsule =
            GetComponentInChildren<Capsule>();
        Debug.Log("capsule: " + capsule.gameObject.name);
        Rigidbody capsuleRb =
            capsule.gameObject.AddComponent<Rigidbody>();
        capsuleRb.useGravity = false;

        Destroy(capsule);
        //Destroy(capsule.gameObject);
    }
}
