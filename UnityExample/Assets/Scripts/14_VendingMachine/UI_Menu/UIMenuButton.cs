using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

// 1. ��ư ���� ����
// 2. ��ư�� ������ �� ���� ����
public class UIMenuButton : MonoBehaviour
{
    private TextMeshProUGUI info = null;
    private StringBuilder sb = new StringBuilder();
    private void Awake()
    {
        info = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdateInfo(string _name, int _price, int _stock)
    {
        sb.Clear();

        sb.Append(_name);
        sb.Append("\n"); // �ٹٲ� ���� �־��ִ���
        sb.AppendLine(_price.ToString()); // appendline���� ������
        sb.AppendLine(_stock.ToString());

        info.text = sb.ToString();
    }
}
