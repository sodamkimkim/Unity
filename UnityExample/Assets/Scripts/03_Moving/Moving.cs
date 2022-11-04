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
        if (Input.GetKey(KeyCode.W))
        {
            // Vector3�� ������ġ���� forward => ȸ���� ���� ������� ������� �� ��(z�����)�� �����̰� �ȴ�.
            // transform.forward�ϸ� ���ñ��� forward. => ȸ���� �������� �����̰� �ȴ�.
            transform.position = transform.position + (transform.forward * movingSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (-transform.forward * movingSpeed * Time.deltaTime);
        }
    }

    private void MovingWithAxis()
    {
        // �ప ������� ( -1~ 1 ���� ������ �� ���� �̿��ؼ� forward������ ���� �ٲ۴�)
        float axisV = Input.GetAxis("Vertical");

        // ������ġ���� ��ȭ�ִ¹�� , �����ġ
        //transform.position = transform.position + (transform.forward * axisV * movingSpeed * Time.deltaTime);

        // ������ǥ���. ���� �� ����, ������ġ �ʿ����. 
        //transform.Translate(
        //    transform.forward * axisV * movingSpeed * Time.deltaTime);
        //���� ������� �ҰŸ� transform.forward�� �ƴ϶� Vector3.forward�� �Ǿ����.
        // transform.Translate���ϱ� �̹� rotate�������� �ݿ��Ǿ�����
        transform.Translate(
           Vector3.forward * axisV * movingSpeed * Time.deltaTime);
    }
    private void RotateWithKey()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 eulerAngle = transform.rotation.eulerAngles;
            eulerAngle.y -= rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(eulerAngle);
            // ���ʹϾ��� +���� �ȵȴ�.
            //transform.rotation = transform.rotation + (Quaternion.Euler(0f, rotateSpeed*Time.deltaTime, 0f));
        }
        if (Input.GetKey(KeyCode.E))
        {
            // # transform.rotation -> world���� ��. => �󸶳� ������ +=�� total�� ����ؼ� 
            //0�������� update���� total ���� ���Ӱ� �׷��ִ� ��.
            //Vector3 eulerAngle = transform.rotation.eulerAngles;
            //eulerAngle.y += rotateSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(eulerAngle);
            ////////////////////////////
            
            // �Ű����� �κп� ctrol + shift + space -> �Ű����� Ȯ��

            //# transform.Rotate�Լ� ����� ��밪.
            // ��������� �󸶳� ���������� ����
            //�� Vector3.up, 1 -> ���� �� ����(������� ����)���� +1��
            // ���� �� ������ Vector3.up�� �������� rotateSpeed��ŭ ������.
            transform.Rotate(Vector3.up,rotateSpeed*Time.deltaTime);
        }
    }
} // end of Moving class
