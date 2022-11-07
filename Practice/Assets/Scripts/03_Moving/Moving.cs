using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float movingSpeed = 10f;
    private float rotateSpeed = 30f;

    private void Update()
    {
        //MovingWithKey();
        MovingWithAxis();
        RotateWithKey();
    }
    private void MovingWithKey()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * movingSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (transform.forward * -1 * movingSpeed * Time.deltaTime);
        }
    }
    private void MovingWithAxis()
    {
        float axisV = Input.GetAxis("Vertical");
        float axisH = Input.GetAxis("Horizontal");
        float axisJ = Input.GetAxis("Jump");

        transform.Translate(Vector3.forward * axisV * movingSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * axisH * movingSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * axisJ * movingSpeed * Time.deltaTime);
    }
    private void RotateWithKey()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            //Vector3 eulerAngle = transform.rotation.eulerAngles;
            //eulerAngle.y -= rotateSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(eulerAngle);
            transform.Rotate(Vector3.up, -rotateSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E))
        {
            //Vector3 eulerAngle = transform.rotation.eulerAngles;
            //eulerAngle.y += rotateSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(eulerAngle);
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}