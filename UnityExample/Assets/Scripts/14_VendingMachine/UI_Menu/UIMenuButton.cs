using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class UIMenuButton : MonoBehaviour
{
    // delegate는 외부접근해야해서 public 
    public delegate bool OnClickDelegate(int _btnIdx, out VendingMachine.SButton _btnInfo);
    // OnClickDelegate함수 타입 변수 onClickCallback
    private OnClickDelegate onClickCallback = null;
    private TextMeshProUGUI info = null;
    private StringBuilder sb = new StringBuilder();
    private RectTransform rtr = null;
    private Button btn = null;
    private int btnIdx = -1;

    private void Awake()
    {
        info = GetComponentInChildren<TextMeshProUGUI>();
        rtr = GetComponent<RectTransform>();
        btn = GetComponent<Button>();
    }
    // 게으른 초기화
    public void Init(int _btnIdx, VendingMachine.SButton _btnInfo, OnClickDelegate _onClickCallback)
    {
        btnIdx = _btnIdx;
        UpdateInfo(_btnInfo);
        onClickCallback = _onClickCallback; // 콜백함수를 위해 만든 OnClickDelegate onClickCallback (함수타입 변수)에 VendingMachine으로부터 매개변수로 전달받은 콜백함수 연결
        btn.onClick.AddListener(OnClickCallback);
        // ㄴ 위처럼 함수로 연결해 주던가 람다식 표현 쓰던가 ㄱ
        //btn.onClick.AddListener(() =>
        //{
        //    VendingMachine.SButton newBtnInfo = new VendingMachine.SButton();
        //    _onClickCallback?.Invoke(btnIdx, out newBtnInfo);
        //});

    }
    // btn정보 업데이트
    public void UpdateInfo(VendingMachine.EBeverageType _type, int _price, int _stock)
    {
        UpdateInfo(new VendingMachine.SButton(_type, _price, _stock));
    }
    public void UpdateInfo(VendingMachine.SButton _btnInfo)
    {
        sb.Clear();
        sb.Append(TypeToName(_btnInfo.type));
        sb.Append("\n");
        sb.AppendLine(_btnInfo.price.ToString());
        sb.AppendLine(_btnInfo.stock.ToString());
        info.text = sb.ToString();
    }
    // btn.onclick이벤트 발생하면 콜백함수 실행해주는 함수
    public void OnClickCallback()
    {
        VendingMachine.SButton newBtnInfo = new VendingMachine.SButton();
        if ((bool)onClickCallback?.Invoke(btnIdx, out newBtnInfo))
        {
            UpdateInfo(newBtnInfo);
        }
    }
    // EBeverage _type -> name
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
    // 버튼 사이즈 지정 메소드
    public void SetSize(Vector2 _size)
    {
        // ui Button의 transform은 RectTransform
        // size변경
        rtr.sizeDelta = _size;
    }
    public void SetSize(float _width, float _height)
    {
        SetSize(new Vector2(_width, _height));
    }
    // 버튼 위치 지정 메소드
    public void SetLocalPosition(Vector3 _localPos)
    {
        rtr.localPosition = _localPos;
    }
    public void SetLocalPosition(float _x, float _y, float _z = 0f)
    {
        SetLocalPosition(new Vector3(_x, _y, _z));
    }
} // end of class
