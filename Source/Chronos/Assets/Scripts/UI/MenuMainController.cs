using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuMainController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _buttonStart;
    [SerializeField] private UnityEngine.UI.Button _buttonOptions;
    [SerializeField] private UnityEngine.UI.Button _buttonQuit;

    [SerializeField] private GameObject _levelSelect;
    [SerializeField] private GameObject _options;

    private void Start()
    {
        _buttonStart.onClick.AddListener(OnClickStart);
        _buttonOptions.onClick.AddListener(OnClickOptions);
        _buttonQuit.onClick.AddListener(OnClickQuit);

        this.gameObject.SetActive(true);
        _options.SetActive(false);
        _levelSelect.SetActive(false);
    }

    private void OnClickStart()
    {
        _levelSelect.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnClickOptions()
    {
        _options.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnClickQuit()
    {
        Application.Quit();
    }
}
