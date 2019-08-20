using UnityEngine;

public class MineScript : MonoBehaviour
{
    private Animator mineAnim;
    public bool activation;

    void Awake()
    {
        activation = false;
        mineAnim = GetComponent<Animator>();
    }

    void Update()
    {
        mineAnim.SetBool("Activation", activation);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        activation = true;
        Destroy(gameObject, 0.5f);
    }
}
