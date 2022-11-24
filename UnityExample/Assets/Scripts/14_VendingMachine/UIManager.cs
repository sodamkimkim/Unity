using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIMenuManager menuMng = null; // canvas�� �޸� menu
    private void Start()
    {
        HideMenu();       
    }
    public void ShowMenu(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        // 1. �޴��� �ʱ�ȭ�ϰ� ( ��� �׳� VendingMachine���� ���� ���� �� �״�� UIMenuManager���� �����Ѵ�. ���� �߰� ����)
        menuMng.Init(_btnInfos, _onClickCallback, _btnColCnt);

        // 2. �޴��� �����ֱ�
        menuMng.gameObject.SetActive(true);
    }
    public void HideMenu()
    {
        menuMng.gameObject.SetActive(false);
    }
} // end of class
