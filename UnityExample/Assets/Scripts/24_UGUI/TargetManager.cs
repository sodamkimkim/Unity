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

    [SerializeField]
    private DefenceTower defenceTower = null;

    public Target GetTarget()
    {
        return target;
    }

    public void SpawnTarget(Target.DestroyCallback _destroyCallback)
    {
        // # Object Pooling
        // �� obj �����Ҵ� �� �س���, �ı��ϸ� ���°� �ƴ϶� ��ġ�� �̵��� ���� ��Ȱ�� �ϴ� ���
        if (target == null)
        {
            GameObject go = Instantiate(targetPrefab);
            target = go.GetComponent<Target>();
        }
        target.Init(GetRandomPosition(targetSpwnRange), _destroyCallback, hpBarHolder, defenceTower);
    }
    private Vector3 GetRandomPosition(float _range)
    {
        return new Vector3(Random.Range(-_range, _range), 0f, Random.Range(-_range, _range));
    }

    //private void TargetDestroyCallback()
    //{
    //    SpawnTarget();
    //}
} // end of class