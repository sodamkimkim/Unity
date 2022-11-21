using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuButtonHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBtnPrefab = null;
    private readonly float hOffset = 80f;
    private readonly float vOffset = 80f;

    [SerializeField]
    private int btnTotalCnt = 10;
    [SerializeField]
    private int btnColCnt = 4;

    private void Update()
    {
        // �츮�� ���� ������ǥ�� �ƴ϶� �θ���� �����ġ�̱� ������ ���ݸ� ����ϸ�ȴ�. ������ġ��� �θ���ġ  + ��ȭ�� ����� �ϴ� ����
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (btnTotalCnt <= 0) btnTotalCnt = 1;
            if (btnColCnt <= 0) btnColCnt = 1;
            Vector3 startPos = new Vector3(-((hOffset * (btnColCnt - 1)) * 0.5f), vOffset * 0.5f, 0f);
            for (int i = 0; i < btnTotalCnt; ++i)
            {
                Vector3 pos = startPos + new Vector3(hOffset * (i % btnColCnt), -vOffset * (i / btnColCnt), 0f);
                CreateMenuButton("�׽�Ʈ", 1000, 5, pos);
            }
        }
    }

    public void CreateMenuButton(
        string _name, int _price, int _stock, Vector3 _pos)
    {
        // ����ó��
        if (menuBtnPrefab == null) { Debug.Log("menuBtnPrefab�� �־��ּ���"); return; }

        GameObject go = Instantiate(menuBtnPrefab);
        //�θ� �� Ʈ�������� �־ canvas�Ʒ��� ui�� ���Բ� �� ��� �Ѵ�.
        // go.transform.parent = transform;
        go.transform.SetParent(transform);
        // ��������� ��ư�� �θ� �������� �����ǥ�� �����������
        go.GetComponent<RectTransform>().localPosition = _pos;

        go.GetComponent<UIMenuButton>().UpdateInfo(_name, _price, _stock);
    }
}
