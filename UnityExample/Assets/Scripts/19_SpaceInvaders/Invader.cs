using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if(_collision.CompareTag("SI_Missile"))
        {
            Debug.Log("dd");
            Destroy(_collision.gameObject);
            Destroy(gameObject);
        }
    }
}
