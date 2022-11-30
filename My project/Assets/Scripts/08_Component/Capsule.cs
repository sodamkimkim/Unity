using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private void Awake()
    {
        gameObject.name = "MyCapsule";

        GetComponent<CapsuleCollider>().isTrigger = true;
        GetComponent<CapsuleCollider>().enabled = false;

        Debug.Log("Capsule Active: " +
                  gameObject.activeSelf);
        gameObject.SetActive(false);
    }
}
