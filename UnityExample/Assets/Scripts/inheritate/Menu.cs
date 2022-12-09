using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Menu가 player랑 연동되는게 아니라
// RentShop이 Menu랑 Player연결해 준다.
public class Menu : MonoBehaviour
{
    // enum 젤 끝에 Len 넣으면, Len인덱스로 요소의 갯수를 알아낼 수 있다.
    public enum EType { Car, Boat, Bike, Len };
    public delegate void OnClickWithType(EType _type);
    private Button[] btns = null;
    private void Awake()
    {
        btns = GetComponentsInChildren<Button>();
    }

    // 각 버튼에 맞는 콜백함수를 버튼 이벤트 리스너에 '달아주고' '호출해주는'함수
    // 리스너에 콜백함수 달아줌.
    // 이벤트 발생하면 RentShop에 있는 해당 콜백함수 호출
    // delegate함수는 RentShop에 있음
    public void SetOnClickCallback(EType _type, OnClickWithType _callback)
    {
        btns[(int)_type].onClick.AddListener(
            () =>
            {
                _callback?.Invoke(_type);
            });
    }
}
