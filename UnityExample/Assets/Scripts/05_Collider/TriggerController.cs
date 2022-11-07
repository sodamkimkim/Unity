using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TriggerController : MonoBehaviour
{
    [SerializeField] private bool useAuto = false;
    private float moveSpeed = 10f;
    private readonly float XMIN = -5f;
    private const float XMAX = 5f;
    private float t = 0f;

    private void InputProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x < XMIN)
            {
                Vector3 newPos = transform.position;
                newPos.x = XMIN;
                transform.position = newPos;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x > XMAX)
            {
                Vector3 newPos = transform.position;
                newPos.x = XMAX;
                transform.position = newPos;
            }
        }
    }
    private void AutoMovingProcess()
    {
        t += Time.deltaTime;
        if (t > 1f) t = 0f;

        float lefpX = Mathf.Lerp(XMIN, XMAX, t);
        Vector3 newPos = transform.position;
        newPos.x = lefpX;
        transform.position = newPos;
    }
    private void Update()
    {
        if (!useAuto) InputProcess();
        else AutoMovingProcess();
    }

    // # 매개변수: collision means, 충돌 체가 들어온다. 
    //private void OnCollisionEnter(Collision _collision)
    //{
    //    Debug.Log("Collision Enter: " + _collision.gameObject.name);
    //}

    // # collider가 들어온다. 충돌자체는 collision이 했지만 충돌체를 가진 내가 들어온다.
    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("Trigger Enter: " + _other.name);
    }
    private void OnTriggerStay(Collider _other)
    {
        Debug.Log("Trigger Stay : " + _other.name);
    }
    private void OnTriggerExit(Collider _other)
    {
        Debug.Log("Trigger Exit: " + _other.name);
    }

}
