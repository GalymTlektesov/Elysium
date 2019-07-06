using UnityEngine;

public class Player : Persona
{
    public Rigidbody2D player;
    public int HP { get; set; }
    private Animator CharAnimator;

    public Player()// конструктор для глобальной переменной
    {

    }

    public Player(int hp, Transform position, Rigidbody2D player, 
        SpriteRenderer sprite, Animator charAnimator) : 
        base(hp, position, player, sprite, charAnimator)
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
    public override void Controller(float speed, float jumpforce)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// горизонтальное перемещение

        player.velocity = new Vector2(moveHorizontal * speed, player.velocity.y); // движение и скорость движение

        if (Input.GetKeyDown(KeyCode.Space) || status != Status.Earch)// прыжок
        {
            player.AddForce(player.transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

}
