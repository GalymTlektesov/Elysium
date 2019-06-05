using UnityEngine;


public class EnemyControllerScript : MonoBehaviour
{
    public Rigidbody2D enemy;// наш персонаж
    public Rigidbody2D player;
    public Player hero;
    public float speed; // скорость
    public float jumpforce; //сила прыжка
    Enemy Enemy = new Enemy();

    public GameObject bullet;

    Status status;


    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); // добавляем компонент
        Enemy = new Enemy(100, speed, jumpforce, enemy.transform, player, 35, 25, enemy, hero);// добавляем параметры
    }

    private void Update()
    {
        Enemy.Flip();

        if (System.Math.Abs(transform.localRotation.y - 180) < 5)
            bullet.transform.position = new Vector2(bullet.transform.position.x * speed * Time.deltaTime, bullet.transform.position.y);
        if (System.Math.Abs(transform.localRotation.y - 0) > 5)
            bullet.transform.position = new Vector2(bullet.transform.position.x * -speed * Time.deltaTime, bullet.transform.position.y);
    }

    private void FixedUpdate()
    {
        if (status == Status.Earch)
        {
            Enemy.Controller(speed, player.transform, jumpforce);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        status = Status.Earch;

    }

    //Проверка на прекращения столкновения двух объктов
    private void OnCollisionExit2D(Collision2D collision)
    {
        status = Status.Air;
    }
}
