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
    public List<List<Flag>> pathList =
            new List<List<Flag>>();

    private void Awake()
    {
        flags = GetComponentsInChildren<Flag>();
    }

    private void Start()
    {
        startFlag.SetScale(2f);
        endFlag.SetScale(2f);
    }

    public void Searching()
    {
        //List<List<Flag>> pathList =
        //    new List<List<Flag>>();

        List<Flag> visitFlagList = new List<Flag>();

        Flag curFlag = null;

        while (visitFlagList.Count != flags.Length)
        {
            List<Flag> path = new List<Flag>();
            curFlag = startFlag;
            path.Add(curFlag);
            if (visitFlagList.Contains(curFlag) == false)
                visitFlagList.Add(curFlag);

            while (true)
            {
                if (curFlag.IsNextEmpty()) break;

                Flag[] nextFlags = curFlag.GetNextFlags();
                foreach (Flag nextFlag in nextFlags)
                {
                    // 검사용 복사본 생성
                    List<Flag> copyPath = new List<Flag>(path);
                    copyPath.Add(nextFlag);

                    // 이미 방문한 경로이면 패스                    
                    if (ContainPath(pathList, copyPath))
                    {
                        // 이미 방문한 경로라고 하더라도 끝까지 가야하기 때문에 이동
                        curFlag = nextFlag;
                        continue;
                    }

                    curFlag = nextFlag;
                    path.Add(curFlag);
                    if (visitFlagList.Contains(curFlag) == false)
                        visitFlagList.Add(curFlag);
                    break;
                }
            }

            pathList.Add(path);
        }
    }

    private bool ContainPath(
        List<List<Flag>> _pathList,
        List<Flag> _curPath)
    {
        foreach (List<Flag> path in _pathList)
        {
            if (path.Count == _curPath.Count)
            {
                bool isCompare = true;
                for (int i = 0; i < path.Count; ++i)
                {
                    if (path[i] != _curPath[i])
                    {
                        isCompare = false;
                        break;
                    }
                }

                if (isCompare) return true;
            }
        }

        return false;
    }

    public void PrintPathList()
    {
        System.Text.StringBuilder sb =
            new System.Text.StringBuilder();

        foreach(List<Flag> path in pathList)
        {
            sb.Clear();
            foreach (Flag flag in path)
            {
                sb.Append(flag.name);
                sb.Append(" - ");

                // 끝 플래그까지 갔다면 가능한 경로
                if (flag == endFlag)
                    sb.Append("OK!");
            }
            Debug.Log(sb.ToString());
        }
    }
}
