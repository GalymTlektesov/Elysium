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
        float z = Trap.rotation.z + speed * 10;
        Trap.rotation = Quaternion.Euler(0, 0, z);
        speed++;
    }
}
