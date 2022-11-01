
// # Name - Space (네임 스페이스)
// ㄴ using 
using System.Collections;
using System.Collections.Generic;

//using UnityEngine;
// ㄴ ex) 원래 UnityEngine.MonoBehaviour 이렇게 써야 하는데, using (name-space)사용으로 MonoBehavior이렇게 쓸 수 있음.


// # C#은 #include로 헤더파일같은거 안찾는다. 대신 class명 == file명 => file찾을 때 class명 사용하면 바로 찾을 수 있게 설계되어 있다.
// ㄴ 클레스를 명확하게 정의하고, 해당 객체 이외 다른 기능이 있으면 안된다.

// # MonoBehaviour : MonoBehaviour is the base class from which every Unity script derives.
// ㄴ MonoBehaviour가 있어야 component로 넣을 수 있다.
public class Translate : UnityEngine.MonoBehaviour
{
    // # 클레스 멤버 변수 (Class Member Variables)
    // # 멤버 접근 범위 지정자 (Member Access Modifier)
    // ㄴ public, private, protected(상속관계)

    private int value = 10;
    
    // 클래스 객체(Class-Object)
    private UnityEngine.Transform tr = null; // Transform 색보면 class임을 알 수 있고 null로 초기화.. -> 포인터 개념과 비슷하게 사용( for 주소 접근)

    public void Func()
    {
        UnityEngine.Debug.Log("value: " + value);
    }

    // << Unity Script Life-Cycle >> -> MonoBehavior에 정의되어 있다.

    // # start() 
    // ㄴ 첫 번째 프레임이 그려지기 전에 호출된다.
    // Start is called before the first frame update
    // 멤버 접근 범위 지정자 default는 private임. ( void Start() == private void Start() )
    private void Start()
    {
        UnityEngine.Debug.Log("Start");

        // # Template ( Generic type)
        // component 자료형이 Transform (<Transform> 제네릭). 없으면 null로 초기화됨. => 예외처리 필요
        tr = this.GetComponent<UnityEngine.Transform>();
        // ㄴ 이 컴포넌트(이 스크립트)가 붙어있는 게임 오브젝트(this, named 'Translate' 큐브)에서 이 컴포넌트(<Transform>)를 주세요
        if(tr == null)
        {
            UnityEngine.Debug.LogError("tr is null!");
        }

        // # public class Transform : Component , IEnumerable
        // # public Vector3 position { get; set; }
        // ㄴ 컴퓨터 3차원 공간 vector로 표현
        //tr.position = tr.position + (UnityEngine.Vector3.right * 2f); // Vector3.right는 1,0,0 방향벡터 => ( 2, 0, 0 )
        //UnityEngine.Vector3.Dot : 내적
        //UnityEngine.Vector3.Magnitude : 벡터 길이
    }

    // # Update()
    // ㄴ Update is called once per frame
    // 매 프레임마다 수행. 유니티는 1초에 60번 frame이 그려진다. - > 1초에 60번 update()호출된다. 
    // ex) 키입력 대기 이벤트 리스너 여기 작성한다.
    private void Update()
    {
        // # tr.position = tr.position + (UnityEngine.Vector3.right);
        // ㄴ 1초당 (60, 0, 0)
        
        // # tr.position = tr.position + (UnityEngine.Vector3.right * 2f); // 1초당 (120, 0, 0)
        // ㄴ 속도 개념은 한 번 갈 때 벡터에 scalar곱 하는 거 이용한 거임
        
        tr.position = tr.position + (UnityEngine.Vector3.right * 2f * UnityEngine.Time.deltaTime);
        // ㄴ 좀 천천히 가게 함.
        // 초당 60frame  = 초당 60번 그림.

        // # deltaTime : 한 프레임 처리 후 다음 프레임 처리하는 시간 ( like,, thread.sleep() )
        // ㄴ 고정프레임일 때는 1[sec] / 60[frame] =>  0.01666 [sec/frame]
       
        // # deltaTime 곱해주는 이유? -> cpu별로 연산속도가 다르다.(=> frame 그려주는 속도가 다르다. => 보정해 주지 않으면 컴퓨터 성능별로 게임에서 이동 속도(프레임 그려주는 시간) 차이가 나게 된다.)걸리는 시간은 다르더라도 프레임 그려주는 결과는 같게 보정해주는 거임
    }

    // << vector >>
    // v( 2, 3 ) : 원점 ~> (2, 3)을 향하는 벡터

    // # vector의 상등
    // : 위치가 달라도 크기가 같으면 같은 벡터이다.

    // < vector 연산 >
    //-> 각 성분별로 더하고 빼면 된다.
    // ㄴ Scalar는 ( + )( - ) x
    // # (+)
    // ㄴ : va(1, 2) + vb(2, 1) = (3, 3) 

    // # (-) : 두 벡터간의 '방향'
    // ㄴ : va(1, 2) - vb(2, 2) = (-1, 0) -> vb에서 va로 향하는 벡터 나온다. (객체끼리의 '방향'을 구할 때 ( - ) 쓴다.)


    // # Scalar : 벡터공간에 있는 벡터가 아닌 그냥 숫자
    // ㄴ ( x ) , ( / ) ->벡터와 Scalar간의 연산 수행. 각 성분에 ( x ), ( / )하면 됨
    // 방향은 그대로 유지, Scalar만큼 크기 연산.

    // < Vector의 곱셈 >
    // ㄴ 내적( dot product ( dot() ), inner product) & 외적 ( cross product ( cross() ), outer product)

    // # dot product  
    // ㄴ 두 벡터간의 '각도'
    // : va(2, 2) ● vb(1, 3) : 시커먼 동그라미사용. 각 성분별로 곱한다음 더함
    // ㄴ (ax x bx) + (ay x by)
    // va(2, 2) ● vb(1, 3) = 2 + 6 = 8
    // => 두 벡터를 내적하면 Scalar가 나온다. ( 두 벡터간의 '각도')

    // # cross product
    // ㄴ 조명 계산 객체 벡터 외적해서 나온 벡터랑 광원벡터랑 내적 -> 객체와 광원간의 각도 나옴 => 조명으로부터 빛을 받는 양
    // 광원에서 오는 방향
    // ㄴ 3차원 공간에서만 존재
    // (x, y, z) 벡터가 나온다.
    // ㄴ  벡터들이 이루는 면을 수직으로 하는 벡터 나옴
    // ex) va(x, y, z) ⓧ vb(x, y, z) : x 동그라미 사용
    /*
     * 23 - 32, 31 - 13, 12 - 21
     * 23 31 12
     * va(x, y, z) ⓧ vb(x, y, z) = ay*bz - az*by , az*bx - ax*bz , ax*by - ay*bx
     */

    // # 벡터의 정규화(Normalization), # 방향 벡터(Normal vector)
    // ㄴ 3차원 공간에서 객체가 움직이는 방식
    // ㄴ 길이 1 이면서 방향을 가지고 있는 벡터
    // 각 성분을 스칼라(총길이)로 나눔
    // 

}
