using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // private으로 선언해서 은닉하되 인스펙터뷰에서 관리하기 위해 SerializeField써줌
    [SerializeField, Range(0f, 360f)]
    private float rotX = 0f;

    // Range : 변수 범위 지정. 
    [SerializeField, Range(0f, 360f)]
    private float rotY = 0f;

    // public - 인스펙터뷰에서 표시된다.
    [SerializeField, Range(0f, 360f)]
    private float rotZ = 0f;

    private void Update()
    {
        // transform은 UnityEngine에 기본적으로 만들어져 있다.
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }


    /*
     < Rotate >
     - θ가 정해졌을 때 변화한 정점의 위치를 구하는 것
     
     # Pitch
     : x축 회전

    # Yaw
    : Y축 회전

    # Roll
    : Z축 회전

    # 오일러 앵글
     - x -> y -> z 순으로 각각 한 축을 다 돌리고 다른 축 회전을 하는 방식
     - 축을 옮기는 방식

     - # 짐벌락 현상
    ㄴ rotation 축이 겹쳐서 자유도를 잃어버리는 현상 (x, y, z : 3축 자유도) -> x축 90도 rotate => (y, z : 2축 자유도)

    # 쿼터니언(Quaternion) : 사원수
    - 오일러 앵글 보완
    - 복소수 개념으로 rotate 구현
    - 순차적 회전이 아니라 임의의 축 하나를 만들어서 그 축을 기준으로 회전. ( 짐벌락 해결 )
    
    # World 좌표계
    - 전체 세계관 중심의 좌표
    - position이동이 일어나면 이 원점을 기준으로 좌표가 정해진다.

    # Local 좌표계
    - 객체 각자만의 좌표
    - 원점은 각자 정의할 수 있고, 원점으로부터 정점이 얼마나 떨어져있는지 기억을 해 두고, rotation이 일어나면 이 원점을 기준으로 좌표가 정해진다.
    - rotation할 때 local 좌표계를 기준으로 수행된다.
     */

}
