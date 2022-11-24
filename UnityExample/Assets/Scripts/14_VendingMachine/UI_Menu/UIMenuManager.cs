using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform backPanelTr = null;
    // 자식의 컴포넌트를 아는 게 있을 때 GetComponentInChildren써서 object찾는데,
    // 편의상 찾을 것 같은 삘일 때 빈 스크립트라도 넣어놓으면 편리.
    private UIMenuButtonHolder btnHolder = null;
    private void Awake()
    {
        btnHolder = GetComponentInChildren<UIMenuButtonHolder>();
    }
    // # 게으른 초기화 Init()
    // 원하는 시점에 초기화 가능.
    // 참고로 콜백함수는 vending --> menubutton까지 가야하므로 계속 초기화 함수에 던져준다.
    // ㄴ 근데 던져줄 때 함수 타입이란 것은 없기 때문에 delegate로 지정해서 쓴다.(UIMenuButton에서 delegate 명명함)
    public void Init(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        btnHolder.BuildButtons(_btnInfos, _onClickCallback, _btnColCnt, backPanelTr.sizeDelta);
    }

}
