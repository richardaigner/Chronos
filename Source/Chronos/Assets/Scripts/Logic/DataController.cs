using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private int _levelProgress = 0;
    public int LevelProgress { get { return _levelProgress; } set { _levelProgress = value; } }

    private int _keys = 10;
    public int Keys { get { return _keys; } set { _keys = value; } }

    private int _damageLevel = 0;
    private float _damageMultiplierPerLevel = 0.4f;
    
    private int _attackSpeedLevel = 0;
    private float _attackSpeedMultiplierPerLevel = 0.1f;

    private int _moveSpeedLevel = 0;
    private float _moveSpeedMultiplierPerLevel = 0.1f;

    private void Awake()
    {
        LoadData();
    }

    public void LoadData()
    {
        _levelProgress = PlayerPrefs.GetInt("LevelProgress", 0);
        _keys = PlayerPrefs.GetInt("Keys", 0);
        _damageLevel = PlayerPrefs.GetInt("DamageLevel", 0);
        _attackSpeedLevel = PlayerPrefs.GetInt("AttackSpeedLevel", 0);
        _moveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("LevelProgress", _levelProgress);
        PlayerPrefs.SetInt("Keys", _keys);
        PlayerPrefs.SetInt("DamageLevel", _damageLevel);
        PlayerPrefs.SetInt("AttackSpeedLevel", _attackSpeedLevel);
        PlayerPrefs.SetInt("MoveSpeedLevel", _moveSpeedLevel);
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("LevelProgress", 0);
        PlayerPrefs.SetInt("Keys", 0);
        PlayerPrefs.SetInt("DamageLevel", 0);
        PlayerPrefs.SetInt("AttackSpeedLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedLevel", 0);
        LoadData();
    }

    public int GetUpgradeLevel(string name)
    {
        if (name == "Damage")
        {
            return _damageLevel;
        }
        else if (name == "AttackSpeed")
        {
            return _attackSpeedLevel;
        }
        else if (name == "MoveSpeed")
        {
            return _moveSpeedLevel;
        }

        return 0;
    }

    public void SetUpgradeLevel(string name, int value)
    {
        if (name == "Damage")
        {
            _damageLevel = value;
        }
        else if (name == "AttackSpeed")
        {
            _attackSpeedLevel = value;
        }
        else if (name == "MoveSpeed")
        {
            _moveSpeedLevel = value;
        }
    }

    public float GetUpgradeMultiplier(string name)
    {
        if (name == "Damage")
        {
            float damageMultiplier = 1;
            for (int i = 0; i < _damageLevel; i++)
            {
                damageMultiplier += _damageMultiplierPerLevel;
            }
            return damageMultiplier;
        }
        else if (name == "AttackSpeed")
        {
            float attackSpeedMultiplier = 1;

            for (int i = 0; i < _attackSpeedLevel; i++)
            {
                attackSpeedMultiplier -= _attackSpeedMultiplierPerLevel;
            }

            return attackSpeedMultiplier;
        }
        else if (name == "MoveSpeed")
        {
            float moveSpeedMultiplier = 1;

            for (int i = 0; i < _moveSpeedLevel; i++)
            {
                moveSpeedMultiplier += _moveSpeedMultiplierPerLevel;
            }

            return moveSpeedMultiplier;
        }

        return 1;
    }
}
