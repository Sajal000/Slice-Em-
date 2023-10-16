using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public float  maxHealth = 100;
    public float currentHealth;
    public TMP_Text lifeText;
    
    void Start()
    {
        currentHealth = maxHealth;
        lifeText.text = "Lives: " + playerLife.lives.ToString();
    }

    private bool isTakingDamage = false; 
    public void TakeDamage (int damage)
    {
        if (isTakingDamage)
            return;

        isTakingDamage = true; 
        currentHealth -= damage;
   

        if (currentHealth <= 0)
        {
            checkDie();
        }

        StartCoroutine(ResetDamageFlag());
       
    }

    IEnumerator ResetDamageFlag()
    {
        yield return new WaitForSeconds(1.0f); 
        isTakingDamage = false;
    }



    void checkDie()
    {
        playerLife.lives--;
        
        if (playerLife.lives <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("youLose");
        }
        else
        {
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OldMan")
        {
            currentHealth = maxHealth;
            if(playerLife.lives < 3)
            {
                playerLife.lives++;
            }
        }

        if (collision.gameObject.tag == "Water")
        {
            checkDie();
        }
    }
}
