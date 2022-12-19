using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private TileMapBuilder mapBuilder = null;
    [SerializeField]
    private Character character = null;

    private void Start()
    {
        mapBuilder.Building();
        UpdateCharPos();
    }
    private void Update()
    {
        Character.TileIdx curIdx = character.GetCurIndex();

        // 오른쪽 이동
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            curIdx = character.GetCurIndex();
            curIdx.x += 1;
            // 갈수 있는 맵인지 체크
            if (mapBuilder.CheckCanMove(curIdx))
            {
                // 'character index 구조체 정보(TileIdx)' update
                character.MoveRight();
                // 위의 index를 기반으로 '실제 character position' Update
                UpdateCharPos();
            }
        }

        // 왼쪽 이동
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            curIdx = character.GetCurIndex();
            curIdx.x -= 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveLeft();
                UpdateCharPos();
            }
        }

        // 위로 이동
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            curIdx = character.GetCurIndex();
            curIdx.y -= 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveUp();
                UpdateCharPos();
            }
        }

        // 아래로 이동
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            curIdx = character.GetCurIndex();
            curIdx.y += 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveDown();
                UpdateCharPos();
            }
        }
    }
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx);
        character.SetPosition(tilePos);

    }
} // end of class TileMapManager
