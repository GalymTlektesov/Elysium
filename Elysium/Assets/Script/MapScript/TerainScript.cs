using UnityEngine;

public class TerainScript : MonoBehaviour
{
    private Collider2D _tarainColl;

    private bool _playerTouch;
    private bool _trumpetTouch;

    private void Start()
    {
        _tarainColl = GetComponent<Collider2D>();
    }
    
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("trumpet"))
        {
            _tarainColl.isTrigger = true;
        }
        if (other.CompareTag("dont_trumpet"))
        {
            _tarainColl.isTrigger = false;
        }
    }
}
