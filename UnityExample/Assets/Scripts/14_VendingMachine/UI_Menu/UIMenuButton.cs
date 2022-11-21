using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

// 1. 버튼 내용 설정
// 2. 버튼을 눌렀을 때 동작 구현
public class UIMenuButton : MonoBehaviour
{
    private TextMeshProUGUI info = null;
    private StringBuilder sb = new StringBuilder();
    private void Awake()
    {
        info = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdateInfo(string _name, int _price, int _stock)
    {
        sb.Clear();

        sb.Append(_name);
        sb.Append("\n"); // 줄바꿈 문자 넣어주던가
        sb.AppendLine(_price.ToString()); // appendline으로 쓰던가
        sb.AppendLine(_stock.ToString());

        info.text = sb.ToString();
    }
}
