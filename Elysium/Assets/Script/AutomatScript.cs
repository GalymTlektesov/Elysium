using UnityEngine;

public class AutomatScript : MonoBehaviour
{
    public float speed = 20;
    public float shotDelay;
    private float nextShot;
    public Transform automat;
    public Rigidbody2D bullet;


    void Update()
    {
        bool canShot = Time.time > nextShot;
        if (canShot)
        {
            Instantiate(bullet, new Vector2(transform.position.x - 1.3f , transform.position.y), Quaternion.identity);
            if (automat.rotation == Quaternion.Euler(0, 0, 0))
            {
                bullet.velocity = Vector2.left * speed;
            }
            if (automat.rotation == Quaternion.Euler(0, 180, 0))
            {
                bullet.velocity = Vector2.right * speed;
            }
            nextShot = Time.time + shotDelay;
        }
        
    }
}
