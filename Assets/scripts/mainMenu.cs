using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{

    private void Start()
    {
        playerLife.lives = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("scene1");
        }
    }
}
