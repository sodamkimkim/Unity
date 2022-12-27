using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 과제 ) 각도 못넘어가게 
public class Tourlist : MonoBehaviour
{
    [SerializeField]
    private GameObject fxPangPrefab = null;

    [SerializeField]
    private GameObject fxFireBoost = null;

    private CharacterController cc = null;
    private Camera cam = null;
    private float moveSpeed = 1000f;
    private float rotSpeed = 50f;
    private Vector3 camRot = Vector3.zero;


    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        //camRot = cam.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        MovingProcess();
        LookProcess();
        if (Input.GetMouseButtonDown(0))
            SpawnFxPang();
    }
    private void MovingProcess()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        GameObject bostGo = null;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 5000f;
            Vector3 pos = transform.position;
            pos.y = transform.position.y - transform.localScale.y + 1f;

            bostGo = Instantiate(fxFireBoost, pos, Quaternion.Euler(0f, 0f, 0f));
            bostGo.transform.SetParent(transform);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 1000f;
            Destroy(bostGo);

        }

        Vector3 camF = cam.transform.forward;
        // y축 0으로 초기화
        camF.y = 0f;
        camF.Normalize();
        Vector3 dirF = camF * axisV;

        Vector3 camR = cam.transform.right;
        camR.y = 0f;
        camR.Normalize();
        Vector3 dirR = camR * axisH;

        Vector3 dir = dirF + dirR;
        dir.Normalize();

        // 중력 계산안하고 움직인다.
        //cc.Move
        // 중력 계산하고 움직인다. rigidbody없는 상황에서는 simpleMove 쓰면 된다.
        cc.SimpleMove(dir * moveSpeed * Time.deltaTime);
    }
    private void LookProcess()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

       
        camRot.x += -mouseY * rotSpeed * Time.deltaTime;
        camRot.y += mouseX * rotSpeed * Time.deltaTime;
        camRot.z = 0f;
        Debug.Log("(camRot.x: )-mouseY * rotSpeed * Time.deltaTime: " + -mouseY * rotSpeed * Time.deltaTime);
        Debug.Log("(camRot.y: ) mouseX * rotSpeed * Time.deltaTime: " + mouseX * rotSpeed * Time.deltaTime);

        // Tourist랑 카메라랑 각도 제한
        cam.transform.rotation = Quaternion.Euler(camRot);
    }
    private void SpawnFxPang()
    {
        Instantiate(fxPangPrefab, cam.transform.position + (cam.transform.forward * 3f), Quaternion.identity);
    }

}
