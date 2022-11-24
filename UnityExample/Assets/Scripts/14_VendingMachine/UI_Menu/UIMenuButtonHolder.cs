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

        // ���� ���� ���ϱ�
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

        // �޴� ��ư �����ϱ� �� destroy()
        DestroyButtons();

        // �������� ��ư ����
        for (int i = 0; i < btnTotalCnt; i++)
        {
            GameObject btnGo = Instantiate(menuBtnPrefab);
            // ������ btnGo�� UIMenuButtonHolder�Ʒ��� �־��ִ� �ڵ夡
            btnGo.transform.SetParent(transform);
            // ������ ��ư������ Script�� UIMenuButton�� �ҷ��ͼ� ��ġ�� ������ ����
            UIMenuButton btn = btnGo.GetComponent<UIMenuButton>();
            // SetLocalPosition�� z�� = 0f�� default �� ������ �־ �ȳ־ �ȴ�.
            btn.SetLocalPosition(
                startPosX + (horizontalOffset * (i % btnColCnt)),
                startPosY - (verticalOffset * (i / btnColCnt))
                );
            btn.SetSize(btnWidth, btnHeight);
            // i������� ��ư ������ ��, i�� �ٸ� Ŭ�������� btnIdx�� Ȱ��ǰ� �ȴ�.
            btn.Init(i, _btnInfos[i], _onClickCallback);

            // ����Ʈ�� ���� ������Ʈ �߰�
            btnList.Add(btnGo);
        }

    }
    private void DestroyButtons()
    {
        if (btnList == null) return;
        foreach (GameObject btnGo in btnList)
            Destroy(btnGo); // node���� GameObject ����
        btnList.Clear(); // node �޸� ����
    }
} // end of class
