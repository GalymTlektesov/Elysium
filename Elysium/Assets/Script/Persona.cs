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
    private float Atack { get; set; }

    /// <summary>
    /// Защита нашего персонажа
    /// </summary>
    /// <value>The defense.</value>
    private float Defense { get; set; }
    public FlipStatus FlipStatus1 { get; }
    private Transform Position { get; set; }

    /// <summary>
    /// /Атакующий элемент нашего персонажа
    /// </summary>
    /// <value>The bullet.</value>
    private Rigidbody2D Bullet { get; set; }

    // Статус нашего объекта
    internal static Status status;
    public FlipStatus flipStatus;

    //конструктор для глобализации
    public Persona()
    {

    }

    public Persona(int hp, float speed, float jumpForce, Transform position, Rigidbody2D player, float atack, float defense, Rigidbody2D bullet)
    {
        Hp = hp;
        Speed = speed;
        JumpForce = jumpForce;
        Position = position;
        Player = player;
        Atack = atack;
        Defense = defense;
        Bullet = bullet;
    }

    //Флипание нашего объекта
    public virtual void Flip()
    {
        //Поворот в право
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Поворот нашего персонажа
            flipStatus = FlipStatus.Rigth;
            Position.localRotation = Quaternion.Euler(0, 0, 0);
        }
        //Поворот в лево
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Поворот наншего персонажа
            flipStatus = FlipStatus.Left;
            Position.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //Упраление пержонажа
    public virtual void Controller(float speed, Transform transform, float jumpforce)
    {
        Debug.Log("Atack");
    }

}
