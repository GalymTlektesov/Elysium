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

    public AutomatScript auto;


    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
        auto = GetComponentInChildren<AutomatScript>();
        enemy = GetComponent<Rigidbody2D>(); // добавляем компоненты
    }

    private void Start()
    {
        Enemy = new Enemy(enemy.transform, player, enemy, enemySprite);// добавляем параметры
    }

    private void Update()
    {
        enemyAnim.SetInteger("EnemyState", Enemy.animNumber);
        Enemy.Atack = auto.atack;
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
