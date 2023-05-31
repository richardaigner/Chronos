using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private WeaponController[] _weapons;

    public WeaponController[] Weapons { get { return _weapons; } }

    [SerializeField] private GameObject[] _weaponPrefabs;

    private void Start()
    {
        _weapons = new WeaponController[_weaponPrefabs.Length];

        for (int i = 0; i < _weaponPrefabs.Length; i++)
        {
            GameObject weapon = Instantiate(_weaponPrefabs[i], this.gameObject.transform);
            _weapons[i] = weapon.GetComponent<WeaponController>();
        }

        UpgradeWeapon(2); // start weapon
    }

    public void UpgradeWeapon(int weaponId)
    {
        _weapons[weaponId].Upgrade();
    }
}
