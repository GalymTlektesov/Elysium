using UnityEngine;

public class EyesScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (transform.localRotation.z > 400)
        {
            speed *= -1;
        }

        if (transform.localRotation.z < 300)
        {
            speed *= -1;
        }
        transform.localRotation = Quaternion.Euler(0, 0, transform.localRotation.z + speed);
    }


    private void OnTriggerStay2D(Collider2D other)
    {

    }
}
