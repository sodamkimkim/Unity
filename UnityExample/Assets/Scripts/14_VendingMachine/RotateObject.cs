using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50f;
    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        //StartCoroutine(Sleep());

    }
    //private IEnumerator Sleep()
    //{
    //    while(true)
    //    {
    //    transform.Translate(transform.position + Vector3.up * moveSpeed);
    //    yield return new WaitForSeconds(1f);
    //    transform.Translate(transform.position + Vector3.up * -moveSpeed);

    //    }
    //}
}
