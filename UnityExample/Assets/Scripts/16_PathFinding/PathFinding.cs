using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField]
    private Flag startFlag = null;
    [SerializeField]
    private Flag endFlag = null;

    private Flag[] flags = null;

    // 결과 확인용
    public List<List<Flag>> pathList = new List<List<Flag>>();

    private void Awake()
    {
        flags = GetComponentsInChildren<Flag>();
    }
    private void Start()
    {
        
    }
    public void Searching()
    {

    }
    private void SearchingRecursive(List<Flag> _path, Flag _curFlag)
    {

    }

    public void PrintPathList()
    {

    }

} // end of class
