using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    public Camera camera;
    void Start()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
    }
}
