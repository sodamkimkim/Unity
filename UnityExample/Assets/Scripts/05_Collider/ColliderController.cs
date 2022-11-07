using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    
    [SerializeField] private bool useAuto = false;

    private float moveSpeed = 10f;

    // # 런타임 타임 상수 - 생성과 동시에 초기화 필요 x -> 생성자에서만 초기화 가능
    private readonly float XMIN = -5f;

    // # 컴파일 타임 상수 - 생성과 동시에 초기화 필요
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

        //Vector3.Lerp
        // Lerp: Linear-Interpolation : 선형보간
        float lerpX = Mathf.Lerp(XMIN, XMAX, t);
        Vector3 newPos = transform.position;
        newPos.x = lerpX;
        transform.position = newPos;

    }
    private void Update()
    {
        if (!useAuto) InputProcess();
        else AutoMovingProcess();
    }

    // # 충돌 검출됐을 때 호출
    // Monobehavior 함수 오버라이딩
    // 우리가 호출하는 것이아니라 API 나 엔진이 호출해주는 함수 : Callback Function
    // rigidbody없으면 동작안한다. 충돌체 둘 중하나가 rigidbody있으면 충돌체크 되긴 된다. 
    //private void OnCollisionEnter(Collision _collision)
    //{
    //    Debug.Log("Collision Enter: " + _collision.gameObject.name);
    //}
    //// # 충돌 중일 때 호출
    //private void OnCollisionStay(Collision _collision)
    //{
    //    //Debug.Log("Collision Stay: " + _collision.gameObject.name);
    //}
    //// # 충돌 빠져나갈 때 호출
    //private void OnCollisionExit(Collision _collision)
    //{
    //    Debug.Log("Collision Exit : " + _collision.gameObject.name);
    //}
}
