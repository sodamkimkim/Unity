using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    [SerializeField]
    private GameObject targetPrefab = null;

    [SerializeField]
    private HpBarHolder hpBarHolder = null;

    private float targetSpwnRange = 15f;
    private Target target = null;

    private void Start()
    {
        SpawnTarget();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
            SpawnTarget();
    }
    private void SpawnTarget()
    {
        // # Object Pooling
        // ㄴ obj 동적할당 다 해놓고, 파괴하며 쓰는게 아니라 위치만 이동해 가며 재활용 하는 기법
        if (target == null)
        {
            GameObject go = Instantiate(targetPrefab);
            target = go.GetComponent<Target>();
        }
        target.Init(GetRandomPosition(targetSpwnRange), TargetDestroyCallback, hpBarHolder);
    }
    private Vector3 GetRandomPosition(float _range)
    {
        return new Vector3(Random.Range(-_range, _range), 0f, Random.Range(-_range, _range));
    }

    private void TargetDestroyCallback()
    {
        SpawnTarget();
    }
} // end of class
