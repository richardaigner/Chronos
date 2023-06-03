using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int _level = 1;
    private int _currentXp = 0;
    private int _levelUpXp = 20;
    private float _levelUpXpIncreaseFactor = 1.2f;

    [SerializeField] private XpBar _uiXpBar;
    [SerializeField] private GameObject _uiUpgradeSelect;

    private void Start()
    {
        _uiXpBar.SetProgress(_currentXp, _levelUpXp);
    }

    public void AddXp(int value)
    {
        _currentXp += value;

        if (_currentXp >= _levelUpXp)
        {
            LevelUp();
        }

        _uiXpBar.SetProgress(_currentXp, _levelUpXp);
    }

    private void LevelUp()
    {
        _level++;
        _currentXp -= _levelUpXp;
        _levelUpXp = (int)(_levelUpXp * _levelUpXpIncreaseFactor);
        ShowUpgradeWindow();
    }

    private void ShowUpgradeWindow()
    {
        _uiUpgradeSelect.SetActive(true);
        _uiUpgradeSelect.GetComponent<UpgradeSelect>().CreateUpgradeButtons();
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
}
