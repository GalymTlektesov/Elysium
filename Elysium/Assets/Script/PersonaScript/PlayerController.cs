using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float _trueJumpforce;
    private Rigidbody2D player;
    
    private Animator charAnimator;
    public Player Player = new Player();// Объкт нашего персонажа
    
    
    float punchX = 0.83f;
    const float punchY = 0.68f;
    
    public LegsPlayerScipt legs;

    DirectionPunch directionPunch;
    
    public Transform punch; // Объект удара нашего героя
    public float punchDelay; // Задржка удара
    private float punchNext; // Можно ударить
    public GameObject fire; // Объект огня

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        _trueJumpforce = jumpforce;
        Player = new Player(player.transform, player, directionPunch);// добавляем параметры
    }

    private void Update()
    {
        charAnimator.SetInteger("State", Player.animNumber);
        Player.Flip();// флипаем если нужно
    }


    private void FixedUpdate()
    {
        if (legs.condition == СondPlayer.Earch)
        {
            Player.Controller(speed, jumpforce); // управление движения
        }

        //Удар
        bool canshot = Time.time > punchNext;
        if (Input.GetKey(KeyCode.Z) && canshot)
        {
            Punch();
            Player.animNumber = 3;
        }
        //Огонь
        if (Input.GetKey(KeyCode.X) && canshot)
        {
            Player.animNumber = 3;
            Fire();
        }
    }


    void Punch()
    {
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

    private void Fire()
    {
        punchNext = Time.time + punchDelay;
        if (directionPunch == DirectionPunch.rigth)
        {
            Instantiate(fire, new Vector2(transform.position.x + punchX, transform.position.y + punchY), Quaternion.Euler(0, 180, 0));
        }
        if (directionPunch == DirectionPunch.left)
        {
            Instantiate(fire, new Vector2(transform.position.x - punchX, transform.position.y + punchY), Quaternion.Euler(0, 0, 0));
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("trumpet"))
        {
            jumpforce = 3.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        jumpforce = _trueJumpforce;
    }

}
