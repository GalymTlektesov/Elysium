using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public Transform Lazer;
    public float shotDelay;
    private float nextShot;


    private void Update()
    {
        bool canShot = Time.time > nextShot;
        if (canShot)
        {
            Lazer.localScale = transform.localScale;
            Instantiate(Lazer, transform.position, transform.rotation);
            nextShot = Time.time + shotDelay;
        }
    }

}
