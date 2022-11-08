using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject hitFXPrefab = null;
    private void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            //Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // # 반직선으로 충돌 검출
            // screenpoint에 있는 거를 ray로 만들어 주는 코드
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("(Cannon) Hit : " + hit.transform.name);
                Instantiate(hitFXPrefab, hit.point, Quaternion.identity);
            }
        }

        
        
    }
}
