using UnityEngine;


public class EnemyControllerScript : MonoBehaviour
{   
    Rigidbody2D enemy;// наш персонаж
    public Rigidbody2D player; // наш враг // нужно для слежки за наним героем
    public float speed; // скорость
    public float jumpforce; //сила прыжка

    SpriteRenderer enemySprite;
    Animator enemyAnim;
    Enemy Enemy = new Enemy();

    Status status;


    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); // добавляем компонент
        Enemy = new Enemy(100, enemy.transform, player, enemy, enemySprite, enemyAnim);// добавляем параметры
    }

    private void FixedUpdate()
    {
         Enemy = new Enemy(enemy);
        if (status == Status.Earch)
        {
            Enemy.Flip();
            Enemy.Controller(speed, jumpforce);
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
