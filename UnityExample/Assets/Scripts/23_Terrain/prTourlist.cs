using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prTourlist : MonoBehaviour
{
    private CharacterController cc = null;
    private Camera cam = null;
    private float moveSpeed = 1000f;
    private float rotSpeed = 100f;
    private Vector3 camRot = Vector3.zero;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        MovingProcess();
        LookProcess();
    }
    private void MovingProcess()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");

        Vector3 camF = cam.transform.forward;
        camF.y = 0f;
        camF.Normalize();
        Vector3 dirF = camF * axisV;

        Vector3 camR = cam.transform.right;
        camR.y = 0f;
        camR.Normalize();
        Vector3 dirR = camR * axisH;

        Vector3 dir = dirF + dirR;
        dir.Normalize();
        cc.SimpleMove(dir * moveSpeed * Time.deltaTime);
    }
    private void LookProcess()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camRot.x += -mouseY * rotSpeed * Time.deltaTime;
        camRot.y += mouseX * rotSpeed * Time.deltaTime;
        camRot.z = 0f;

        cam.transform.rotation = Quaternion.Euler(camRot);
    }
}

