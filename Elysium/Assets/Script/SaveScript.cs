using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public GameObject textSave;
    public GameObject explosion;
    public Camera camera;

    internal bool Exit;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(textSave, new Vector3(camera.transform.position.x, camera.transform.position.y, 0), Quaternion.identity);
            if(Input.GetKey(KeyCode.F))
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
    }
}
