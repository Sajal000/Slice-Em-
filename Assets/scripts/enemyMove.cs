using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed, checkRadius, attackRadius;
    public bool shouldRotate;
    private bool isInChaseRange, isInAttackRange;
    public LayerMask whatIsPlayer;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    private Vector3 dir;
    public LayerMask playerLayers;

    public Transform[] attackPoints;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int attackDamage = 10; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (shouldRotate)
        {
            anim.SetFloat("X",dir.x);
            anim.SetFloat("Y", dir.y);
        }

        if (Time.time >= nextAttackTime)
        {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }

    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }

        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
            
        }

    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        foreach (Transform point in attackPoints)
        {

            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(point.position, attackRadius, playerLayers);
            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<playerHealth>().TakeDamage(attackDamage);
            }

        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    private void OnDrawGizmosSelected()
    {

        foreach (Transform point in attackPoints)
        {
            if (point == null)
                continue;

            Gizmos.DrawWireSphere(point.position, attackRadius);

        }
    }
}
