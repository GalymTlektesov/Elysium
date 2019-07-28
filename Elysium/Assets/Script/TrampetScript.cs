﻿using UnityEngine;

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
        if (!other.CompareTag("terain"))
        {
            gameObject.tag = "trumpet";
        }
        if (other.CompareTag("Player"))
        {
            sprite.sprite = TrampetSprite[1];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.tag = "dont_trumpet";
        if (other.CompareTag("Player"))
        {
            sprite.sprite = TrampetSprite[0];
        }
    }
}
