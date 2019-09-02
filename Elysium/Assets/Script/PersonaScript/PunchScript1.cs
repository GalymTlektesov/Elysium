using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript1 : MonoBehaviour
{
    [SerializeField]
    public GameObject punchAnim;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(punchAnim, transform.position, Quaternion.identity);
    }
}
