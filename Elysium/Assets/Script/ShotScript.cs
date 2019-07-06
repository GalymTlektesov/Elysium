using System;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody2D bullet;
    public float speed = 25;

    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Math.Abs(transform.rotation.y) < 1)
        {
            bullet.velocity = Vector2.left * speed;
        }
        else
        {
            bullet.velocity = Vector2.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
