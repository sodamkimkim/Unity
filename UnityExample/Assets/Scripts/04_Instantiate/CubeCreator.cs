using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    // cube를 만들어줄 클래스
    // 큐브의 원본을 가지고 와야한다.
    // 유니티 인스펙터에서 넣어준다.
    [SerializeField]
    private GameObject cubePrefab = null;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(cubePrefab);
            // CubeCreator위치 기준으로 GameObject cubePrefab 인스턴스생성
            go.transform.position = transform.position + new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));

            Destroy(go,2f);// 1초 뒤에 파괴
        }
    }

}
