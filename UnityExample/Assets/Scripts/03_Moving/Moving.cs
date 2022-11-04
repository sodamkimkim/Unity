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
            // Vector3는 절대위치기준 forward => 회전한 방향 상관없이 월드기준 앞 뒤(z축따라)로 움직이게 된다.
            // transform.forward하면 로컬기준 forward. => 회전한 방향으로 움직이게 된다.
            transform.position = transform.position + (transform.forward * movingSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (-transform.forward * movingSpeed * Time.deltaTime);
        }
    }

    private void MovingWithAxis()
    {
        // 축값 가지고옴 ( -1~ 1 값을 가지고 이 값을 이용해서 forward만으로 방향 바꾼다)
        float axisV = Input.GetAxis("Vertical");

        // 현재위치에서 변화주는방식 , 상대위치
        //transform.position = transform.position + (transform.forward * axisV * movingSpeed * Time.deltaTime);

        // 절대좌표방식. 증분 값 없음, 원래위치 필요없음. 
        //transform.Translate(
        //    transform.forward * axisV * movingSpeed * Time.deltaTime);
        //ㄴ이 방식으로 할거면 transform.forward가 아니라 Vector3.forward가 되어야함.
        // transform.Translate쓰니까 이미 rotate값같은거 반영되어있음
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
            // 쿼터니언은 +연산 안된다.
            //transform.rotation = transform.rotation + (Quaternion.Euler(0f, rotateSpeed*Time.deltaTime, 0f));
        }
        if (Input.GetKey(KeyCode.E))
        {
            // # transform.rotation -> world기준 값. => 얼마나 돌릴지 +=로 total값 계산해서 
            //0도값에서 update마다 total 각도 새롭게 그려주는 거.
            //Vector3 eulerAngle = transform.rotation.eulerAngles;
            //eulerAngle.y += rotateSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(eulerAngle);
            ////////////////////////////
            
            // 매개변수 부분에 ctrol + shift + space -> 매개변수 확인

            //# transform.Rotate함수 사용은 상대값.
            // 상대적으로 얼마나 돌릴건지만 넣음
            //ㄴ Vector3.up, 1 -> 현재 내 각도(상대적인 개념)에서 +1도
            // 지금 내 값에서 Vector3.up을 기준으로 rotateSpeed만큼 돌린다.
            transform.Rotate(Vector3.up,rotateSpeed*Time.deltaTime);
        }
    }
} // end of Moving class
