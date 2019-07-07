using UnityEngine;

public class Player : Persona
{
    public Rigidbody2D player;
    private Animator charAnimator;
    private DirectionPunch Punch;
    private SpriteRenderer sprite;

    public Player()// конструктор для глобальной переменной
    {

    }

    public Player( Transform position, Rigidbody2D player, 
        SpriteRenderer sprite, Animator charAnimator) : 
        base(position, player, sprite, charAnimator)
    {
        this.player = player;
        this.charAnimator = charAnimator;
        this.sprite = sprite;
    }

    public Player(DirectionPunch punch)
    {
        Punch = punch;
    }

    public override void Flip()
    {
        //Поворот в право
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Поворот нашего персонажа
            Punch = DirectionPunch.rigth;
            sprite.flipX = false;
        }
        //Поворот в лево
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Поворот наншего персонажа
            sprite.flipX = true;
            Punch = DirectionPunch.left;
        }
    }


    //Управления наш героя
    public override void Controller(float speed, float jumpforce)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// горизонтальное перемещение

        player.velocity = new Vector2(moveHorizontal * speed, player.velocity.y); // движение и скорость движение


        // Прыжок
        if (Input.GetButton("Jump"))
        {
            //charAnimator.SetTrigger("Jump");
            charAnimator.SetInteger("State", 2);
            player.AddForce(player.transform.up * jumpforce, ForceMode2D.Impulse);
        }


        // Ничего 
        if (!Input.anyKey)
        {
            //charAnimator.ResetTrigger("Jump");
            charAnimator.SetInteger("State", 0);
        }

        //Выход
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

}
