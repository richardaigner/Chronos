using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttack : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;

    public void IncreaseAttackSpeed()
    {
        _playerWeapon.IncreaseAttackSpeed(0.05f);
    }
}
