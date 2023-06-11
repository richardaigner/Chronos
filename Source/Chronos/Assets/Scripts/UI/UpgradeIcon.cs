using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeIcon : MonoBehaviour
{
    private bool _active = false;
    public bool Active { get { return _active; } }

    [SerializeField] private int _itemId = 0;
    public int ItemId { get { return _itemId; } }

    [SerializeField] private Text _text;
    [SerializeField] private GameObject _iconPrefab;

    private void Start()
    {
        Instantiate(_iconPrefab, this.transform);
    }

    public void Activate(Vector2 position)
    {
        _active = true;
        transform.localPosition = position;
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        int itemLevel = GameObject.Find("Player").GetComponent<PlayerItems>().GetItemLevel(_itemId);
        _text.text = itemLevel.ToString();
    }
}
