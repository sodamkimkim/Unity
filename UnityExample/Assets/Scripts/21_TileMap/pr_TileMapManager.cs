using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character �� TileMapBuilder�� �������ִ� Ŭ����
public class pr_TileMapManager : MonoBehaviour
{
    [SerializeField]
    private TileMapBuilder mapBuilder = null;
    [SerializeField]
    private Character character = null;

    /*
     1. �� ����
     2. Character �ʱ���ġ ���� 
     */
    private void Start()
    {
        // �� ����
        mapBuilder.Building();

        // private TileIdx tileIdx = new TileIdx(0, 0);
        // character�� �ʱ� �ε��� ������ ������ tile�� index�� �����ؼ� tile�� position���� character�� �Ű� ��
        UpdateCharPos();
    }

    /*
     : Ű �̺�Ʈ �������ִ� �ڵ� �ۼ�
    1. ĳ������ ���� ��ġ tileIdx�޾ƿͼ�
    2. �� ���� ++ / -- ���� �ε����� ����� ����
    3. �� �ε����� �ش��ϴ� tile�� move�������� üũ�ϰ� �����ϸ�
    4. ������ character�� tileIdx�� ������Ʈ ���ְ�
    5. character�� �� Ÿ�� ��ġ��(position)�̵�
     */
    private void Update()
    {
         // ���� �̵�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            ++curIdx.x;
            if(mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveRight();
                UpdateCharPos();
            }
        }
        // ���� �̵�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            --curIdx.x;
            if(mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveLeft();
                UpdateCharPos();
            }
        }
        // ���� �̵�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            --curIdx.y;
            if(mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveUp();
                UpdateCharPos();
            }
        }
        // �Ʒ��� �̵�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            ++curIdx.y;
            if(mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveDown();
                UpdateCharPos();
            }
        }

    }

    // �ʿ� ĳ���� ���� ��ġ ����, �������ִ� �Լ�
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx);
        character.SetPosition(tilePos);
    }
} // end of class TileMapManager
