using System;
using UnityEngine;

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

    private Transform Position { get; set; }
    // Статус нашего объекта
    internal static Status status;

    //конструктор для глобализации
    public Persona()
    {

    }

    public Persona(int hp, float speed, float jumpForce, Transform position, Rigidbody2D player, float atack, float defense)
    {
        Hp = hp;
        Speed = speed;
        JumpForce = jumpForce;
        Position = position;
        Player = player;
        Atack = atack;
        Defense = defense;

    }

    //Флипание нашего объекта
    public virtual void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Position.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Position.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //Упраление пержонажа
    public virtual void Controller(float speed, Transform transform, float jumpforce)
    {
        Debug.Log("Atack");
    }

}
