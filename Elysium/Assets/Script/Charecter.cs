﻿using UnityEngine;

public class Charecter : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce = 17.0f;

    public LegsScript legs;
    
    private Rigidbody2D charecter;
    private Animator charAnimator;
    private SpriteRenderer sprite;
    float punchX = 0.83f;
    const float punchY = 0.68f;

    public enum DirectionPunch
    {
        rigth,
        left
    }

    DirectionPunch directionPunch;



    public Transform punch; // Объект удара нашего героя
    public float punchDelay; // Задржка удара
    private float punchNext; // Можно ударить

    void Awake()
    {
        charecter = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Move()
    {
        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempVector, speed * Time.deltaTime);
        if (tempVector.x < 0)
        {
            sprite.flipX = true;
            directionPunch = DirectionPunch.left;
        }
        else 
        {
            sprite.flipX = false;
            directionPunch = DirectionPunch.rigth;
        }
    }

    void Jump()
    {
        charecter.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    
    

    void Update()
    {
        // Перемещение право и влево
        if(Input.GetButton("Horizontal"))
        {
            charAnimator.SetInteger("State", 1);
            Move();
        }
        // Прыжок
        if (Input.GetButton("Jump") && legs.condition == Сondition.Earch)
        {
            //charAnimator.SetTrigger("Jump");
            charAnimator.SetInteger("State", 2);
            Jump();
        }

        //Удар
        bool canshot = Time.time > punchNext;
        if (Input.GetKey(KeyCode.Z) && canshot)
        {
            charAnimator.SetInteger("State", 3);
            punchNext = Time.time + punchDelay;
            if (directionPunch == DirectionPunch.rigth)
            {
                Instantiate(punch, new Vector2(transform.position.x + punchX, transform.position.y + punchY), Quaternion.identity);
            }
            if (directionPunch == DirectionPunch.left)
            {
                Instantiate(punch, new Vector2(transform.position.x - punchX, transform.position.y + punchY), Quaternion.identity);
            }
        }


        // Ничего 
        if (!Input.anyKey)
        {
            //charAnimator.ResetTrigger("Jump");
            charAnimator.SetInteger("State", 0);
        }

        //Выход
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
