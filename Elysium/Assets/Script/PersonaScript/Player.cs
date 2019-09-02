using UnityEngine;

public class Player : Persona
{
    private DirectionPunch punch;

    private DirectionPunch GetPunch()
    {
        return punch;
    }

    private void SetPunch(DirectionPunch value)
    {
        punch = value;
    }

    public Player() { }


    public Player( Transform position, Rigidbody2D player, DirectionPunch punch) : 
        base(position, player)
    {
        Player = player;
        SetPunch(punch);
    }

    public override void Flip()
    {
        //Поворот в право
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Поворот нашего персонажа
            SetPunch(DirectionPunch.rigth);
            Position.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Поворот в лево
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Поворот наншего персонажа
            Position.rotation = Quaternion.Euler(0, 180, 0);
            SetPunch(DirectionPunch.left);
        }
    }


    //Управления наш героя
    public override void Controller(float speed, float jumpforce)
    {
        Speed = speed;

        JumpForce = jumpforce;

        if (Input.GetButton("Horizontal"))
        {
            Move(Speed);
            animNumber = 1;
        }
        // Прыжок
        if (Input.GetButton("Jump"))
        {
            //charAnimator.SetTrigger("Jump");
            Player.AddForce(Player.transform.up * JumpForce, ForceMode2D.Impulse);
            animNumber = 2;
        }


        // Ничего 
        if (!Input.anyKey)
        {
            //charAnimator.ResetTrigger("Jump");
            animNumber = 0;
        }
    }



    private void Move(float speed)
    {
        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        var position = Position.position;
        position = Vector3.MoveTowards(position, position + tempVector, speed * Time.deltaTime);
        Position.position = position;
    }

}
