using System;
using UnityEngine;

public class AutomatScript : MonoBehaviour
{
    public float shotDelay;
    private float nextShot;
    public Transform shootCreator;
    public Rigidbody2D bullet;


    public EnemyControllerScript Enemy;
    public bool atack;

    public const int capacity = 25;
    private int numberShots;
    
    
    public float doubleShotDelay;
    private float doubleNextShot;
    
    


    void Update()
    {
        bool canShot = Time.time > nextShot;
        bool doubleCanShot = Time.time > doubleNextShot;
        if (numberShots == capacity)
        {
            doubleNextShot = Time.time + doubleShotDelay;
            numberShots = 0;
        }
        
        if (doubleCanShot && canShot && Math.Abs(Enemy.player.transform.position.x - Enemy.enemy.transform.position.x) < 14 
        && Math.Abs(Enemy.player.transform.position.y - Enemy.enemy.transform.position.y) < 3)
        {
            atack = true;
            var position = shootCreator.position;
            Instantiate(bullet, new Vector2(position.x , position.y), transform.rotation);
            nextShot = Time.time + shotDelay;
            numberShots++;
        }
        else
        {
            atack = false;
        }
        
    }
}
