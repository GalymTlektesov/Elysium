using System;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    private Transform camera;

    private float pause;

    public float x = 3.2f;
    public float y = 3;


    void Awake()
    {
        camera = GetComponent<Transform>();
        pause = 0.5f;
    }

    private void Update()
    {

        if (x > 3)
        {
            x -= 0.2f;
        }
        else if (x < 2.5)
        {
            x += 0.2f;
        }

        Invoke("ForUpDate", pause);
    }


    private void ForUpDate()
    {
        if (Math.Abs(player.position.x - camera.position.x) > 3.5f)
        {
            camera.position = Vector3.MoveTowards(camera.position, new Vector3(player.position.x + x, player.position.y + y, -10), 0.2f);
        }

        if (Math.Abs(player.position.y - camera.position.y) > 2.5f)
        {
            camera.position = Vector3.MoveTowards(camera.position, new Vector3(player.position.x + x, player.position.y + y, -10), 0.2f);
        }
        pause = 0;
    }

}


