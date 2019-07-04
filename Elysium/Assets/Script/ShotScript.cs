using UnityEngine;

public class ShotScript : MonoBehaviour
{
    Rigidbody2D bullet;
    public float speed = 30;
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bullet.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
