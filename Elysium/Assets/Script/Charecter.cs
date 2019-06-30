using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Charecter : MonoBehaviour
{
    public int Hp = 3;
    public float speed = 4.0f;
    public float jumpforce = 17.0f;
    private Rigidbody2D charecter;
    private Animator charAnimator;
    private SpriteRenderer sprite;

    public enum Сondition
    {
        Air,
        Earch
    };

    public Сondition condition;

    void Awake()
    {
        charecter = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void Move()
    {
        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempVector, speed * Time.deltaTime);
        if (tempVector.x < 0)
        {
            sprite.flipX = true;
        }
        else 
        {
            sprite.flipX = false;
        }
    }

    void Jump()
    {
        charecter.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    
    

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            charAnimator.SetInteger("State", 1);
            Move();
        }
        if (Input.GetButton("Jump") && condition == Сondition.Earch)
        {
            //charAnimator.SetTrigger("Jump");
            charAnimator.SetInteger("State", 2);
            Jump();
        }
        if (!Input.anyKey)
        {
            //charAnimator.ResetTrigger("Jump");
            charAnimator.SetInteger("State", 0);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "terain")
        {
            condition = Сondition.Earch;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        condition = Сondition.Air;
    }
}
