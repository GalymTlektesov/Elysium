using UnityEngine;

public class TrapController : MonoBehaviour
{
    Transform Trap;
    public float yStay;
    public float yExit;
    private void Awake()
    {
        Trap = GetComponent<Transform>();
        yExit = Trap.position.y;
        if (Trap.rotation.z == 0)
        {
            yStay = yExit + 1.5f;
        }
        if (Trap.rotation.z == 180)
        {
            yStay = yExit - 1.5f;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Trap.position = Vector2.MoveTowards(Trap.position, new Vector2(Trap.position.x, yStay), 3);
    }

    //Проверка на прекращения столкновения двух объктов
    private void OnTriggerExit2D(Collider2D collision)
    {
        Trap.position = Vector2.MoveTowards(Trap.position, new Vector2(Trap.position.x, yExit), 3);
    }
}
