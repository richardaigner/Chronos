using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _button1;
    [SerializeField] private UnityEngine.UI.Button _button2;
    [SerializeField] private UnityEngine.UI.Button _button3;
    [SerializeField] private UnityEngine.UI.Button _button4;

    private void Start()
    {
        LoadMenuButtons();
    }

    private void LoadMenuButtons()
    {
        _button1.GetComponent<Text>().text = "Start";
        _button1.onClick.AddListener(OnClickStart);
        _button2.GetComponent<Text>().text = "Upgrades";
        _button2.onClick.AddListener(OnClickUpgrades);
        _button3.GetComponent<Text>().text = "Options";
        _button3.onClick.AddListener(OnClickOptions);
        _button4.GetComponent<Text>().text = "Quit";
        _button4.onClick.AddListener(OnClickQuit);
    }

    private void LoadOptionsButtons()
    {
        _button1.GetComponent<Text>().text = "Music Off";
        _button1.onClick.AddListener(OnClickBack); // TODO
        _button2.GetComponent<Text>().text = "Sound Off";
        _button2.onClick.AddListener(OnClickBack); // TODO
        _button3.GetComponent<Text>().text = "Reset Progress";
        _button3.onClick.AddListener(OnClickBack); // TODO
        _button4.GetComponent<Text>().text = "Back";
        _button4.onClick.AddListener(OnClickBack);
    }

    private void OnClickStart()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    private void OnClickUpgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }

    private void OnClickOptions()
    {
        LoadOptionsButtons();
    }

    private void OnClickBack()
    {
        LoadMenuButtons();
    }

    private void OnClickQuit()
    {
        Application.Quit();
    }
}
