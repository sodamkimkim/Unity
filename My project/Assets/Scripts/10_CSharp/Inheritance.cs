using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���(Inheritance)
// Parent - Child
// Super - Sub
// Base - Derived
public abstract class Parent
{
    protected int parentVal = 0;

    public void ParentFunc()
    {
        Debug.Log("Parent Function!");
    }

    // �����Լ�(Virtual Function)
    // Virtual Function Table
    // �߻�ȭ ���α׷���(Abstract Programming)
    // ������(Polymorphism)
    public virtual void Something()
    {
        Debug.Log("Parent Something");
    }

    public abstract void Sound();
}

public class Child : Parent
{
    private int childVal = 0;

    public void PrintParentValue()
    {
        parentVal = 100;
        Debug.Log("Print Parent Value: " + parentVal);
    }

    public void ChildFunc()
    {
        Debug.Log("Child Function!");
    }

    // �Լ� �������̵�(Function Overriding)
    public override void Something()
    {
        base.Something();
        Debug.Log("Child Something");
    }

    public override void Sound()
    {
        Debug.Log("Child Sound");
    }
}


////////////////////////////////////////


// Virtual - Abstract - Interface
public interface IInterface
{
    //public int val = 0;

    //public void Func()
    //{
    //    Debug.Log("IInterface Function");
    //}

    public abstract void Func();
}


///////////////////////////////////////////


public class Human
{
    private int age;
}

public class Cop : Human
{
    // IS-A
}

public class Computer { }

// ���߻��(Multi Inheritance)
// ������ ���̾Ƹ��
public class Programmer : Human//, Computer
{
    // HAS-A
    private Computer computer;
}


public class Inheritance : MonoBehaviour
{
    private void Start()
    {
        //Parent parent = new Parent();
        //parent.Something();

        //Child child = new Child();
        //child.PrintParentValue();
        //child.Something();


        /////////////////////////////////////


        Parent parentChild = new Child();
        //Child childParent = new Parent();
        parentChild.Something();
        Debug.Log("--------");
        //((Child)parentChild).Something();

        //Parent parent = new Parent();
    }
}
