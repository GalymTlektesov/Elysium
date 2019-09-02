using UnityEngine;

public class Persona
{
    /// <summary>
    /// Физический объект нашего персонажа
    /// </summary>
    protected Rigidbody2D Player;

    /// <summary>
    /// Скорость персонажа
    /// </summary>
    /// <value>The speed.</value>
    protected float Speed
    {
        get => Speed;
        set
        {
            if (Speed > 20)
            {
                Speed = 20;
            }
            if (Speed < 0.1f)
            {
                Speed = 0.1f;
            }
            else
            {
                Speed = value;
            }
        }
    }

    /// <summary>
    /// Сила прыжка
    /// </summary>
    /// <value>The jump force.</value>
    protected float JumpForce
    {
        get => JumpForce;
        set
        {
            if (JumpForce > 25)
            {
                JumpForce = 25;
            }
            if (JumpForce < 5f)
            {
                JumpForce = 5f;
            }
            else
            {
                JumpForce = value;
            }
        }
    }

    /// <summary>
    /// Позиция нашего персонажа
    /// </summary>
    protected Transform Position { get;}

    public int animNumber;

    //конструктор для глобализации
    public Persona() { }

    public Persona( 
    Transform position, Rigidbody2D player)
    {
        Position = position;
        Player = player;
    }

    //Флипание нашего объекта
    public virtual void Flip()
    {
        //Поворот в право
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Поворот нашего персонажа
        }
        //Поворот в лево
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Поворот наншего персонажа
        }
    }

    //Упраление пержонажа
    public virtual void Controller(float speed, float jumpforce)
    {
        Speed = speed;
        JumpForce = jumpforce;
    }

}
