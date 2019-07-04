using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatScript : MonoBehaviour
{
    public GameObject bullet;

    public float shotDelay;
    private float nextShot;

    void Start()
    {
        
    }

    void Update()
    {
        bool canShot = Time.time > nextShot;
        if (canShot)
        {
            Instantiate(bullet, new Vector2(transform.position.x - 1.3f , transform.position.y), Quaternion.identity);
            nextShot = Time.time + shotDelay;
        }
        
    }
}
