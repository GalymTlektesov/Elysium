using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackEnemy : MonoBehaviour
{
    Player Hero;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
