using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    public int Health;
    public Slider slider;

    public float shotDelay; // задержка удара
    private float nextshot; //время когда удар снова наностится 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Health;
        if (Health < 1)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool canShoot = Time.time > nextshot;
        if(collision.collider.tag == "Saw" && canShoot)
        {
            Health -= Random.Range(10, 25);
            nextshot = Time.time + shotDelay;
        }
    }
}
