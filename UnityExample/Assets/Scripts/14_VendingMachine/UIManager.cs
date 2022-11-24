using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIMenuManager menuMng = null; // canvas에 달린 menu
    private void Start()
    {
        HideMenu();       
    }
    public void ShowMenu(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        // 1. 메뉴판 초기화하고 ( 얘는 그냥 VendingMachine에서 전달 받은 거 그대로 UIMenuManager에게 전달한다. 정보 추가 없음)
        menuMng.Init(_btnInfos, _onClickCallback, _btnColCnt);

        // 2. 메뉴판 보여주기
        menuMng.gameObject.SetActive(true);
    }
    public void HideMenu()
    {
        menuMng.gameObject.SetActive(false);
    }
} // end of class
