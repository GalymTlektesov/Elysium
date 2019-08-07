using System;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody2D bullet;
    public GameObject explosion;
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
        if (collision.CompareTag("trumpet"))
        {
            return;
        }
        if (collision.CompareTag("dont_trumpet"))
        {
            return;
        }
        if (collision.CompareTag("terain") && collision.isTrigger)
        {
            return;
        }

        Destroy(gameObject);

        if (Math.Abs(transform.rotation.y) < 1)
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 270));
        }
        else
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 90));
        }
        
        
        if (collision.CompareTag("Wall"))
        {
            bullet.tag = "terain";
        }
    }
}
