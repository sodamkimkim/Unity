using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindManager : MonoBehaviour
{
    [SerializeField]
    private PathFinding pathFinding = null;
    [SerializeField]
    private PathFinder pathFinder = null;

    private void Start()
    {
        pathFinding.Searching();
        pathFinding.PrintPathList();
    }
} // end of class
