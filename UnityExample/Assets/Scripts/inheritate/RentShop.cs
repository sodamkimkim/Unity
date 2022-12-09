using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentShop : MonoBehaviour
{
    // RentShop�� Menu�� Player�� �ȴ�.
    // Menu�� Player�� ���θ� ���� ���Ѵ�.
    public Menu menu = null;
    public Player222 player = null;

    private void Start()
    {
        for (int i = 0; i < (int)Menu.EType.Len; ++i)
            menu.SetOnClickCallback((Menu.EType)i, OnClickCallback);
    }

    // RentShop�� Start()���� menu��ư�� �̺�Ʈ �����ʿ� �ݹ��Լ� �޾� �� ��, 
    // Menu�� ��ư�� �������� ȣ��Ǵ� �Լ�.
    public void OnClickCallback(Menu.EType _type)
    {
        Debug.Log("Ride to " + _type.ToString());
        player.RideTo(VehicleFactory(_type));
    }

    // # factory pattern
    // type�� �޾Ƽ� �ش� ��ü�� �����������ִ� �Լ�.
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
