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
            // # ���������� �浹 ����
            // screenpoint�� �ִ� �Ÿ� ray�� ����� �ִ� �ڵ�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("(Cannon) Hit : " + hit.transform.name);
                Instantiate(hitFXPrefab, hit.point, Quaternion.identity);
            }
        }

        
        
    }
}
