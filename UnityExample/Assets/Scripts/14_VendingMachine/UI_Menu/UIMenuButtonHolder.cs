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
        // 우리는 지금 월드좌표가 아니라 부모기준 상대위치이기 때문에 간격만 계산하면된다. 월드위치라면 부모위치  + 변화량 해줘야 하는 거임
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (btnTotalCnt <= 0) btnTotalCnt = 1;
            if (btnColCnt <= 0) btnColCnt = 1;
            Vector3 startPos = new Vector3(-((hOffset * (btnColCnt - 1)) * 0.5f), vOffset * 0.5f, 0f);
            for (int i = 0; i < btnTotalCnt; ++i)
            {
                Vector3 pos = startPos + new Vector3(hOffset * (i % btnColCnt), -vOffset * (i / btnColCnt), 0f);
                CreateMenuButton("테스트", 1000, 5, pos);
            }
        }
    }

    public void CreateMenuButton(
        string _name, int _price, int _stock, Vector3 _pos)
    {
        // 예외처리
        if (menuBtnPrefab == null) { Debug.Log("menuBtnPrefab을 넣어주세요"); return; }

        GameObject go = Instantiate(menuBtnPrefab);
        //부모가 될 트렌스폼을 넣어서 canvas아래에 ui가 들어가게끔 해 줘야 한다.
        // go.transform.parent = transform;
        go.transform.SetParent(transform);
        // 만들어지는 버튼은 부모를 기준으로 상대좌표로 지정해줘야함
        go.GetComponent<RectTransform>().localPosition = _pos;

        go.GetComponent<UIMenuButton>().UpdateInfo(_name, _price, _stock);
    }
}
