using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    bool active = true;
    float attackSpeed = 1.0f; // 0.5 = 2 Attacks per second || lower is faster attack speed
    public GameObject bulletPrefab;
    float timeCounter = 1.0f;

    void Update()
    {
        if (active)
        {
            timeCounter -= Time.deltaTime;

            if (timeCounter < 0.0f)
            {
                timeCounter += attackSpeed;
                FireWeapon();
            }
        }
    }

    void FireWeapon()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    public void IncreaseAttackSpeed(float amount)
    {
        attackSpeed -= amount;
    }
}
