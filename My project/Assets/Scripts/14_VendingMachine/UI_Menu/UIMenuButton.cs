using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

// 1. 버튼 내용 설정
// 2. 버튼을 눌렀을 때 동작
public class UIMenuButton : MonoBehaviour
{
    public delegate bool OnClickDelegate(
        int _btnIdx, out VendingMachine.SButton _btnInfo);
    private OnClickDelegate onClickCallback = null;

    private TextMeshProUGUI info = null;
    private StringBuilder sb = new StringBuilder();
    private RectTransform rtr = null;

    private Button btn = null;
    private int btnIdx = -1;

    private void Awake()
    {
        info =
            GetComponentInChildren<TextMeshProUGUI>();
        rtr = GetComponent<RectTransform>();

        btn = GetComponent<Button>();
    }

    // Initialization
    public void Init(
        int _btnIdx,
        VendingMachine.SButton _btnInfo,
        OnClickDelegate _onClickCallback)
    {
        btnIdx = _btnIdx;
        UpdateInfo(_btnInfo);
        onClickCallback = _onClickCallback;
        btn.onClick.AddListener(OnClickCallback);

        // 람다식(Lambda Expression)
        //btn.onClick.AddListener(
        //    () =>
        //    {
        //        _onClickCallback?.Invoke();
        //    }
        //);
    }

    public void UpdateInfo(
        VendingMachine.EBeverageType _type,
        int _price,
        int _stock)
    {
        //VendingMachine.SButton tmpBtnInfo =
        //    new VendingMachine.SButton();
        //tmpBtnInfo.type = _type;
        //tmpBtnInfo.price = _price;
        //tmpBtnInfo.stock = _stock;

        UpdateInfo(
            //tmpBtnInfo,
            new VendingMachine.SButton(
                _type, _price, _stock));
    }

    public void OnClickCallback()
    {
        VendingMachine.SButton newBtnInfo =
            new VendingMachine.SButton();
        if ((bool)onClickCallback?.Invoke(btnIdx, out newBtnInfo))
        {
            UpdateInfo(newBtnInfo);
        }
    }

    public void UpdateInfo(
        VendingMachine.SButton _btnInfo)
    {
        sb.Clear();

        sb.Append(TypeToName(_btnInfo.type));
        sb.Append("\n");
        sb.AppendLine(_btnInfo.price.ToString());
        sb.AppendLine(_btnInfo.stock.ToString());

        info.text = sb.ToString();
    }

    private string TypeToName(
        VendingMachine.EBeverageType _type)
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

        return "몰라";
    }

    public void SetSize(Vector2 _size)
    {
        rtr.sizeDelta = _size;
    }

    public void SetSize(
        float _width, float _height)
    {
        //rtr.sizeDelta =
        //    new Vector2(_width, _height);
        SetSize(new Vector2(_width, _height));
    }

    public void SetLocalPosition(Vector3 _localPos)
    {
        rtr.localPosition = _localPos;
    }

    public void SetLocalPosition(
        float _x, float _y, float _z = 0f)
    {
        SetLocalPosition(new Vector3(_x, _y, _z));
    }
}
