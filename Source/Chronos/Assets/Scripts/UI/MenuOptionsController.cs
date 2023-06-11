using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionsController : MonoBehaviour
{
    [SerializeField] private AudioListener _cameraAudiolistener;

    [SerializeField] private UnityEngine.UI.Button _buttonSound;
    [SerializeField] private Text _soundText;
    [SerializeField] private UnityEngine.UI.Button _buttonReset;
    [SerializeField] private UnityEngine.UI.Button _buttonBack;

    [SerializeField] private GameObject _main;
    [SerializeField] private MenuLevelSelectController _levelSelectController;
    [SerializeField] private MenuUpgradeButton[] _upgradeButtons;
    [SerializeField] private DataController _dataController;

    private void Start()
    {
        _buttonSound.onClick.AddListener(OnClickSound);
        _buttonReset.onClick.AddListener(OnClickReset);
        _buttonBack.onClick.AddListener(OnClickBack);

        UpdateSoundSettings();
    }

    private void OnClickSound()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        
        UpdateSoundSettings();
    }

    private void UpdateSoundSettings()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            _cameraAudiolistener.enabled = true;
            _soundText.text = "Sound On";
        }
        else
        {
            _cameraAudiolistener.enabled = false;
            _soundText.text = "Sound Off";
        }
    }

    private void OnClickReset()
    {
        _dataController.ResetData();
        _levelSelectController.UpdateTextAndButtons();

        for (int i = 0; i < _upgradeButtons.Length; i++)
        {
            _upgradeButtons[i].LoadValues();
        }
    }

    private void OnClickBack()
    {
        _main.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
