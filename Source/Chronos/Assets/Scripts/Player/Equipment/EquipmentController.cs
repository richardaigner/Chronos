using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] private int _itemId = 0;
    public int ItemId { get { return _itemId; } }

    private int _level = 0;
    public int Level { get { return _level; } }

    EquipmentValues[] _equipmentValues;
    GameObject _player;

    private void Start()
    {
        _equipmentValues = EquipmentLevelValues.GetEquipmentValues(_itemId);
        _player = GameObject.Find("Player");
    }

    public void Upgrade()
    {
        if (_level == 0)
        {
            Activate();
        }

        _level++;

        if (_equipmentValues != null && _level == _equipmentValues.Length - 1)
        {
            GameObject.Find("UpgradeSelect").GetComponent<UpgradeSelect>().RemovePossibleUpgrade(_itemId);
        }

        AddValuesToPlayer();
    }

    private void Activate()
    {
        // TODO after activaten create a icon to show that the weapon is equipt
    }

    private void AddValuesToPlayer()
    {
        _player.GetComponent<PlayerHealth>().IncreaseMaxHealth(_equipmentValues[_level].Health);
        _player.GetComponent<PlayerMovement>().MoveSpeed += _equipmentValues[_level].MoveSpeed;
        _player.GetComponent<PlayerMovement>().DashForce += _equipmentValues[_level].DashForce;
        _player.GetComponent<PlayerHealth>().RegenerationValue += _equipmentValues[_level].RegenerationValue;
        _player.GetComponent<PlayerItems>().PickUpRange += _equipmentValues[_level].PickUpRange;
        _player.GetComponent<PlayerItems>().UpgradeWeaponsFromEquipment(_equipmentValues[_level]);
    }
}
