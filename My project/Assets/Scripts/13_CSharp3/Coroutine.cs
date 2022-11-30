using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    private UnityEngine.Coroutine coroutineExample = null;

    private void Start()
    {
        coroutineExample =
            StartCoroutine(CoroutineExample());
        StartCoroutine("CountCoroutine");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StopCoroutine(coroutineExample);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StopCoroutine("CountCoroutine");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator CoroutineExample()
    {
        while (true)
        {
            Debug.Log("1");
            yield return new WaitForSeconds(1f);
            Debug.Log("2");
            yield return new WaitForSeconds(1f);
            Debug.Log("3");
        }
    }

    private IEnumerator CountCoroutine()
    {
        while(true)
        {
            Debug.Log("-");
            //yield return new WaitForSeconds(0.3f);
            //yield break;
            yield return null;
        }
    }
}
