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

    // ��� Ȯ�ο�
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

    //public void Searching()
    //{
    //    //List<List<Flag>> pathList = new List<List<Flag>>();

    //    List<Flag> visitFlagList = new List<Flag>();

    //    Flag curFlag = null;

    //    while (visitFlagList.Count != flags.Length)
    //    {
    //        List<Flag> path = new List<Flag>();
    //        curFlag = startFlag;
    //        path.Add(curFlag);
    //        if (visitFlagList.Contains(curFlag) == false)
    //            visitFlagList.Add(curFlag);

    //        while (true)
    //        {
    //            if (curFlag == endFlag || curFlag.IsNextEmpty()) break;

    //            Flag[] nextFlags = curFlag.GetNextFlags();
    //            //foreach (Flag nextFlag in nextFlags)
    //            for (int i = 0; i < nextFlags.Length; ++i)
    //            {
    //                // �˻�� ���纻 ����
    //                List<Flag> copyPath = new List<Flag>(path);
    //                copyPath.Add(nextFlags[i]);

    //                // �̹� �湮�� ����̸� �н�
    //                if (ContainPath(pathList, copyPath))
    //                {
    //                    // �̹� �湮�� ��ζ�� �ϴ��� ������ �����ϱ� ������ �̵�
    //                    curFlag = nextFlags[i];
    //                    continue;
    //                }

    //                curFlag = nextFlags[i];
    //                path.Add(curFlag);
    //                if (visitFlagList.Contains(curFlag) == false)
    //                    visitFlagList.Add(curFlag);
    //                break;
    //            }
    //        }

    //        pathList.Add(path);
    //    }

    //    // endFlag���� �� �� �ִ� ��θ� �����
    //    for (int i = 0; i < pathList.Count; ++i)
    //    {
    //        if (!pathList[i].Contains(endFlag))
    //        {
    //            pathList.RemoveAt(i);
    //            --i;
    //        }
    //    }
    //}

    public void Searching()
    {
        List<Flag> path = new List<Flag>();
        SearchingRecursive(path, startFlag);

        // endFlag���� �� �� �ִ� ��θ� �����
        for (int i = 0; i < pathList.Count; ++i)
        {
            if (!pathList[i].Contains(endFlag))
            {
                pathList.RemoveAt(i);
                --i;
            }
        }
    }

    private void SearchingRecursive(List<Flag> _path, Flag _curFlag)
    {
        _path.Add(_curFlag);
        
        if (_curFlag == endFlag || _curFlag.IsNextEmpty())
        {
            List<Flag> tmp = new List<Flag>(_path);
            pathList.Add(tmp);
            return;
        }

        foreach (Flag nextFlag in _curFlag.GetNextFlags())
        {
            SearchingRecursive(_path, nextFlag);
            _path.RemoveAt(_path.Count - 1);
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

                // �� �÷��ױ��� ���ٸ� ������ ���
                if (flag == endFlag)
                    sb.Append("OK!");
            }
            Debug.Log(sb.ToString());
        }
    }

    public Flag[] GetShortPath()
    {
        float[] distList = new float[pathList.Count];
        for (int i = 0; i < pathList.Count; ++i)
        {
            List<Flag> path = pathList[i];
            float elapsedDist = 0f;
            for (int j = 0; j < path.Count - 1; ++j)
            {
                Vector3 firstPos = path[j].GetPosition();
                Vector3 secondPos = path[j + 1].GetPosition();
                elapsedDist +=
                    Vector3.Distance(firstPos, secondPos);
            }

            distList[i] = elapsedDist;
            //Debug.Log("distLize[" + i + "]: " + distList[i]);
        }

        // �ּڰ� ã��
        int minIdx = 0;
        for (int i = 1; i < distList.Length; ++i)
        {
            if (distList[i] < distList[minIdx])
                minIdx = i;
        }

        return pathList[minIdx].ToArray();
    }
}
