using UnityEngine;

public class Player : Persona
{
    public Rigidbody2D player;
    public int HP { get; set; }
    private Animator CharAnimator;

    public Player()// конструктор для глобальной переменной
    {

    }

    public Player(int hp, float speed, float jumpForce, Transform position, Rigidbody2D player, 
        SpriteRenderer sprite, Animator charAnimator) : 
        base(hp, speed, jumpForce, position, player, sprite, charAnimator)
    {
        HP = hp;
        this.player = player;
        CharAnimator = charAnimator;
    }

    public int Hp(int hp)
    {
        HP = hp;
        return HP;
    }
    
    //Управления наш героя
    public override void Controller(float speed, Transform transform, float jumpforce)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// горизонтальное перемещение

        player.velocity = new Vector2(moveHorizontal * speed, player.velocity.y); // движение и скорость движение

        if (Input.GetKeyDown(KeyCode.Space) || status != Status.Earch)// прыжок
        {
            player.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

}
