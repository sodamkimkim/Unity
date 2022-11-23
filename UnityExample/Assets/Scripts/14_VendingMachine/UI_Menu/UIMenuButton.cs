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
    private RectTransform rtr = null;
    private void Awake()
    {
        info = GetComponentInChildren<TextMeshProUGUI>();
        rtr = GetComponent<RectTransform>();
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
    public void UpdateInfo(VendingMachine.SButton _btnInfo)
    {
        UpdateInfo(TypeToName(_btnInfo.type), _btnInfo.price, _btnInfo.cnt);
    }

    private string TypeToName(VendingMachine.EBeverageType _type)
    {
        switch (_type)
        {
            case VendingMachine.EBeverageType.Cider:
                return "사이다";
            case VendingMachine.EBeverageType.Coke:
                return "콜라";
            case VendingMachine.EBeverageType.StrawberryMilk:
                return "딸기우유";
        }
        return "모름";
    }
    public void SetSize(Vector2 _size)
    {
        rtr.sizeDelta = _size;
    }
    public void SetSize(float _width, float _height)
    {
        //rtr.sizeDelta = new Vector2(_width, _height);
        SetSize(new Vector2(_width, _height));
    }
    public void SetLocalPosition(Vector3 _localPos)
    {
        rtr.localPosition = _localPos;
    }
    public void SetLocalPosition(float _x, float _y, float _z = 0f)
    {
        SetLocalPosition(new Vector3(_x, _y, _z));
    }
}
