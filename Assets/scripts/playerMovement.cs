using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    
    Vector2 velocity;

    void Update()
    {
        velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        if (velocity != Vector2.zero)
        {
            UpdateMovemnet();

            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void UpdateMovemnet()
    {
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }


}
