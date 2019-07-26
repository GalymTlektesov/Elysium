using System;
using UnityEngine;

public class Enemy : Persona
{
    Rigidbody2D enemy;
    Rigidbody2D player;
    private Animator EnemyAnim;
    private string NameAnim { get; set; }
    public bool Atack;

    public Enemy() { }

    public Enemy(Transform position, Rigidbody2D player, 
        Rigidbody2D enemy, SpriteRenderer sprite, Animator charAnimator) : 
        base(position, player, sprite, charAnimator)
    {
        this.enemy = enemy;
        this.player = player;
    }
    
    public Enemy(Animator enemyAnim, string nameAnim)
    {
        NameAnim = nameAnim;
        EnemyAnim = enemyAnim;
    }

    public override void Controller(float speed, float jumpforce)
    {
        bool motion;
        motion = false;
        //Прыжок
        if (player.transform.position.y - enemy.position.y > 1.5f && Math.Abs(enemy.transform.position.x - player.transform.position.x) < 14
                                                                      && player.transform.position.y - enemy.position.y < 3)
        {
            enemy.AddForce(enemy.transform.up * jumpforce, ForceMode2D.Impulse);
        }
        // Преследования
        if (Math.Abs(enemy.transform.position.x - player.transform.position.x) < 14 && Math.Abs(enemy.transform.position.x - player.transform.position.x) > 12)
        {
            var position = enemy.position;
            enemy.position = Vector2.MoveTowards(position, new Vector2(player.transform.position.x, position.y), speed);
            EnemyAnim.SetInteger(NameAnim, 2);
            motion = true;
            Debug.Log("Преследование");
        }

        if (Atack)
        {
            EnemyAnim.SetInteger(NameAnim, 1);
            motion = true;
            Debug.Log("Atack");
        }
        if (!motion)
        {
            EnemyAnim.SetInteger(NameAnim, 0);
            Debug.Log("Ничего");
        }
        //Отскок в право
        /* if (((enemy.transform.position.x - player.transform.position.x) < 2) && (Math.Abs(enemy.transform.position.y - player.transform.position.y) < 1))
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(enemy.position.x + 2, enemy.position.y), speed);
        }
        //Отскок в лево
        if (((player.transform.position.x - enemy.transform.position.x) < 2) && (Math.Abs(enemy.transform.position.y - player.transform.position.y) < 1))
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(enemy.position.x - 2, enemy.position.y), speed);
        }*/
    }

    public override void Flip()
    {
        if (enemy.transform.position.x - player.position.x > 0)
        {
            //Поворот наншего персонажа в лево
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (enemy.transform.position.x - player.position.x < 0)
        {
            //Поворот наншего персонажа в право
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
