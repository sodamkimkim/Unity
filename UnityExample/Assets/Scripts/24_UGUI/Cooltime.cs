using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooltime : MonoBehaviour
{
    public delegate void FinishDelegate();
    private FinishDelegate finishCallback = null;

    [SerializeField]
    private float duration = 1f;

    private Image uiImage = null;
    private bool isReady = true;

    private void Awake()
    {
        uiImage = GetComponent<Image>();
    }
    private void Update()
    {
        if (isReady == true && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(CooltimeCoroutine());
        }
    }
    private IEnumerator CooltimeCoroutine()
    {
        isReady = false;
        float amount = 0f;
        while (amount < 1f)
        {
            uiImage.fillAmount = amount;

            amount += Time.deltaTime / duration;
            yield return null;
        }
        uiImage.fillAmount = 1f;
        isReady = true;

        // 콜백함수 받았으면 수행. 여기선 없긴 함
        finishCallback?.Invoke();
    }
} // end of class
