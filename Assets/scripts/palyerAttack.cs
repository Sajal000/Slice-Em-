using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyerAttack : MonoBehaviour
{ 
    public Animator animator;
    public Transform[] attackPoints;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    AudioSource src;
    public AudioClip swing;

    void Start()
    {
        src = GetComponent<AudioSource>(); 
    }


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                src.PlayOneShot(swing);
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        foreach (Transform point in attackPoints)
        {

            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(point.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemy)
            {
                Debug.Log("We hit" + enemy.name);
                enemy.GetComponent<enemyAttack>().TakeDamage(attackDamage);
            }

        }
    }

    private void OnDrawGizmosSelected()
    {

        foreach (Transform point in attackPoints)
        {
            if (point == null)
                continue;

            Gizmos.DrawWireSphere(point.position, attackRange);

        }
    }




}
