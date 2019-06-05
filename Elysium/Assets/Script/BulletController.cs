using UnityEngine;


public class BulletController : MonoBehaviour
{
    public float speed;
    public GameObject Pesona;

    private void Start()
    {
        Destroy(gameObject, 12);
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
