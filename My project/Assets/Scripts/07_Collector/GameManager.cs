using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab = null;
    [SerializeField]
    private GameObject bombPrefab = null;

    private void Start()
    {
        // Thread, Task-Manager
        // ÄÚ·çÆ¾(Co-Routine)
        StartCoroutine(SpawnCoroutine());
    }

    private Vector3 GetRndPos()
    {
        return new Vector3(
            Random.Range(-20f, 20f),
            0f,
            Random.Range(-20f, 20f)
            );
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(coinPrefab,
                GetRndPos(), Quaternion.identity);
            Instantiate(bombPrefab,
                GetRndPos(), Quaternion.identity);

            yield return new WaitForSeconds(3f);
        }
    }
}
