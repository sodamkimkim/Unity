using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraidPlayerNew : MonoBehaviour
{
    private Animator anim = null;
    private SpriteRenderer sr = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        // IsRun 제어
        anim.SetBool("IsRun", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        if (Input.GetKey(KeyCode.A))
            sr.flipX = true;
        else if (Input.GetKey(KeyCode.D))
            sr.flipX = false;

        // IsNodding 제어
        anim.SetBool("IsNodding", Input.GetKey(KeyCode.UpArrow));

        //IsDumchit 제어
        anim.SetBool("IsDumchit", Input.GetKey(KeyCode.F));
    }
}
