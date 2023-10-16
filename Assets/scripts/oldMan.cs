using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldMan : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer speechBubbleRenderer;
    void Start()
    {
        speechBubbleRenderer = GetComponent<SpriteRenderer>();
        speechBubbleRenderer.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speechBubbleRenderer.enabled = true;
            player = collision.gameObject.GetComponent<Transform>();
        }

        


    }


}
