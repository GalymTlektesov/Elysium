using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public float speed;
    Transform Trap;

    private void Start()
    {
        Trap = GetComponent<Transform>();
    }

    private void Update()
    {
        Trap.rotation = Quaternion.Euler(0, 0, Trap.rotation.z * speed * Time.deltaTime);
    }
}
