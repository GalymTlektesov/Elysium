using UnityEngine;

public class TrapController : MonoBehaviour
{
    Transform Trap;

    private void Awake()
    {
        Trap = GetComponent<Transform>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Trap.position = Vector3.MoveTowards(Trap.position, new Vector3(Trap.position.x, -1.33f, 0), 3);
    }

    //Проверка на прекращения столкновения двух объктов
    private void OnTriggerExit2D(Collider2D collision)
    {
        Trap.position = Vector3.MoveTowards(Trap.position, new Vector3(Trap.position.x, -2.84f, 0), 3);
    }
}
