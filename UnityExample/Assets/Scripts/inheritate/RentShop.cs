using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentShop : MonoBehaviour
{
    // RentShop은 Menu와 Player를 안다.
    // Menu와 Player는 서로를 알지 못한다.
    public Menu menu = null;
    public Player222 player = null;

    private void Start()
    {
        for (int i = 0; i < (int)Menu.EType.Len; ++i)
            menu.SetOnClickCallback((Menu.EType)i, OnClickCallback);
    }

    // RentShop의 Start()에서 menu버튼의 이벤트 리스너에 콜백함수 달아 준 후, 
    // Menu의 버튼이 눌러지면 호출되는 함수.
    public void OnClickCallback(Menu.EType _type)
    {
        Debug.Log("Ride to " + _type.ToString());
        player.RideTo(VehicleFactory(_type));
    }

    // # factory pattern
    // type을 받아서 해당 객체를 동적생성해주는 함수.
    private Vehicle VehicleFactory(Menu.EType _type)
    {
        switch (_type)
        {
            case Menu.EType.Car:
                return new Car();
            case Menu.EType.Boat:
                return new Boat();
            case Menu.EType.Bike:
                return new Bike();
        }
        return null;
    }

} // end of class
