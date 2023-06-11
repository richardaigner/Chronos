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

    [SerializeField] private GameObject _levelUpEffectPrefab;
    [SerializeField] private AudioSource _levelupSoundPrefab;

    private void Start()
    {
        _uiXpBar.SetProgress(_currentXp, _levelUpXp);
        _uiUpgradeSelect.SetActive(false);
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
        _levelupSoundPrefab.Play();
        Instantiate(_levelUpEffectPrefab, transform.position, Quaternion.identity);
        StartCoroutine(ShowUpgradeWindow(1.0f));
    }

    IEnumerator ShowUpgradeWindow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        _uiUpgradeSelect.SetActive(true);
        _uiUpgradeSelect.GetComponent<UpgradeSelect>().CreateUpgradeButtons();
    }
}
