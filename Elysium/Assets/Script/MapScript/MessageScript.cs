using UnityEngine;

public class MessageScript : MonoBehaviour
{
    private SaveScript Save;

    private void Start() 
    {
        Save = GetComponentInParent<SaveScript>();
    }

    private void Update() 
    {
        if(Save.Exit)
        {
            Destroy(gameObject);
        }
    }
}
