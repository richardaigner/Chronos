using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isDead;
    private float deathTimer = 0.5f;

    public Animator animator;
    
    public void TakeDamage(int amount)
    {
        // for testing
        if (!isDead)
        {
            isDead = true;

            animator.SetBool("Dead", isDead);

            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, deathTimer);
        }
    }
}
