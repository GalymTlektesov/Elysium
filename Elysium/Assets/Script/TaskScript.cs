using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskScript : MonoBehaviour
{
    public static int Kill;
    public int task;

    // Update is called once per frame
    void Update()
    {
        if (Kill == task)
        {
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
    }
}
