using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character 랑 TileMapBuilder랑 연동해주는 클래스
public class pr_TileMapManager : MonoBehaviour
{
    [SerializeField]
    private TileMapBuilder mapBuilder = null;
    [SerializeField]
    private Character character = null;

    /*
     1. 맵 생성
     2. Character 초기위치 지정 
     */
    private void Start()
    {
        // 맵 생성
        mapBuilder.Building();

        // private TileIdx tileIdx = new TileIdx(0, 0);
        // character의 초기 인덱스 정보를 가지고 tile의 index랑 맵핑해서 tile의 position으로 character를 옮겨 줌
        UpdateCharPos();
    }

    /*
     : 키 이벤트 감지해주는 코드 작성
    1. 캐릭터의 현재 위치 tileIdx받아와서
    2. 그 값에 ++ / -- 해준 인덱스를 계산해 보고
    3. 그 인덱스에 해당하는 tile에 move가능한지 체크하고 가능하면
    4. 실제로 character의 tileIdx를 업데이트 해주고
    5. character를 그 타일 위치로(position)이동
     */
    private void Update()
    {
         // 우측 이동
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
        // 좌측 이동
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
        // 위로 이동
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
        // 아래로 이동
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

    // 맵에 캐릭터 실제 위치 조정, 연동해주는 함수
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx);
        character.SetPosition(tilePos);
    }
} // end of class TileMapManager
