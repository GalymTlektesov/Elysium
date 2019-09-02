using UnityEngine;

public class TrapScript : MonoBehaviour
{
    float speed;
    Transform Trap;

    private TrapController Controller;

    private void Start()
    {
        Controller = GetComponentInParent<TrapController>();
        Trap = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Controller.IsTouch)
        {
            Move();
        }
        else{
            return;
        }
    }

    private void Move()
    {
        float z = Trap.rotation.z + speed * 10;
        Trap.rotation = Quaternion.Euler(0, 0, z);
        speed++;
    }
}
