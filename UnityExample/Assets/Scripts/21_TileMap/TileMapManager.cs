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
        // 오른쪽 이동
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
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
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.x -= 1;
            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveLeft();
                UpdateCharPos();
            }
        }

        // 위로 이동
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

        // 아래로 이동
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
     * 요약) 맵에 캐릭터 실제 위치 조정, 연동해주는 함수
     Update()에서 키 입력 마다 Character에서 Move함수를 호출한다.
    Move함수에서 tileIdx의 변화가 일어나고, 
    그 tileIdx를 받아와서 tile의 실제 position을 구한다음
    그 위치로 Character를 이동한다.
    ㄴ TileMapManager가 Character와 TileMapBuilder를 들고와서 그려주는 클래스 이기 때문에
    이 곳에서 두 객체의 정보를 필요에 따라 수정 혹은 받아와서
    두 객체를 연동해 주는 것이다.
     */
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx);
        character.SetPosition(tilePos);

    }
} // end of class TileMapManager
