using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceTower : MonoBehaviour
{
    [SerializeField]
    private Transform bodyTopTr = null;
    [SerializeField]
    private GameObject missilePrefab = null;
    [SerializeField]
    private Transform missileSpawnPointTr = null;

    private Target target = null;
    private float rotSpeed = 5f;
    private float cooltime = 0.5f;
    public void Start()
    {
        StartCoroutine(LaunchMissileCoroutine());
    }
    public Transform GetTransform()
    {
        return transform;
    }
    public void SetTarget(Target _target)
    {
        target = _target;
        LookAtTarget();
    }
    public void LookAtTarget()
    {
        if (target == null) return;
        StopCoroutine("LookAtTargetCoroutine");
        StartCoroutine("LookAtTargetCoroutine");
    }
    private IEnumerator LookAtTargetCoroutine()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Quaternion endRot = Quaternion.LookRotation(dir, Vector3.up);
        while (true)
        {
            Quaternion newRot = Quaternion.Lerp(bodyTopTr.rotation, endRot, Time.deltaTime * rotSpeed);
            bodyTopTr.rotation = newRot;
            if (Quaternion.Angle(bodyTopTr.rotation, endRot) < 1f)
                break;
            yield return null;
        }
        bodyTopTr.rotation = endRot;
    }
    private IEnumerator LaunchMissileCoroutine()
    {
        while (true)
        {
            LaunchMissile();
            yield return null;
        }
    }
    private void LaunchMissile()
    {
        Instantiate(missilePrefab, missileSpawnPointTr.position, missileSpawnPointTr.rotation);
    }
} // end of class
