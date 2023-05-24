using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int _level = 1;
    private int _xp = 0;
    private int _xpNeedForLevel = 3; // default 10 -> for testing set to 3
    private float _xpNeedIncreaseFactor = 1.2f;

    [SerializeField] private GameObject _uiXpProgressBar;
    [SerializeField] private GameObject _uiUpgradeSelect;

    public void AddXp(int value)
    {
        _xp += value;

        if (_xp >= _xpNeedForLevel)
        {
            LevelUp();
        }

        _uiXpProgressBar.GetComponent<XpProgressBar>().UpdateBar(_xp, _xpNeedForLevel);
    }

    private void LevelUp()
    {
        _level++;
        _xp -= _xpNeedForLevel;
        _xpNeedForLevel = (int)(_xpNeedForLevel * _xpNeedIncreaseFactor);
        ShowUpgradeWindow();
    }

    private void ShowUpgradeWindow()
    {
        PauseGames();
        _uiUpgradeSelect.SetActive(true);
    }

    private void PauseGames()
    {
        Time.timeScale = 0;
    }
}
