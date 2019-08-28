using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public GameObject textSave;
    public GameObject explosion;
    public Camera camera;
    internal bool Exit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Exit = false;
            Instantiate(textSave, new Vector3(camera.transform.position.x, camera.transform.position.y, 0), Quaternion.identity, transform);
        }        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.F))
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other) 
    {
        Exit = true;
    }
}
