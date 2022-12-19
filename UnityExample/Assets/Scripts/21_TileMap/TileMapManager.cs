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

        // ������ �̵�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            curIdx = character.GetCurIndex();
            curIdx.x += 1;
            // ���� �ִ� ������ üũ
            if (mapBuilder.CheckCanMove(curIdx))
            {
                // 'character index ����ü ����(TileIdx)' update
                character.MoveRight();
                // ���� index�� ������� '���� character position' Update
                UpdateCharPos();
            }
        }

        // ���� �̵�
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

        // ���� �̵�
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

        // �Ʒ��� �̵�
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
