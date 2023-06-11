using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeIconController : MonoBehaviour
{
    private float _spawnPositionModifier = 100;
    
    [SerializeField] private GameObject[] _itemPrefabs;
    private List<UpgradeIcon> _items = new List<UpgradeIcon>();

    private void Awake()
    {
        for (int i = 0; i < _itemPrefabs.Length; i++)
        {
            _items.Add(Instantiate(_itemPrefabs[i], transform).GetComponent<UpgradeIcon>());
        }
    }

    public void ActivateItem(int itemId)
    {
        UpgradeIcon item = GetItem(itemId);

        if (item != null)
        {
            if (item.Active)
            {
                item.UpdateLevelText();
            }
            else
            {
                item.Activate(new Vector2(_spawnPositionModifier * ActiveItemsCount(), 0));
            }
        }
    }

    private UpgradeIcon GetItem(int itemId)
    {
        foreach (var item in _items)
        {
            if (item.ItemId == itemId)
            {
                return item;
            }
        }

        return null;
    }

    private int ActiveItemsCount()
    {
        int count = 0;

        foreach (var item in _items)
        {
            if (item.Active)
            {
                count++;
            }
        }

        return count;
    }
}
