using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapBuilder : MonoBehaviour
{
    public enum EType {Grass, Road, Sea, Stone};
    [SerializeField]
    private Sprite[] tileImgs = null;
    [SerializeField]
    private GameObject tilePrefab = null;

    private int rowCnt = 5;
    private int colCnt = 5;

    // # C#���� ���߹迭 �����ϴ� 2���� ���
    //private int [ ] [ ] 
    private int[,] mapInfo =
     {
        // Ÿ�� ��ġ info
        // 0 : grass, 1 : road, 2 : Sea, 3 : Stone
           { 1,0,0,2,2 },
           { 1,1,0,2,2 },
           { 0,1,1,0,2 },
           { 3,0,1,1,0 },
           { 3,3,0,1,1 }
    };
    private List<Tile> tileList = new List<Tile>();

    public void Building()
    {
        float tileW = 1f;
        float tileH = 1f;
        float tileWHalf = tileW * 0.5f;
        float tileHHalf = tileH * 0.5f;

        float startPosX = ((colCnt * tileW) * 0.5f * -1f) + tileWHalf;
        float startPosY = ((rowCnt * tileH) * 0.5f) - tileHHalf;

        Vector3 startPos = new Vector3(startPosX, startPosY, 0f);

        for (int r = 0; r < rowCnt; r++)
        {
            for (int c = 0; c < colCnt; c++)
            {
                float rowOffset = r * tileH;
                float colOffset = c * tileW;
                Vector3 tilePos = new Vector3(startPos.x + colOffset, startPos.y - rowOffset, startPos.z);

                GameObject tileGo = Instantiate(tilePrefab, tilePos, Quaternion.identity);
                tileGo.transform.SetParent(transform);

                // SetSprite�ϱ� ���ؼ� tileGo�� Tile�� ����
                Tile tile = tileGo.GetComponent<Tile>();
                // mapInfo�� �˸´� tileImg�� ã�Ƽ� sprite�� ������
                tile.SetSprite(tileImgs[mapInfo[r, c]]);
                // list�� �߰�. list ������ 2���� �迭�� mapInfo������ ���ƾ� �Ѵ�.
                tileList.Add(tile);
            }
        }
    } // end of Building()

    /*
     character�� tileIdx�� �޾Ƽ� 
    return tile�� position; 
    => TileMapManager���� �� �Լ��� �̿��ؼ� character�� tileIdx�� tile�� �ش��ϴ� ��ġ�� ���Եȴ�.
     */
    public Vector3 GetPosWithIdx(
        Character.TileIdx _tileIdx)
    {
        // tileList���� ���� �迭 ������ 1�������� ����Ǿ��ִ�.
        // ���� list�� index�� (_tileIdx.y * colCnt) + _tileIdx.x�� ����� �ش�.
        Tile tile = tileList[(_tileIdx.y * colCnt) + _tileIdx.x];
        // Ÿ���� ���� position����
        return tile.GetPosition();
    }
    // Player�� �̵��� �� �ִ� Map���� Ȯ���ϴ� �Լ�
    public bool CheckCanMove(Character.TileIdx _tileIdx)
    {
        // �� ���� ����� ������.
        if (_tileIdx.x < 0 || _tileIdx.x > colCnt - 1)
            return false;
        if (_tileIdx.y < 0 || _tileIdx.y > rowCnt - 1)
            return false;
        // tille�� �ε��� ���ͼ� Sea or Stone�̸� ������.
        int tileInfo = mapInfo[_tileIdx.y, _tileIdx.x];
        if (tileInfo == (int)EType.Sea || tileInfo == (int)EType.Stone)
            return false;

        return true;
    }
} // end of class TileMapBuilder
