using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsPlayerScipt : MonoBehaviour
{
    public СondPlayer condition;


    private void OnTriggerStay2D(Collider2D collision)
    {
        condition = СondPlayer.Earch;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        condition = СondPlayer.AirOne;
    }
}
