using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Persona
{
    private Rigidbody2D Player;
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

    private Transform Position { get; set; }


    private SpriteRenderer Sprite { get; set; }

    private Animator CharAnimator { get; set; }

    //конструктор для глобализации
    public Persona(){}

    public Persona( 
    Transform position, Rigidbody2D player, SpriteRenderer sprite)
    {
        Position = position;
        Player = player;
        Sprite = sprite;
    }

    //Флипание нашего объекта
    public virtual void Flip()
    {
        //Поворот в право
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Поворот нашего персонажа
            Sprite.flipX = false;
        }
        //Поворот в лево
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Поворот наншего персонажа
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
