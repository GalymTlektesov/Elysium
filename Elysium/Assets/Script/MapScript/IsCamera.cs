using UnityEngine;

public class IsCamera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCamera"))
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("MainCamera"))
        {
            gameObject.SetActive(false);
        }
    }
}
