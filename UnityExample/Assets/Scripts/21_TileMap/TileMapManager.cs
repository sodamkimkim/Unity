using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
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
        // ������ �̵�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
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
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.x -= 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveLeft();
                UpdateCharPos();
            }
        }

        // ���� �̵�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.y -= 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveUp();
                UpdateCharPos();
            }
        }

        // �Ʒ��� �̵�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.y += 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveDown();
                UpdateCharPos();
            }
        }
    }

    /*
     * ���) �ʿ� ĳ���� ���� ��ġ ����, �������ִ� �Լ�
     Update()���� Ű �Է� ���� Character���� Move�Լ��� ȣ���Ѵ�.
    Move�Լ����� tileIdx�� ��ȭ�� �Ͼ��, 
    �� tileIdx�� �޾ƿͼ� tile�� ���� position�� ���Ѵ���
    �� ��ġ�� Character�� �̵��Ѵ�.
    �� TileMapManager�� Character�� TileMapBuilder�� ���ͼ� �׷��ִ� Ŭ���� �̱� ������
    �� ������ �� ��ü�� ������ �ʿ信 ���� ���� Ȥ�� �޾ƿͼ�
    �� ��ü�� ������ �ִ� ���̴�.
     */
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx);
        character.SetPosition(tilePos);

    }
} // end of class TileMapManager
