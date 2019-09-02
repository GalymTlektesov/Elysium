using UnityEngine;

public class destroyCommand : MonoBehaviour
{
    public float TimeDeath;
    void Start()
    {
        Destroy(gameObject, TimeDeath);
    }
}
