using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 hitDirection = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<PlayerHealth>().GetDamage(this.GetComponent<EnemyWeapon>().Damage, hitDirection);
        }
    }
}
