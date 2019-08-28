using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HpPlayer : MonoBehaviour
{
    private static float health;
    public Slider slider;
    public Image image;


    public float shotDelay; // задержка удара
    private float nextshot; //время когда удар снова наностится 

    public static float Health { get => health; set => health = value; }

    private float _maxHealth;
    public static int DeathPlayer = 2;

    private void Start() 
    {
        health = 100;
        _maxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        image.color = Color.Lerp(Color.red, Color.green, Health / _maxHealth);
        slider.value = Health;
        if (Health < 1)
        {
            DeathPlayer++;
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
            var demage = collision.collider.GetComponent<DamageScript>();
            Health -= demage.Damage();
            nextshot = Time.time + shotDelay;
        }

        if (collision.collider.CompareTag("Lazer") && canShoot)
        {
            var demage = collision.collider.GetComponent<DamageScript>();
            Health -= demage.Damage();
            nextshot = Time.time + (shotDelay / 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyAtack")
        {
            var demage = collision.GetComponent<DamageScript>();
            Health -= demage.Damage();
        }
        if(collision.CompareTag("Hp"))
        {
            var plus = collision.GetComponent<HealthScript>();
            Health += plus.HpPlus();
            if(Health > _maxHealth)
            {
                Health = _maxHealth;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        bool canShoot = Time.time > nextshot;
        if (canShoot && other.CompareTag("EnemyAtack"))
        {
            Health -= Random.Range(25, 50);
            nextshot = Time.time + shotDelay;
        }
    }
}
