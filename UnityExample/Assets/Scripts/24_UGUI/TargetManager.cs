using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPrefab = null;
    [SerializeField]
    private HpBarHolder hpBarHolder = null;
    private float targetSpawnRange = 15f;
    private Target target = null;

    [SerializeField]
    private DefenceTower defenceTower = null;
    public Target GetTarget()
    {
        return target;
    }
    public void SpawnTarget()
    {

    }
    private Vector3 GetRandomPostiion(float _range)
    {
        return new Vector3(0f, 0f, 0f);
    }
} // end of class
