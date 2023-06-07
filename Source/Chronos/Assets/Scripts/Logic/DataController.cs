using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private int _levelProgress = 0;
    public int LevelProgress { get { return _levelProgress; } set { _levelProgress = value; } }

    private int _keys = 0;
    public int Keys { get { return _keys; } set { _keys = value; } }

    private int _damageLevel = 0;
    private float _damageMultiplierPerLevel = 0.05f;
    
    private int _attackSpeedLevel = 0;
    private float _attackSpeedMultiplierPerLevel = 0.05f;

    private int _moveSpeedLevel = 0;
    private float _moveSpeedMultiplierPerLevel = 0.05f;

    private void Start()
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

    public void SaveDate()
    {
        PlayerPrefs.SetInt("LevelProgress", _levelProgress);
        PlayerPrefs.SetInt("Keys", _keys);
        PlayerPrefs.SetInt("DamageLevel", _damageLevel);
        PlayerPrefs.SetInt("AttackSpeedLevel", _attackSpeedLevel);
        PlayerPrefs.SetInt("MoveSpeedLevel", _moveSpeedLevel);
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("LevelProgress", _levelProgress);
        PlayerPrefs.SetInt("Keys", 0);
        PlayerPrefs.SetInt("DamageLevel", 0);
        PlayerPrefs.SetInt("AttackSpeedLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedLevel", 0);
        LoadData();
    }

    public float GetDamageMultiplier()
    {
        float damageMultiplier = 0;

        for (int i = 0; i < _damageLevel; i++)
        {
            damageMultiplier += _damageMultiplierPerLevel;
        }

        return damageMultiplier;
    }

    public float GetAttackSpeedMultiplier()
    {
        float attackSpeedMultiplier = 1;

        for (int i = 0; i < _attackSpeedLevel; i++)
        {
            attackSpeedMultiplier -= _attackSpeedMultiplierPerLevel;
        }

        return attackSpeedMultiplier;
    }

    public float GetMoveSpeedMultiplier()
    {
        float moveSpeedMultiplier = 0;

        for (int i = 0; i < _moveSpeedLevel; i++)
        {
            moveSpeedMultiplier += _moveSpeedMultiplierPerLevel;
        }

        return moveSpeedMultiplier;
    }
}
