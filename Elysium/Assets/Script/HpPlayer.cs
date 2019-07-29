using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HpPlayer : MonoBehaviour
{
    private static int health;
    public Slider slider;

    public float shotDelay; // задержка удара
    private float nextshot; //время когда удар снова наностится 

    public static int Health { get => health; set => health = value; }


    private void Start() 
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Health;
        if (Health < 1)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            TaskScript.Kill = 0;
            //time.Time = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool canShoot = Time.time > nextshot;
        if (collision.collider.CompareTag("Saw") && canShoot)
        {
            Health -= Random.Range(10, 25);
            nextshot = Time.time + shotDelay;
        }

        if (collision.collider.CompareTag("Lazer") && canShoot)
        {
            Health -= Random.Range(5, 10);
            nextshot = Time.time + (shotDelay / 2);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mine"))
        {
            Invoke("Explosion", 0.2f);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyAtack")
        {
            Health -= Random.Range(0, 3);
        }
        if (collision.tag == "GameOver")
        {
            Health -= 10000;
        }
    }


    private void Explosion()
    {
        Health -= Random.Range(35, 100);
    }
}
