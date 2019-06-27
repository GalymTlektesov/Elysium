using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter : MonoBehaviour
{
    public int Hp = 3;
    public float speed = 4.0f;
    public float jumpforce = 17.0f;
    public Rigidbody2D charecter;
    public Animator charAnimator;
    public SpriteRenderer sprite;
    bool OnGround;

    void Awake()
    {
        charecter = GetComponentInChildren<Rigidbody2D>();
        charAnimator = GetComponentInChildren<Animator>();
        sprite =GetComponentInChildren<SpriteRenderer>();
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

    void ChekcGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        OnGround = colliders.Length > 1;
    }

    void FixedUpdate()
    {
        ChekcGround();
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            Move();
            charAnimator.SetInteger("State", 1);
        }
        if (Input.GetButton("Jump"))
        {
            Jump();
            charAnimator.SetInteger("State", 2);
        }
        if (!Input.anyKey)
        {
            charAnimator.SetInteger("State", 0);
        }
    }
}
