using System;
using UnityEngine;

public class Enemy : Persona
{
    Rigidbody2D enemy;
    Rigidbody2D player;
    new FlipStatus flipStatus;

    public Enemy()
    {
    }

    public Enemy(int hp, float speed, float jumpForce, Transform position, Rigidbody2D player, 
        float atack, float defense, Rigidbody2D bullet, Rigidbody2D enemy, SpriteRenderer sprite, Animator charAnimator) : 
        base(hp, speed, jumpForce, position, player, atack, defense, bullet, sprite, charAnimator)
    {
        this.enemy = enemy;
    }

    public override void Controller(float speed, Transform transform, float jumpforce)
    {
        if ((Math.Abs(enemy.transform.position.x - transform.position.x) < 14) && (Math.Abs(enemy.transform.position.x - transform.position.x) > 5))
        {
            enemy.position = Vector3.MoveTowards(enemy.position, new Vector3(transform.position.x, enemy.position.y, 0), 0.2f);
        }

        if ((Math.Abs(transform.position.y - enemy.position.y) > 1.5f) && (Math.Abs(enemy.transform.position.x - transform.position.x) < 14))
        {
            enemy.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    public override void Flip()
    {
        if (enemy.transform.position.x - player.position.x > 0)
        {
            //Поворот наншего персонажа
            flipStatus = FlipStatus.Rigth;
            enemy.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (enemy.transform.position.x - player.position.x < 0)
        {
            //Поворот наншего персонажа
            flipStatus = FlipStatus.Left;
            enemy.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
