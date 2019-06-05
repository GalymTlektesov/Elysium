using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    public Transform camera;

    public float x = 3.2f;
    public float y = 3;



    private void Update()
    {

        if (x > 3)
        {
            x -= 0.2f;
        }
        else if (x < 0)
        {
            x += 0.2f;
        }

        camera.position = new Vector3(player.position.x + x, player.position.y +
            y, -10);

    }

}
