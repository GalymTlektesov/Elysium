using UnityEngine;

public class WallTrumpetScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.isTrigger = false;
        }
    }
}
