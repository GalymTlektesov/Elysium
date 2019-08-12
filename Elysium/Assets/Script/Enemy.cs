using System;
using UnityEngine;

public class Enemy : Persona
{
    Rigidbody2D enemy;

    private Animator EnemyAnim;

    public bool Atack;
    
    private bool motion;

    public Enemy() { }

    public Enemy(Transform position, Rigidbody2D player, 
        Rigidbody2D enemy) : 
        base(position, player)
    {
        this.enemy = enemy;
    }



    public override void Controller(float speed, float jumpforce)
    {
        //Проверка движения
        motion = false;
        //Координаты врага
        var enemyX = enemy.transform.position.x;
        var enemyY = enemy.position.y;
        
        //Наши координаты
        var position1 = Player.transform.position;
        var playerY = position1.y;
        var playerX = position1.x;
        
        //Прыжок
        if (playerY - enemyY > 1.5f && Math.Abs(enemyX - playerX) < 14 && playerY - enemyY < 2.5f)
        {
            enemy.AddForce(enemy.transform.up * jumpforce, ForceMode2D.Impulse);
        }
        // Преследования
        if (Math.Abs(enemyX - playerX) > 12 && Math.Abs(enemyX - playerX) < 14 && (Math.Abs(enemyY - playerY)) < 2.5f)
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
    }

    public override void Flip()
    {
        //Координаты врага
        var enemyX = enemy.transform.position.x;
        var enemyY = enemy.position.y;
        
        //Наши координаты
        var position1 = Player.transform.position;
        var playerY = position1.y;
        var playerX = position1.x;
        
        if (enemyX - playerX > 0 && (Math.Abs(enemyY - playerY)) < 2.5f)
        {
            //Поворот наншего персонажа в лево
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (enemyX - playerX < 0 && (Math.Abs(enemyY - playerY)) < 2.5f)
        {
            //Поворот наншего персонажа в право
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
