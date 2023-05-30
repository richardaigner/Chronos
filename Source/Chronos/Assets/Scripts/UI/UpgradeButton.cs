using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private int _weaponId = 0;

    private int _buttonNum = 1;
    [SerializeField] private string _buttonText = "";
    [SerializeField] private Text _text;
    
    private Button _button;
    private UpgradeSelect _upgradeSelect;

    public void SetupButton(int buttonNum, UpgradeSelect upgradeSelect)
    {
        _buttonNum = buttonNum;
        _upgradeSelect = upgradeSelect;
        _text.text = _buttonNum + ". " + _buttonText;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Select" + _buttonNum) == 1)
        {
            UpgradeWeapon();
            _upgradeSelect.HideUpgradeWindow();
        }
    }

    private void OnClick()
    {
        UpgradeWeapon();
        _upgradeSelect.HideUpgradeWindow();
    }

    public void UpgradeWeapon()
    {
        GameObject.Find("Player").GetComponent<PlayerWeapon>().UpgradeWeapon(_weaponId);
    }
}
