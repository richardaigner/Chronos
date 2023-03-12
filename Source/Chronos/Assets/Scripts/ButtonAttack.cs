using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttack : MonoBehaviour
{
    public PlayerWeapon playerWeapon;

    public void IncreaseAttackSpeed()
    {
        playerWeapon.IncreaseAttackSpeed(0.05f);
    }

}
