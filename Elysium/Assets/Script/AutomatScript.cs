using UnityEngine;

public class AutomatScript : MonoBehaviour
{
    public float shotDelay;
    private float nextShot;
    public Transform shootCreator;
    public Rigidbody2D bullet;


    void Update()
    {
        bool canShot = Time.time > nextShot;
        if (canShot)
        {
            Instantiate(bullet, new Vector2(shootCreator.position.x , shootCreator.position.y), transform.rotation);
            nextShot = Time.time + shotDelay;
        }
        
    }
}
