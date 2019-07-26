using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampetScript : MonoBehaviour
{
    private SpriteRenderer sprite;

    public Sprite[] TrampetSprite = new Sprite[2];
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.isTrigger = true;
            sprite.sprite = TrampetSprite[1];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.sprite = TrampetSprite[0];
            other.isTrigger = false;
        }
    }
}
