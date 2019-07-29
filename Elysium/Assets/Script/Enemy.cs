using System;
using UnityEngine;

public class Enemy : Persona
{
    Rigidbody2D enemy;
    Rigidbody2D player;
    private Animator EnemyAnim;
    private string NameAnim { get; set; }
    public bool Atack;
    
    private bool motion;

    public int animNumber;

    public Enemy() { }

    public Enemy(Transform position, Rigidbody2D player, 
        Rigidbody2D enemy, SpriteRenderer sprite, Animator charAnimator) : 
        base(position, player, sprite, charAnimator)
    {
        this.enemy = enemy;
        this.player = player;
    }

    public override void Controller(float speed, float jumpforce)
    {
        //Проверка движения
        motion = false;
        //Координаты врага
        var enemyX = enemy.transform.position.x;
        var enemyY = enemy.position.y;
        
        //Наши координаты
        var position1 = player.transform.position;
        var playerY = position1.y;
        var playerX = position1.x;
        
        //Прыжок
        if (playerY - enemyY > 1.5f && Math.Abs(enemyX - playerX) < 14 && playerY - enemyY < 3)
        {
            enemy.AddForce(enemy.transform.up * jumpforce, ForceMode2D.Impulse);
        }
        // Преследования
        if (Math.Abs(enemyX - playerX) > 12 && Math.Abs(enemyX - playerX) < 14)
        {
            var position = enemy.position;
            enemy.position = Vector2.MoveTowards(position, new Vector2(playerX, position.y), speed);
            animNumber = 2;
            motion = true;
        }

        if (Atack)
        {
            animNumber = 1;
            motion = true;
        }
        if (!motion)
        {
            animNumber = 0;
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
