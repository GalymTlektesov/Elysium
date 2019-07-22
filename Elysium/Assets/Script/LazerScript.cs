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
            Instantiate(Lazer, transform.position, Quaternion.identity);
            nextShot = Time.time + shotDelay;
        }
    }

}
