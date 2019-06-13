using UnityEngine;


public class BulletController : MonoBehaviour
{
    public Rigidbody2D Bullet;

    public static float speed = 12;

    private void Start()
    {
        Destroy(gameObject, 12);
    }

    private void Update()
    {
        Bullet.velocity = Vector3.left * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
