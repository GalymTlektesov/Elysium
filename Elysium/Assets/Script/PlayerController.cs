using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private Rigidbody2D player;
    
    private Animator charAnimator;
    private SpriteRenderer sprite;
    public static Player Player = new Player();// Объкт нашего персонажа
    
    
    float punchX = 0.83f;
    const float punchY = 0.68f;
    
    public LegsScript legs;

    DirectionPunch directionPunch;
    
    public Transform punch; // Объект удара нашего героя
    public float punchDelay; // Задржка удара
    private float punchNext; // Можно ударить

    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // добавляем компонент
        Player = new Player(player.transform, player, sprite);// добавляем параметры
    }

    private void Update()
    {
        Player PLayer = new Player(directionPunch);
        Player.Flip();// флипаем если нужно
    }


    private void FixedUpdate()
    {
        if (legs.condition == Сondition.Earch)
        {
            Player.Controller(speed, jumpforce); // управление движения
        }

        //Удар
        bool canshot = Time.time > punchNext;
        if (Input.GetKey(KeyCode.Z) && canshot)
        {
            charAnimator.SetInteger("State", 3);
            punchNext = Time.time + punchDelay;
            if (directionPunch == DirectionPunch.rigth)
            {
                Instantiate(punch, new Vector2(transform.position.x + punchX, transform.position.y + punchY), Quaternion.identity);
            }
            if (directionPunch == DirectionPunch.left)
            {
                Instantiate(punch, new Vector2(transform.position.x - punchX, transform.position.y + punchY), Quaternion.identity);
            }
        }
    }

}
