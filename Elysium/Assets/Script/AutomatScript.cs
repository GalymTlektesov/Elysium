using System;
using UnityEngine;

public class AutomatScript : MonoBehaviour
{
    public float shotDelay;
    private float nextShot;
    public Transform shootCreator;
    public Rigidbody2D bullet;
    public EnemyControllerScript Player;


    void Update()
    {
        bool canShot = Time.time > nextShot;
        if (canShot && Math.Abs(Player.player.transform.position.x - Player.enemy.transform.position.x) < 14 
        && Math.Abs(Player.player.transform.position.y - Player.enemy.transform.position.y) < 3) 
        {
            Instantiate(bullet, new Vector2(shootCreator.position.x , shootCreator.position.y), transform.rotation);
            nextShot = Time.time + shotDelay;
        }
        
    }
}
