using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Stage1");
    }

    void Start()
    {

    }

    void Update()
    {
        Screen.fullScreen = false;

        if (Input.GetKeyDown(KeyCode.Space))
            ChangeScene();
    }
}
