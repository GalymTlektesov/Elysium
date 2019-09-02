using UnityEngine;


public class EnemyControllerScript : MonoBehaviour
{   
    internal Rigidbody2D enemy;// наш персонаж
    public Rigidbody2D player; // наш враг // нужно для слежки за наним героем
    public float speed; // скорость
    public float jumpforce; //сила прыжка

    public LegsScript legs;

    private Animator enemyAnim;
    private Enemy Enemy = new Enemy();

    public AutomatScript auto;


    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        auto = GetComponentInChildren<AutomatScript>();
        enemy = GetComponent<Rigidbody2D>(); // добавляем компоненты
    }

    private void Start()
    {
        Enemy = new Enemy(enemy.transform, player, enemy);// добавляем параметры
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
