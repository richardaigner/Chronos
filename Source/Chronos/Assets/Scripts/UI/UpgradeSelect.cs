using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelect : MonoBehaviour
{
    private bool _active = false;
    public bool Active { get { return _active; } }

    private int _upgradeButtonCount = 3;
    private Vector2[] _upgradeButtonPosition = { new Vector2(0, 60), new Vector2(0, -60), new Vector2(0, -180), new Vector2(0, -300), new Vector2(0, -420) };
    private GameObject[] _upgradeButtons = new GameObject[5];

    [SerializeField] private List<GameObject> _possibleUpgrades;

    public void CreateUpgradeButtons()
    {
        int buttonCount = _upgradeButtonCount;
        if (buttonCount > _possibleUpgrades.Count)
        {
            buttonCount = _possibleUpgrades.Count;
        }

        int[] randomItemIds = new int[buttonCount];

        for (int i = 0; i < buttonCount; i++)
        {
            do
            {
                randomItemIds[i] = Random.Range(0, _possibleUpgrades.Count);
            } while (IsValueInArray(randomItemIds, randomItemIds[i], i));
        }

        for (int i = 0; i < buttonCount; i++)
        {
            _upgradeButtons[i] = Instantiate(_possibleUpgrades[randomItemIds[i]], this.transform);
            _upgradeButtons[i].transform.localPosition = _upgradeButtonPosition[i];
            _upgradeButtons[i].GetComponent<UpgradeButton>().SetupButton(i + 1, this);
        }

        if (buttonCount > 0)
        {
            PauseGame();
        }
    }

    private bool IsValueInArray(int[] array, int value, int length)
    {
        for (int u = 0; u < length; u++)
        {
            if (array[u] == value)
            {
                return true;
            }
        }

        return false;
    }

    private void RemoveUpgradeButtons()
    {
        for (int i = 0; i < _upgradeButtonCount; i++)
        {
            Destroy(_upgradeButtons[i]);
        }
    }

    public void RemovePossibleUpgrade(int itemId)
    {
        for (int i = 0; i < _possibleUpgrades.Count; i++)
        {
            if (_possibleUpgrades[i].GetComponent<UpgradeButton>().ItemId == itemId)
            {
                _possibleUpgrades.RemoveAt(i);
            }
        }
    }

    public void HideUpgradeWindow()
    {
        ResumeGame();
        RemoveUpgradeButtons();
        this.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        _active = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        _active = false;
    }
}
