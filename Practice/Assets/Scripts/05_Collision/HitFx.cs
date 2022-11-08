using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFx : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.1f);
    }
    private void Update()
    {
        transform.localScale = transform.localScale + (Vector3.one * Time.deltaTime);
    }
}
