using System;
using UnityEngine;

public class Atack
{
    /// <summary>
    /// Скорость движения нашей пули
    /// </summary>
    /// <value>The speed.</value>
    private float Speed { get; set; }

    /// <summary>
    /// Пресонаж который стреляет
    /// </summary>
    /// <value>The persona.</value>
    private Persona Persona { get; set; }

    private Rigidbody2D Bullet { get; set; }

    public Atack()
    {

    }

    public Atack(float speed, Persona persona, Rigidbody2D bullet)
    {
        Speed = speed;
        Persona = persona;
        Bullet = bullet;
    }

    public virtual void FlipAtatck()
    {
        if (Persona.flipStatus == FlipStatus.Rigth)
        {
            //Поворот и движение нашего атакущего объекта 
            Bullet.velocity = Vector3.right * Speed;
            Bullet.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Persona.flipStatus == FlipStatus.Left)
        {
            //Поворот и движение нашего атакущего объекта 
            Bullet.velocity = Vector3.left * Speed;
            Bullet.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else { return; }

    }

}
