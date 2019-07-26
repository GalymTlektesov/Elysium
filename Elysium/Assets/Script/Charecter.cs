using UnityEngine;

public class Charecter : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce = 17.0f;

    public LegsPlayerScipt legs;
    
    private Rigidbody2D charecter;
    private Animator charAnimator;
    private SpriteRenderer sprite;
    public int AnimNumber;
    float punchX = 0.83f;
    const float punchY = 0.68f;
    

    DirectionPunch directionPunch;



    public Transform punch; // Объект удара нашего героя
    public float punchDelay; // Задржка удара
    private float punchNext; // Можно ударить

    void Awake()
    {
        charecter = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Move()
    {
        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempVector, speed * Time.deltaTime);
        if (tempVector.x < 0)
        {
            sprite.flipX = true;
            directionPunch = DirectionPunch.left;
        }
        else 
        {
            sprite.flipX = false;
            directionPunch = DirectionPunch.rigth;
        }
    }

    void Jump()
    {
        charecter.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
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
    
    

    void Update()
    {
        charAnimator.SetInteger("State", AnimNumber);


        // Ничего 
        if (!Input.anyKey)
        {
            //charAnimator.ResetTrigger("Jump");
            AnimNumber = 0;
        }
    }

    private void FixedUpdate() 
    {
         // Перемещение право и влево
        if(Input.GetButton("Horizontal"))
        {
            AnimNumber = 1;
            Move();
        }

        // Прыжок
        if (Input.GetButton("Jump") && legs.condition == СondPlayer.Earch)
        {
            //charAnimator.SetTrigger("Jump");
            AnimNumber = 2;
            Jump();
        }
        if (Input.GetButtonDown("Jump") && legs.condition == СondPlayer.AirOne)
        {
            AnimNumber = 2;
            legs.condition = СondPlayer.AirTwo;
            Jump();
        }

        //Удар
        bool canshot = Time.time > punchNext;
        if (Input.GetKey(KeyCode.Z) && canshot)
        {
            AnimNumber = 3;
            Punch();
        }
    }
}
