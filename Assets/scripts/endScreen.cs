using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");
        }
    }
}
