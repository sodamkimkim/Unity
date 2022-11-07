using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float movingSpeed = 10f;
    private float rotateSpeed = 100f;

    private void Update()
    {
        //MovingWithKey();
        MovingWithAxis();

        RotateWithKey();
    }

    private void MovingWithKey()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position =
                transform.position +
                // Vector3 ¿ùµåÁÂÇ¥ ±âÁØ
                (transform.forward *
                 movingSpeed *
                 Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position =
                transform.position +
                (-transform.forward *
                movingSpeed *
                Time.deltaTime);
        }
    }

    private void MovingWithAxis()
    {
        float axisV = Input.GetAxis("Vertical");
        //transform.position =
        //    transform.position +
        //    (transform.forward *
        //     axisV *
        //     movingSpeed *
        //     Time.deltaTime);
        transform.Translate(
            Vector3.forward *
            axisV *
            movingSpeed *
            Time.deltaTime);
    }

    private void RotateWithKey()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 eulerAngle = transform.rotation.eulerAngles;
            eulerAngle.y -= rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(eulerAngle);

            // ÄõÅÍ´Ï¾ðÀº +¿¬»ê ¾ÈµÊ
            //transform.rotation =
            //    transform.rotation +
            //    (Quaternion.Euler(
            //        0f,
            //        rotateSpeed * Time.deltaTime,
            //        0f));
        }

        if (Input.GetKey(KeyCode.E))
        {
            //Vector3 eulerAngle = transform.rotation.eulerAngles;
            //eulerAngle.y += rotateSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(eulerAngle);

            transform.Rotate(
                Vector3.up,
                rotateSpeed * Time.deltaTime);
        }
    }
} // class Moving
