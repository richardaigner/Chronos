using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isDead;
    private float deathTimer = 0.5f;

    public int health = 1;

    public Animator animator;
    public GameObject xpPrefab;
    
    public void GetDamage(int amount)
    {
        health -= amount;


        if (health <= 0 && !isDead)
        {
            Remove();
        }
    }

    private void Remove()
    {
        isDead = true;

        animator.SetBool("Dead", isDead);
        Instantiate(xpPrefab, transform.position, Quaternion.identity);

        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, deathTimer);
    }
}
