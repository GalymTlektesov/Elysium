using UnityEngine;

public class MessageScript : MonoBehaviour
{
    public SaveScript Save;

    private void Update()
    {
        if (Save.Exit)
        {
            Destroy(gameObject);
        }
    }
}
