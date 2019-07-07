using UnityEngine;

public class LegsScript : MonoBehaviour
{
    public Сondition condition;


    private void OnTriggerStay2D(Collider2D collision)
    {
        condition = Сondition.Earch;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        condition = Сondition.Air;
    }
}
