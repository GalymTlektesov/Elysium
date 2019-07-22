using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampetScript : MonoBehaviour
{
    private Animator trampetAnim;
    void Start()
    {
        trampetAnim = GetComponent<Animator>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            trampetAnim.SetBool("Motion", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            trampetAnim.SetBool("Motion", false);
        }
    }
}
