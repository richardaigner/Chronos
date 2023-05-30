using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponPrefabs;

    private void Start()
    {
        UpgradeWeapon(0);
    }

    public void UpgradeWeapon(int weaponId)
    {
        Instantiate(_weaponPrefabs[weaponId], this.gameObject.transform);
    }
}
