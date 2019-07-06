using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Persona
{
    private Rigidbody2D Player;
    /// <summary>
    /// Жизни персонажа
    /// </summary>
    /// <value>The hp.</value>
    private int Hp { get; set; }

    /// <summary>
    /// Скорость персонажа
    /// </summary>
    /// <value>The speed.</value>
    private float Speed { get; set; }

    /// <summary>
    /// Сила прыжка
    /// </summary>
    /// <value>The jump force.</value>
    private float JumpForce { get; set; }

    /// <summary>
    /// Наносимый урон от нашего персонажа
    /// </summary>
    /// <value>The atack.</value>
    /// 
    public FlipStatus FlipStatus1 { get; }

    private Transform Position { get; set; }


    private SpriteRenderer Sprite { get; set; }

    // Статус нашего объекта
    internal static Status status;
    public FlipStatus flipStatus;

    private Animator CharAnimator { get; set; }

    //конструктор для глобализации
    public Persona(){}

    public Persona(int hp, 
    Transform position, Rigidbody2D player, SpriteRenderer sprite, Animator charAnimator)
    {
        Hp = hp;
        Position = position;
        Player = player;
        Sprite = sprite;
        CharAnimator = charAnimator;
    }

    //Флипание нашего объекта
    public virtual void Flip()
    {
        //Поворот в право
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Поворот нашего персонажа
            flipStatus = FlipStatus.Rigth;
            Sprite.flipX = false;
        }
        //Поворот в лево
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Поворот наншего персонажа
            flipStatus = FlipStatus.Left;
            Sprite.flipX = true;
        }
    }

    //Упраление пержонажа
    public virtual void Controller(float speed, float jumpforce)
    {
        Speed = speed;
        JumpForce = jumpforce;
        Debug.Log("Atack");
    }

}
