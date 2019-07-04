using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCommand : MonoBehaviour
{
    public float TimeDeath;
    void Start()
    {
        Destroy(gameObject, TimeDeath);
    }
}
