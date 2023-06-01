using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private int _itemId = 0;
    public int ItemId { get { return _itemId; } }

    private int _buttonNum = 1;
    [SerializeField] private string _itemName = "";
    [SerializeField] private Text _text;
    
    private Button _button;
    private UpgradeSelect _upgradeSelect;

    [SerializeField] private GameObject _iconPrefab;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        GameObject icon =  Instantiate(_iconPrefab, this.transform);
        icon.transform.localPosition = new Vector2(-120, 0);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Select" + _buttonNum) == 1)
        {
            Upgrade();
        }
    }

    public void SetupButton(int buttonNum, UpgradeSelect upgradeSelect)
    {
        _buttonNum = buttonNum;
        _upgradeSelect = upgradeSelect;

        string itemText;
        int itemLevel = GameObject.Find("Player").GetComponent<PlayerItems>().GetItemLevel(_itemId);
        
        if (itemLevel == 0)
        {
            itemText = "Equip new item -> " + _itemName;
        }
        else
        {
            itemText = "Upgrade " + _itemName + " to level " + (itemLevel + 1);
        }
        _text.text = _buttonNum + ". " + itemText;
    }

    private void OnClick()
    {
        Upgrade();
    }

    public void Upgrade()
    {
        GameObject.Find("Player").GetComponent<PlayerItems>().UpgradeItem(_itemId);

        _upgradeSelect.HideUpgradeWindow();
    }
}
