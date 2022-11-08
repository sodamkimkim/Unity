using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText = null;

    private int coinCnt = 0;
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("Coin"))
        {
            ++coinCnt;
            countText.text = coinCnt.ToString();
            Destroy(_other.gameObject);
        }
        else if(_other.tag == "Bomb")
        {
            Debug.Log("Boooom!!");
            Destroy(_other.gameObject);
        }
    }
}
