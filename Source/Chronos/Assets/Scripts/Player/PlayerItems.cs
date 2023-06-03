using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private float _pickUpRange = 120;
    public float PickUpRange { get { return _pickUpRange; } set { _pickUpRange = value; } }

    private const int WEAPON_ID_RANGE = 50;
    private WeaponController[] _weapons;
    [SerializeField] private GameObject[] _weaponPrefabs;

    private EquipmentController[] _equipment;
    [SerializeField] private GameObject[] _equipmentPrefabs;

    private void Start()
    {
        _weapons = new WeaponController[_weaponPrefabs.Length];
        for (int i = 0; i < _weaponPrefabs.Length; i++)
        {
            GameObject weapon = Instantiate(_weaponPrefabs[i], this.gameObject.transform);
            _weapons[i] = weapon.GetComponent<WeaponController>();
        }

        UpgradeItem(2); // start weapon

        _equipment = new EquipmentController[_equipmentPrefabs.Length];
        for (int i = 0; i < _equipmentPrefabs.Length; i++)
        {
            GameObject equipment = Instantiate(_equipmentPrefabs[i], this.gameObject.transform);
            _equipment[i] = equipment.GetComponent<EquipmentController>();
        }
    }

    public int GetItemLevel(int itemId)
    {
        if (itemId >= 0 && itemId < WEAPON_ID_RANGE)
        {
            return GetWeapon(itemId).Level;
        }
        else
        {
            return GetEquipment(itemId).Level;
        }
    }

    public void UpgradeItem(int itemId)
    {
        if (itemId >= 0 && itemId < WEAPON_ID_RANGE)
        {
            GetWeapon(itemId).Upgrade();
        }
        else
        {
            GetEquipment(itemId).Upgrade();
        }
    }

    public void UpgradeWeaponsFromEquipment(EquipmentValues equipmentValues)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].UpgradeFromEquipment(equipmentValues);
        }
    }

    public void AddRandomWeapon()
    {
        GetWeapon(Random.Range(0, 7)).Upgrade();
    }

    public WeaponController GetWeapon(int itemId)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i].ItemId == itemId)
            {
                return _weapons[i];
            }
        }

        return null;
    }

    public EquipmentController GetEquipment(int itemId)
    {
        for (int i = 0; i < _equipment.Length; i++)
        {
            if (_equipment[i].ItemId == itemId)
            {
                return _equipment[i];
            }
        }

        return null;
    }
}
