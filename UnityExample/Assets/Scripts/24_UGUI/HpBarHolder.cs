using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarHolder : MonoBehaviour
{
    private RectTransform rt = null;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }
    public void SetPosition(Vector3 _worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(_worldPos);
        screenPos.y += 70f;
        rt.position = screenPos;
        //rt.position = _worldPos;
    }
}
