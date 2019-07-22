using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    public int Health = 100;
    
    public float shotDelay; // задержка удара
    private float nextshot; //время когда удар снова наностится 

    void Update()
    {
        if (Health < 1)
        {
            HpPlayer.Health += 5;
            TaskScript.Kill++;
            Destroy(gameObject);
        }
    }
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        bool canShoot = Time.time > nextshot;
        if (collision.collider.tag == "Saw" && canShoot)
        {
            Health -= Random.Range(10, 25);
            nextshot = Time.time + shotDelay;
        }     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "punch")
        {
            Health -= Random.Range(20, 35);
        }
    }
}
