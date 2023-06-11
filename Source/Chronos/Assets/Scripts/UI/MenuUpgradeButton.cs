using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpgradeButton : MonoBehaviour
{
    private int _level = 0;
    private int _maxLevel = 5;

    private Color _normalColor = new Color(1.0f, 1.0f, 1.0f, 0.4f);
    private Color _highlightColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);

    private Color _inactiveColor = new Color(1.0f, 1.0f, 1.0f, 0.4f);
    private Color _activeColor = new Color(0.3f, 0.8f, 0.3f, 0.4f);
    private Color _activeHighlightColor = new Color(0.3f, 0.8f, 0.3f, 0.7f);

    private AudioSource _audioSource;
    [SerializeField] private Button _descriptionButton;
    [SerializeField] private Image _descriptionImage;
    [SerializeField] private GameObject[] _upgradeLevelButtons;
    [SerializeField] private MenuLevelSelectController _levelSelectController;

    [SerializeField] private string _descriptionInDataController;
    [SerializeField] private DataController _dataController;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _descriptionButton.onClick.AddListener(OnClick);
        for (int i = 0; i < _upgradeLevelButtons.Length; i++)
        {
            _upgradeLevelButtons[i].GetComponent<Button>().onClick.AddListener(OnClick);
        }

        LoadValues();
    }

    public void LoadValues()
    {
        _level = _dataController.GetUpgradeLevel(_descriptionInDataController);
        UpdateButtonColors(false);
    }

    private void UpdateButtonColors(bool highlight)
    {
        for (int i = 0; i < _upgradeLevelButtons.Length; i++)
        {
            if (i < _level)
            {
                if (_upgradeLevelButtons[i] == highlight)
                {
                    _upgradeLevelButtons[i].GetComponent<Image>().color = _activeHighlightColor;
                }
                else
                {
                    _upgradeLevelButtons[i].GetComponent<Image>().color = _activeColor;
                }
            }
            else
            {
                _upgradeLevelButtons[i].GetComponent<Image>().color = _inactiveColor;
            }
        }
    }
    private void OnMouseEnter()
    {
        _descriptionImage.color = _highlightColor;
        UpdateButtonColors(true);
        
        if (_level < _maxLevel)
        {
            _upgradeLevelButtons[_level].GetComponent<Image>().color = _highlightColor;
        }
    }

    private void OnMouseExit()
    {
        _descriptionImage.color = _normalColor;
        UpdateButtonColors(false);
        
        if (_level < _maxLevel)
        {
            _upgradeLevelButtons[_level].GetComponent<Image>().color = _normalColor;
        }
    }

    private void OnClick()
    {
        if (_dataController.Keys >= (_level + 1))
        {
            _dataController.SetUpgradeLevel(_descriptionInDataController, _level + 1);
            _dataController.Keys -= _level + 1;
            _dataController.SaveData();
            _levelSelectController.UpdateTextAndButtons();
            _level++;
            _audioSource.Play();
            OnMouseEnter(); // update text()
        }
    }
}
