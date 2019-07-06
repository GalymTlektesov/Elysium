using System;
using UnityEngine;

public class Enemy : Persona
{
    Rigidbody2D enemy;
    Rigidbody2D player;
    new FlipStatus flipStatus;
    new readonly Status status;

    public Enemy()
    {
    }

    public Enemy(int hp, Transform position, Rigidbody2D player, 
        Rigidbody2D enemy, SpriteRenderer sprite, Animator charAnimator) : 
        base(hp, position, player, sprite, charAnimator)
    {
        this.enemy = enemy;
        this.player = player;
    }

    public Enemy(Rigidbody2D enemy)
    {
        this.enemy = enemy;
    }

    public override void Controller(float speed, float jumpforce)
    {
        if ((Math.Abs(enemy.transform.position.x - player.transform.position.x) < 14) && (Math.Abs(enemy.transform.position.x - player.transform.position.x) > 5))
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(player.transform.position.x, enemy.position.y), speed);
        }

        if ((Math.Abs(player.transform.position.y - enemy.position.y) > 1.5f) && (Math.Abs(enemy.transform.position.x - player.transform.position.x) < 14))
        {
            enemy.AddForce(enemy.transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    public override void Flip()
    {
        if (enemy.transform.position.x - player.position.x > 0)
        {
            //Поворот наншего персонажа в лево
            flipStatus = FlipStatus.Rigth;
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (enemy.transform.position.x - player.position.x < 0)
        {
            //Поворот наншего персонажа в право
            flipStatus = FlipStatus.Left;
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
