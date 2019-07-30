using System;
using UnityEngine;

public class unstableScript : MonoBehaviour
{
    public Transform Player;

    private Rigidbody2D phisics;

    private void Start()
    {
        phisics = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Math.Abs(Player.position.x - transform.position.x) < 23 &&
            Math.Abs(Player.position.y - transform.position.y) < 10)
        {
            phisics.simulated = true;
        }
    }
}
