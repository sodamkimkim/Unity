using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuButtonHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBtnPrefab = null;
    private readonly float hOffset = 80f;
    private readonly float vOffset = 80f;

    private int btnTotalCnt = 0;
    private int btnColCnt = 0;

    private List<GameObject> btnList = new List<GameObject>();

    public void BuildButtons(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt, Vector2 _backPanelSize)
    {
        btnTotalCnt = _btnInfos.Length;
        btnColCnt = _btnColCnt;
        if (btnTotalCnt <= 0) btnTotalCnt = 1;
        if (btnColCnt <= 0) btnColCnt = 1;
        if (btnTotalCnt < btnColCnt)
            btnColCnt = btnTotalCnt;

        // 가로 간격 구하기
        float backPanelWidth = _backPanelSize.x;
        float backPanelHeight = _backPanelSize.y;

        float horizontalOffset = backPanelWidth / btnColCnt;
        float horizontalOffsetHalf = horizontalOffset * 0.5f;

        int lineCnt = btnTotalCnt / btnColCnt;
        lineCnt += (btnTotalCnt % btnColCnt) > 0 ? 1 : 0;

        float verticalOffset = backPanelHeight / lineCnt;
        float verticOffsetHalf = verticalOffset * 0.5f;

        float btnWidth = horizontalOffset * 0.9f;
        float btnHeight = verticalOffset * 0.9f;

        float startPosX = (backPanelWidth * 0.5f * -1f) + horizontalOffsetHalf;
        float startPosY = (backPanelHeight * 0.5f) - verticOffsetHalf;

        // 메뉴 버튼 생성하기 전 destroy()
        DestroyButtons();

        // 포문돌려 버튼 생성
        for (int i = 0; i < btnTotalCnt; i++)
        {
            GameObject btnGo = Instantiate(menuBtnPrefab);
            // 생성된 btnGo를 UIMenuButtonHolder아래로 넣어주는 코드ㄱ
            btnGo.transform.SetParent(transform);
            // 생성한 버튼마다의 Script인 UIMenuButton을 불러와서 위치와 사이즈 지정
            UIMenuButton btn = btnGo.GetComponent<UIMenuButton>();
            // SetLocalPosition에 z는 = 0f로 default 값 정해져 있어서 안넣어도 된다.
            btn.SetLocalPosition(
                startPosX + (horizontalOffset * (i % btnColCnt)),
                startPosY - (verticalOffset * (i / btnColCnt))
                );
            btn.SetSize(btnWidth, btnHeight);
            // i순서대로 버튼 생성할 때, i가 다른 클래스에서 btnIdx로 활용되게 된다.
            btn.Init(i, _btnInfos[i], _onClickCallback);

            // 리스트에 게임 오브젝트 추가
            btnList.Add(btnGo);
        }

    }
    private void DestroyButtons()
    {
        if (btnList == null) return;
        foreach (GameObject btnGo in btnList)
            Destroy(btnGo); // node내부 GameObject 정리
        btnList.Clear(); // node 메모리 정리
    }
} // end of class
