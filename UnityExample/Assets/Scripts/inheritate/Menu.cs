using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Menu�� player�� �����Ǵ°� �ƴ϶�
// RentShop�� Menu�� Player������ �ش�.
public class Menu : MonoBehaviour
{
    // enum �� ���� Len ������, Len�ε����� ����� ������ �˾Ƴ� �� �ִ�.
    public enum EType { Car, Boat, Bike, Len };
    public delegate void OnClickWithType(EType _type);
    private Button[] btns = null;
    private void Awake()
    {
        btns = GetComponentsInChildren<Button>();
    }

    // �� ��ư�� �´� �ݹ��Լ��� ��ư �̺�Ʈ �����ʿ� '�޾��ְ�' 'ȣ�����ִ�'�Լ�
    // �����ʿ� �ݹ��Լ� �޾���.
    // �̺�Ʈ �߻��ϸ� RentShop�� �ִ� �ش� �ݹ��Լ� ȣ��
    // delegate�Լ��� RentShop�� ����
    public void SetOnClickCallback(EType _type, OnClickWithType _callback)
    {
        btns[(int)_type].onClick.AddListener(
            () =>
            {
                _callback?.Invoke(_type);
            });
    }
}
