using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float min;
    public float max;

    public float Damage()
    {
        return Random.Range(min, max);
    }
}
