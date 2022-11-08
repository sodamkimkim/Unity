using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private GameObject playerGo = null;

    [SerializeField, Range(5f, 10f)]
    private float movingSpeed = 5f;

    private void Start()
    {
        playerGo = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (playerGo != null) return;

        if (Vector3.Distance(playerGo.transform.position, transform.position) > 10f) return;

        Vector3 dir = playerGo.transform.position - transform.position;
        dir.Normalize();

        transform.position = transform.position + (dir * movingSpeed * Time.deltaTime);
    }
}
