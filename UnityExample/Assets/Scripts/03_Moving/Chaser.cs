using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private GameObject playerGO = null;
    private float movingSpeed = 5f; // Player보다 같거나 빠르면 안된다.
    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        // chaser는 player가 없으면 움직일 이유가 없다 -> 예외처리
        if (playerGO == null) return;

        if (Vector3.Distance(playerGO.transform.position, transform.position) > 10f) return;

        // 1. 방향 구하기 (Player 위치 - Chaser위치)
        Vector3 dir = playerGO.transform.position - transform.position;

        // 2. 방향 정규화 (방향벡터 구하기)
        dir.Normalize();

        // 3. 그 방향으로 이동
        transform.position = transform.position + (dir * movingSpeed * Time.deltaTime);
    }
}
