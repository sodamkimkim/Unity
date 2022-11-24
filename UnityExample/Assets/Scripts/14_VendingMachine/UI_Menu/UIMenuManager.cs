using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform backPanelTr = null;
    // �ڽ��� ������Ʈ�� �ƴ� �� ���� �� GetComponentInChildren�Ἥ objectã�µ�,
    // ���ǻ� ã�� �� ���� ���� �� �� ��ũ��Ʈ�� �־������ ��.
    private UIMenuButtonHolder btnHolder = null;
    private void Awake()
    {
        btnHolder = GetComponentInChildren<UIMenuButtonHolder>();
    }
    // # ������ �ʱ�ȭ Init()
    // ���ϴ� ������ �ʱ�ȭ ����.
    // ����� �ݹ��Լ��� vending --> menubutton���� �����ϹǷ� ��� �ʱ�ȭ �Լ��� �����ش�.
    // �� �ٵ� ������ �� �Լ� Ÿ���̶� ���� ���� ������ delegate�� �����ؼ� ����.(UIMenuButton���� delegate �����)
    public void Init(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        btnHolder.BuildButtons(_btnInfos, _onClickCallback, _btnColCnt, backPanelTr.sizeDelta);
    }

}
