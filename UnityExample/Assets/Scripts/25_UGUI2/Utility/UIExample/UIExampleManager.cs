using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIExampleManager : MonoBehaviour
{

    [SerializeField]
    private OptionPanHolder optionPanHolder = null;
    private GameObject optionPan = null;
    private Button btn = null;
    private bool isOpen = false;
    private bool isAnimation = false;
    private float sizingSpeed = 0.05f;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(BtnCallback);
        optionPan = optionPanHolder.gameObject;
    }
    private void BtnCallback()
    {
        if (!isOpen)
        { // open optionPan
            OpenOptionPan();
        }
        else if (isOpen)
        { // close optionPan
            CloseOptionPan();
        }
    }
    private void OpenOptionPan()
    {
        isOpen = true;
        Debug.Log("Open OptionPan");
        //optionPan.SetActive(true);
        if (isOpen == true )
        {
            StopAllCoroutines();
            StartCoroutine(SizingCoroutine(0.01f, 1f));
        }
    }
    public void CloseOptionPan()
    {
        isOpen = false;
        Debug.Log("Close OptionPan");
        StopAllCoroutines();
        if (isOpen == false)
        {
            StopAllCoroutines();
            StartCoroutine(SizingCoroutine(1f, 0.01f));
        }
        //optionPan.SetActive(false);
    }
    private IEnumerator SizingCoroutine(float _startSz, float _endSz)
    {
        isAnimation = true;
        Vector3 newSz = Vector3.zero;
        Transform opTr = optionPan.transform;
        float t = 0f;
        while (t < 1f)
        {
            newSz = new Vector3(Mathf.Lerp(opTr.localScale.x, _endSz, t), Mathf.Lerp(opTr.localScale.y, _endSz, t), 0f);
            opTr.localScale = newSz;
            t += Time.deltaTime * sizingSpeed;
            yield return null;
        }
        newSz = opTr.localScale;
        newSz = new Vector3(_endSz, _endSz, 0f);
        opTr.localScale = newSz;
        isAnimation = false;
    }
} // end of class
