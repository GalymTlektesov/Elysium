using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Charecter : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce = 20.0f;
    private float _trueJumpforce;

    public LegsPlayerScipt legs;
    
    private Rigidbody2D _charecter;
    private Animator _charAnimator;
    private SpriteRenderer _sprite;
    [FormerlySerializedAs("AnimNumber")] public int animNumber;
    float punchX = 0.83f;
    const float PunchY = 0.68f;
    

    DirectionPunch _directionPunch;



    public Transform punch; // Объект удара нашего героя
    public float punchDelay; // Задржка удара
    private float _punchNext; // Можно ударить

    void Awake()
    {
        _charecter = GetComponent<Rigidbody2D>();
        _charAnimator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _trueJumpforce = jumpforce;
    }

    void Move()
    {
        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        position = Vector3.MoveTowards(position, position + tempVector, speed * Time.deltaTime);
        transform.position = position;
        if (tempVector.x < 0)
        {
            _sprite.flipX = true;
            _directionPunch = DirectionPunch.left;
        }
        else 
        {
            _sprite.flipX = false;
            _directionPunch = DirectionPunch.rigth;
        }
    }

    void Jump()
    {
        _charecter.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    void Punch()
    {
        _punchNext = Time.time + punchDelay;
        if (_directionPunch == DirectionPunch.rigth)
        {
            Instantiate(punch, new Vector2(transform.position.x + punchX, transform.position.y + PunchY), Quaternion.identity);
        }
        if (_directionPunch == DirectionPunch.left)
        {
            Instantiate(punch, new Vector2(transform.position.x - punchX, transform.position.y + PunchY), Quaternion.identity);
        }
    }
    
    

    void Update()
    {
        _charAnimator.SetInteger("State", animNumber);


        // Ничего 
        if (!Input.anyKey)
        {
            //charAnimator.ResetTrigger("Jump");
            animNumber = 0;
        }
    }

    private void FixedUpdate() 
    {
        if (!_charecter.simulated && Input.GetButton("Vertical"))
        {
            Vector3 tempVector = Vector3.up * Input.GetAxis("Vertical");
            var position = transform.position;
            position = Vector3.MoveTowards(position, position + tempVector, speed * Time.deltaTime);
            transform.position = position;
        }
        
        // Перемещение право и влево
        if(Input.GetButton("Horizontal"))
        {
            animNumber = 1;
            Move();
        }

        // Прыжок
        if (Input.GetButton("Jump") && legs.condition == СondPlayer.Earch)
        {
            //charAnimator.SetTrigger("Jump");
            animNumber = 2;
            Jump();
        }
        if (Input.GetButtonDown("Jump") && legs.condition == СondPlayer.AirOne)
        {
            animNumber = 2;
            legs.condition = СondPlayer.AirTwo;
            Jump();
        }

        //Удар
        bool canshot = Time.time > _punchNext;
        if (Input.GetKey(KeyCode.Z) && canshot)
        {
            animNumber = 3;
            Punch();
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
