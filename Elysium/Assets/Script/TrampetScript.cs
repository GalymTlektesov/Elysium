using UnityEngine;

public class TrampetScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    

    public Sprite[] TrampetSprite = new Sprite[2];
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("terain"))
        {
            return;
        }
        else if (other.CompareTag("wall"))
        {
            return;
        }
        else if (other.CompareTag("trumpet"))
        {
            return;
        }
        else
        {
            gameObject.tag = "trumpet";
        }

        if (other.CompareTag("Player"))
        {
            sprite.sortingOrder = -1;
            sprite.sprite = TrampetSprite[1];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.tag = "dont_trumpet";
        if (other.CompareTag("Player"))
        {
            sprite.sortingOrder = 3;
            sprite.sprite = TrampetSprite[0];
        }
    }
}
