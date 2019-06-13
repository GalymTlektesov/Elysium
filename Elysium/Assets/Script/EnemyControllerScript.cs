using UnityEngine;


public class EnemyControllerScript : MonoBehaviour
{
    public Rigidbody2D enemy;// наш персонаж
    public Rigidbody2D player; // наш враг
    public Player hero; // нужно для слежки за наним героем
    public float speed; // скорость
    public float jumpforce; //сила прыжка
    Enemy Enemy = new Enemy();

    public Rigidbody2D bullet;

    public Transform ShotCerator;


    public float shotDelay; // задержка выстерла
    private float nextshot; //время когда можно стрелять


    Status status;


    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); // добавляем компонент
        Enemy = new Enemy(100, speed, jumpforce, enemy.transform, player, 35, 25, enemy, hero);// добавляем параметры
        Debug.Log("Начало");
    }

    private void Update()
    {
        Enemy.Flip();


        //Выстрел
        bool canShoot = Time.time > nextshot;
        if (canShoot)
        {
            if (Enemy.flipStatus == FlipStatus.Left)
            {
                bullet.velocity = Vector3.left * BulletController.speed;
                Instantiate(bullet, ShotCerator.position, Quaternion.Euler(0, 180, 0));
            }
            if (Enemy.flipStatus == FlipStatus.Rigth)
            {
                bullet.velocity = Vector3.right * BulletController.speed;
                Instantiate(bullet, ShotCerator.position, Quaternion.Euler(0, 0, 0));
            }
            nextshot = Time.time + shotDelay;
        }
        //Выстрел
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
