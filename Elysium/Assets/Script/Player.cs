using UnityEngine;

public class Player : Persona
{
    public Rigidbody2D player;
    private int HP { get; set; }

    public Player()// конструктор для глобальной переменной
    {

    }

    public Player(int hp, float speed, float jumpForce, Transform position, Rigidbody2D player, float atack, float defense, Rigidbody2D bullet) : 
        base(hp, speed, jumpForce, position, player, atack, defense, bullet)
    {
        HP = hp;
        this.player = player;
    }
    
    //Управления наш героя
    public override void Controller(float speed, Transform transform, float jumpforce)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// горизонтальное перемещение

        player.velocity = new Vector2(moveHorizontal * speed, player.velocity.y); // движение и скорость движение

        if (!Input.GetKeyDown(KeyCode.Space) || status != Status.Earch)// прыжок
        {
            return;
        }
        player.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

}
