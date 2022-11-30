using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OOP(Object-Oriented Programming)
// CLR(Common Language Runtime)
// 캡슐화(Encapsulation)
// Smart Pointer - Reference Counter
// Garbage Collection
public class Cat
{
    // 멤버 접근범위 지정자(Member Access Modifier)
    string name;    // Default: private
    private int age;
    private float weight = 0f;

    // 생성자(Constructor)
    //public Cat()
    //{
    //    Debug.Log("Cat Constructor");
    //    name = "Unknown";
    //    age = 1;
    //    weight = 1;
    //    // 동적할당
    //}

    public Cat(string _name, int _age, float _weight)
    {
        Debug.Log("Overloading Constructor");
        name = _name;
        age = _age;
        weight = _weight;
    }

    // 소멸자(Destructor)
    ~Cat()
    {
        Debug.Log("Cat Destructor");
        // 동적할당 해제
    }

    // Property
    public float Weight {
        get { return weight; }
        set { weight = value; }
    }

    // Getter / Setter
    public string GetName()
    {
        return name;
    }

    public void SetName(string _name)
    {
        name = _name;
    }

    public void SetAge(int _age)
    {
        if (_age <= 0) _age = 1;
        age = _age;
    }

    public void Jump()
    {
        Debug.Log(name + " Jump!");
    }

    public void Punch()
    {
        Debug.Log(name + " Punch!");
    }
}

public class CSharp : MonoBehaviour
{
    // 멤버변수(Member Variables)
    // 필드(Field)
    private int val = 0;
    // 객체(Object), 인스턴스화(Instance)
    private CSharp csharp = null;

    private Cat navi = null;

    private void Start()
    {
        // RC +1
        navi = new Cat("Chansik", 5, 13.5f);
        navi.Weight = 10;
        //navi.name = "Navi";
        //navi.SetName("Navi");
        navi.GetName();
        navi.Jump();

        {
            // RC +1 -> 2
            Cat changsik = navi;
        }
        // RC -1 -> 1

        ////////////////////////////////////

        PrintSomething();
        PrintSomething(10);
        PrintSomething(5, 0.5f);
    }

    // 멤버함수(Member Function)
    // 메소드(Method)
    private void PrintVal()
    {
        Debug.Log("val: " + val);
    }

    public void PrintSomething()
    {
        Debug.Log("Something");
    }

    public void PrintSomethingWithNumber(int _num)
    {
        Debug.Log("Something: " + _num);
    }

    //public int PrintSomething()
    //{
    //    return 0;
    //}

    // 함수 오버로딩(Function Overloading)
    public void PrintSomething(int _num)
    {
        Debug.Log("Something: " + _num);
    }

    // Default Parameter
    public void PrintSomething(int _num, float _val = 3.14f)
    {
        Debug.Log("Something: " + _num + " / " + _val);
    }
}
