using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public Transform Lazer;
    void Start()
    {
        Lazer = GetComponent<Transform>();
    }

    private void Update()
    {
        StartCoroutine(LazerSpawn());
    }

    IEnumerator LazerSpawn()
    {
        Instantiate(Lazer, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4);
    }
    
}
