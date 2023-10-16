using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(enemies.Length);
            
            if (enemies.Length == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
    }
}
