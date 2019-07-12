using UnityEngine;


public class EnemyControllerScript : MonoBehaviour
{   
    internal Rigidbody2D enemy;// наш персонаж
    public Rigidbody2D player; // наш враг // нужно для слежки за наним героем
    public float speed; // скорость
    public float jumpforce; //сила прыжка

    public LegsScript legs;

    private SpriteRenderer enemySprite;
    private Animator enemyAnim;
    private Enemy Enemy = new Enemy();
    


    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); // добавляем компонент
        Enemy = new Enemy(enemy.transform, player, enemy, enemySprite, enemyAnim);// добавляем параметры
    }

    private void Update()
    {
        Enemy.Flip();
    }

    private void FixedUpdate()
    {
        
        if (legs.condition == Сondition.Earch)
        {
            Enemy.Controller(speed, jumpforce);
        }
    }
}
