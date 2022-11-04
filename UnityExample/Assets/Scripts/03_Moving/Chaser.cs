using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private GameObject playerGO = null;
    private float movingSpeed = 5f; // Player���� ���ų� ������ �ȵȴ�.
    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        // chaser�� player�� ������ ������ ������ ���� -> ����ó��
        if (playerGO == null) return;

        if (Vector3.Distance(playerGO.transform.position, transform.position) > 10f) return;

        // 1. ���� ���ϱ� (Player ��ġ - Chaser��ġ)
        Vector3 dir = playerGO.transform.position - transform.position;

        // 2. ���� ����ȭ (���⺤�� ���ϱ�)
        dir.Normalize();

        // 3. �� �������� �̵�
        transform.position = transform.position + (dir * movingSpeed * Time.deltaTime);
    }
}
