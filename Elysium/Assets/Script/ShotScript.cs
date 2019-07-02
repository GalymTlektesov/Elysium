using UnityEngine;

public class ShotScript : MonoBehaviour
{
    Rigidbody2D bullet;
    public float speed = 30;
    void Start()
    {
        Destroy(gameObject, 7);
    }

    private void Update()
    {
        bullet.velocity = Vector2.left * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
