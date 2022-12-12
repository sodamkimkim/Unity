using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2. 적 생성
// - 가로 11개, 세로 5개, 
 //- 좌측 하단부터 시작
 // - 생성 시퀀스
 // 3. 적 이동
  //- 한 프레임에 한 개씩 이동
  // 화면의 좌우 끝에 도달하면 아래로 이동.
  // 타워 위치까지 내려오면 게임 오버 
  // 적 수가 줄어들면 속도 증가
public class InvadersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject invaderPrefab = null;
    private void SpawnInvader(Vector3 _pos)
    {
        GameObject go = Instantiate(invaderPrefab, _pos, Quaternion.identity);
    }
}
