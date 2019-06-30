using UnityEngine;


public class EnemyControllerScript : MonoBehaviour
{
    public Rigidbody2D enemy;// наш персонаж
    public Rigidbody2D player; // наш враг // нужно для слежки за наним героем
    public float speed; // скорость
    public float jumpforce; //сила прыжка
    Enemy Enemy = new Enemy();

    public Rigidbody2D bullet;

    public Transform ShotCreator;


    public float shotDelay; // задержка выстерла
    private float nextshot; //время когда можно стрелять


    public static float speedBullet = 12;

    public static Atack atack = new Atack();


    Status status;


    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); // добавляем компонент
        Enemy = new Enemy(100, speed, jumpforce, enemy.transform, player, 35, 25, bullet, enemy);// добавляем параметры
        atack = new Atack(speedBullet, Enemy, bullet);
    }

    private void Update()
    {
        atack.FlipAtatck();

        //Выстрел
        bool canShoot = Time.time > nextshot;
        if (canShoot)
        {
            nextshot = Time.time + shotDelay;
            Instantiate(bullet, ShotCreator.position, Quaternion.identity);
        }
        //Выстрел

    }

    private void FixedUpdate()
    {
        if (status == Status.Earch)
        {
            Enemy.Flip();
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
