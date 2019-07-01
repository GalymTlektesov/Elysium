using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    public int Health;
    public Slider slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Health;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Saw")
        {
            Health -= Random.Range(10, 25);
        }
    }
}
