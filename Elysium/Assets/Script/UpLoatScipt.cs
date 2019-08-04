using System;
using UnityEngine;

public class UpLoatScipt : MonoBehaviour
{
    private Rigidbody2D terain;

    private float yMin;
    private float yMax;

    public float speed;

    private void Start()
    {
        terain = GetComponent<Rigidbody2D>();

        yMin = terain.position.y;
        yMax = yMin + 0.3f;
    }

    void Update()
    {
        var terPosX = terain.position.y;
        if (Math.Abs(terPosX - yMin) < 0.5f)
        {
            terain.velocity = Vector2.up * speed;
        }

        if (Math.Abs(terPosX - yMax) < 0.5f)
        {
            terain.velocity = Vector2.down * speed;
        }
    }
}
