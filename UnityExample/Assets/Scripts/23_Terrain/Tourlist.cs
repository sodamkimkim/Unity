using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ) ���� ���Ѿ�� 
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
        // y�� 0���� �ʱ�ȭ
        camF.y = 0f;
        camF.Normalize();
        Vector3 dirF = camF * axisV;

        Vector3 camR = cam.transform.right;
        camR.y = 0f;
        camR.Normalize();
        Vector3 dirR = camR * axisH;

        Vector3 dir = dirF + dirR;
        dir.Normalize();

        // �߷� �����ϰ� �����δ�.
        //cc.Move
        // �߷� ����ϰ� �����δ�. rigidbody���� ��Ȳ������ simpleMove ���� �ȴ�.
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

        // Tourist�� ī�޶�� ���� ����
        cam.transform.rotation = Quaternion.Euler(camRot);
    }
    private void SpawnFxPang()
    {
        Instantiate(fxPangPrefab, cam.transform.position + (cam.transform.forward * 3f), Quaternion.identity);
    }

}
