using UnityEngine;

public class AtackCreate : MonoBehaviour
{
    public Transform player;
    public GameObject atack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.position.x - transform.position.x) < 10)
        {
            Instantiate(atack, transform.position, transform.rotation);
        }
    }
}
