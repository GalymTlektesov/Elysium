using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    public int Health = 100;

    void Update()
    {
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "punch")
        {
            Health -= Random.Range(20, 35);
        }
    }
}
