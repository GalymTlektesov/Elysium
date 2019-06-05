using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;// наш персонаж
    public float speed; // скорость
    public float jumpforce; //сила прыжка
    Player Player = new Player();// Объкт нашего персонажа
    public int HP = 100;
    public GameObject bullet;


    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // добавляем компонент
        Player = new Player(HP, speed, jumpforce, player.transform, player, 35, 25);// добавляем параметры
    }

    private void Update()
    {
        Player.Flip();// флипаем если нужно
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        Player.Controller(speed, player.transform, jumpforce);// управление движения
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }


    // Проверка на столкновения двух объктов
    private void OnCollisionStay2D(Collision2D collision)
    {
        Persona.status = Status.Earch;
    }

    //Проверка на прекращения столкновения двух объктов
    private void OnCollisionExit2D(Collision2D collision)
    {
        Persona.status = Status.Air;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyAtack")
        {
            HP -= Random.Range(10, 25);
        }
    }

}
