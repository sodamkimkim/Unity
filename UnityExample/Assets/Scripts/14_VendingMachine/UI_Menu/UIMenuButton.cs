using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class UIMenuButton : MonoBehaviour
{
    // delegate�� �ܺ������ؾ��ؼ� public 
    public delegate bool OnClickDelegate(int _btnIdx, out VendingMachine.SButton _btnInfo);
    // OnClickDelegate�Լ� Ÿ�� ���� onClickCallback
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
    // ������ �ʱ�ȭ
    public void Init(int _btnIdx, VendingMachine.SButton _btnInfo, OnClickDelegate _onClickCallback)
    {
        btnIdx = _btnIdx;
        UpdateInfo(_btnInfo);
        onClickCallback = _onClickCallback; // �ݹ��Լ��� ���� ���� OnClickDelegate onClickCallback (�Լ�Ÿ�� ����)�� VendingMachine���κ��� �Ű������� ���޹��� �ݹ��Լ� ����
        btn.onClick.AddListener(OnClickCallback);
        // �� ��ó�� �Լ��� ������ �ִ��� ���ٽ� ǥ�� ������ ��
        //btn.onClick.AddListener(() =>
        //{
        //    VendingMachine.SButton newBtnInfo = new VendingMachine.SButton();
        //    _onClickCallback?.Invoke(btnIdx, out newBtnInfo);
        //});

    }
    // btn���� ������Ʈ
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
    // btn.onclick�̺�Ʈ �߻��ϸ� �ݹ��Լ� �������ִ� �Լ�
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
                return "���̴�";
            case VendingMachine.EBeverageType.Coke:
                return "�ݶ�";
            case VendingMachine.EBeverageType.StrawberryMilk:
                return "�������";
        }
        return "��";
    }
    // ��ư ������ ���� �޼ҵ�
    public void SetSize(Vector2 _size)
    {
        // ui Button�� transform�� RectTransform
        // size����
        rtr.sizeDelta = _size;
    }
    public void SetSize(float _width, float _height)
    {
        SetSize(new Vector2(_width, _height));
    }
    // ��ư ��ġ ���� �޼ҵ�
    public void SetLocalPosition(Vector3 _localPos)
    {
        rtr.localPosition = _localPos;
    }
    public void SetLocalPosition(float _x, float _y, float _z = 0f)
    {
        SetLocalPosition(new Vector3(_x, _y, _z));
    }
} // end of class
