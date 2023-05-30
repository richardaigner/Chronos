using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelect : MonoBehaviour
{
    private int _upgradeButtonCount = 2;
    private Vector2[] _upgradeButtonPosition = { new Vector2(0, 60), new Vector2(0, -60), new Vector2(0, -180), new Vector2(0, -300) };
    private GameObject[] _upgradeButtons = new GameObject[4];

    [SerializeField] private GameObject[] _possibleUpgrades;

    private void Start()
    {
        HideUpgradeWindow();
    }

    public void CreateUpgradeButtons()
    {
        int[] randomWeaponIds = new int[_upgradeButtonCount];

        for (int i = 0; i < _upgradeButtonCount; i++)
        {
            do
            {
                randomWeaponIds[i] = Random.Range(0, _possibleUpgrades.Length);
            } while (IsValueInArray(randomWeaponIds, randomWeaponIds[i], i));
        }

        for (int i = 0; i < _upgradeButtonCount; i++)
        {
            _upgradeButtons[i] = Instantiate(_possibleUpgrades[randomWeaponIds[i]], this.transform);
            _upgradeButtons[i].transform.localPosition = _upgradeButtonPosition[i];
            _upgradeButtons[i].GetComponent<UpgradeButton>().SetupButton(i + 1, this);
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

    public void HideUpgradeWindow()
    {
        ResumeGame();
        RemoveUpgradeButtons();
        this.gameObject.SetActive(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
