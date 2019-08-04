using UnityEngine;

public class PunchScript : MonoBehaviour
{
    private Animator punchAnim;

    private void Awake()
    {
        punchAnim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        punchAnim.SetBool("Collision", true);
    }
}
