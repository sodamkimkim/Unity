using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    private NavMeshAgent agent = null;

    private Flag[] pathFlags = null;
    private int curIdx = 0;
    private bool isMoving = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetPathFlags(Flag[] _pathFlags)
    {
        if (isMoving) return;
        
        pathFlags = _pathFlags;
        StartCoroutine(MovingCoroutine());
    }

    private IEnumerator MovingCoroutine()
    {
        isMoving = true;

        while (curIdx != pathFlags.Length)
        {
            agent.SetDestination(
                pathFlags[curIdx].GetPosition());

            while (true)
            {
                float dist = Vector3.Distance(
                    transform.position,
                    pathFlags[curIdx].GetPosition());
                if (dist < 0.1f) break;

                yield return null;
            }

            ++curIdx;
            yield return new WaitForSeconds(0.5f);
        }

        isMoving = false;
    }
}
