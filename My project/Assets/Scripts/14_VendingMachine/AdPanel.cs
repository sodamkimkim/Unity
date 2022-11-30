using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̹��� �߰�
// �̹��� ���� �ð�(����)
// ������ - ������
public class AdPanel : MonoBehaviour
{
    [SerializeField]
    private Texture2D[] adImgs = null;
    [SerializeField]
    private float interval = 1f;
    [SerializeField]
    private bool shuffle = false;

    private MeshRenderer mr = null;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        if (adImgs == null || adImgs.Length == 0)
            return;

        StartCoroutine(ChangeImageCoroutine());
    }

    private IEnumerator ChangeImageCoroutine()
    {
        int idx = 0;

        while (true)
        {
            if (!shuffle)
            {
                mr.material.mainTexture = adImgs[idx];
                ++idx;
                //if (idx >= adImgs.Length) idx = 0;
                idx %= adImgs.Length;
            }
            else
            {
                mr.material.mainTexture =
                    adImgs[Random.Range(0, adImgs.Length)];
            }

            yield return new WaitForSeconds(interval);
        }
    }
}
