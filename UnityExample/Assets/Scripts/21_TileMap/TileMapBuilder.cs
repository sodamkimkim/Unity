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

    // # C#에서 이중배열 선언하는 2가지 방식
    //private int [ ] [ ] 
    private int[,] mapInfo =
     {
        // 타일 배치 info
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

                // SetSprite하기 위해서 tileGo의 Tile을 들고옴
                Tile tile = tileGo.GetComponent<Tile>();
                // mapInfo에 알맞는 tileImg를 찾아서 sprite에 던져줌
                tile.SetSprite(tileImgs[mapInfo[r, c]]);
                // list에 추가. list 순서는 2차원 배열인 mapInfo순서랑 같아야 한다.
                tileList.Add(tile);
            }
        }
    } // end of Building()

    /*
     character의 tileIdx를 받아서 
    return tile의 position; 
    => TileMapManager에서 이 함수를 이용해서 character가 tileIdx의 tile에 해당하는 위치로 가게된다.
     */
    public Vector3 GetPosWithIdx(
        Character.TileIdx _tileIdx)
    {
        // tileList에는 이중 배열 정보가 1차원으로 저장되어있다.
        // 따라서 list의 index를 (_tileIdx.y * colCnt) + _tileIdx.x로 계산해 준다.
        Tile tile = tileList[(_tileIdx.y * colCnt) + _tileIdx.x];
        // 타일의 실제 position정보
        return tile.GetPosition();
    }
    // Player가 이동할 수 있는 Map인지 확인하는 함수
    public bool CheckCanMove(Character.TileIdx _tileIdx)
    {
        // 맵 범위 벗어나면 못간다.
        if (_tileIdx.x < 0 || _tileIdx.x > colCnt - 1)
            return false;
        if (_tileIdx.y < 0 || _tileIdx.y > rowCnt - 1)
            return false;
        // tille의 인덱스 들고와서 Sea or Stone이면 못들어간다.
        int tileInfo = mapInfo[_tileIdx.y, _tileIdx.x];
        if (tileInfo == (int)EType.Sea || tileInfo == (int)EType.Stone)
            return false;

        return true;
    }
} // end of class TileMapBuilder
