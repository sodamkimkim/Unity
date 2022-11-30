using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class StringExample : MonoBehaviour
{
    [SerializeField]
    private string str = null;
    [SerializeField]
    private string newStr = new string("String");
    [SerializeField]
    private string hello = "Hello";

    private void Start()
    {
        //newStr[2] = 'R';
        //hello[2] = 'L';
        char[] newStrToArr = newStr.ToCharArray();
        newStrToArr[2] = 'R';
        Debug.Log(newStr);

        string[] strList = str.Split(',');
        foreach (string s in strList)
            Debug.Log(s);

        // 연산자 오버로딩(Operator Overloading)
        Debug.Log("Hello" + ", " + "World" + "!");

        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(", ");
        sb.Append("World");
        sb.Append("!");
        Debug.Log("sb: " + sb.ToString());

        string num = "123";
        int i = int.Parse(num);
        Debug.Log("i: " + i.ToString());
    }
}
