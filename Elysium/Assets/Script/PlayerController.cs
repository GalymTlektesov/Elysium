using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce = 17.0f;
    private Rigidbody2D player;
    private Animator charAnimator;
    private SpriteRenderer sprite;
    public static Player Player = new Player();// Объкт нашего персонажа
    public int HP = 100;
    public Rigidbody2D bullet;

    public enum Сondition
    {
        Air,
        Earch
    };
    


    public float HpRegeneretionDelay; // задержка выстерла
    private float nextHpRegeneretion; //время когда можно стрелять



    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // добавляем компонент
        //Player = new Player(HP, player.transform, player, 35, 25, bullet);// добавляем параметры
    }

    private void Update()
    {
        Player.Flip();// флипаем если нужно
        if (HP < 1)
        {
            Destroy(gameObject);
        }
        bool canShoot = Time.time > nextHpRegeneretion;

        if (HP < 100 && canShoot)
        {
            HP++;
            nextHpRegeneretion = Time.time + HpRegeneretionDelay;
        }
    }


    private void FixedUpdate()
    {
        Player.Controller(speed, jumpforce);// управление движения
        if (Input.GetKeyDown(KeyCode.Z))
        {

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
