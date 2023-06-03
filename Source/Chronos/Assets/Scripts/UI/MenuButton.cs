using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] bool _active;

    [SerializeField] string _nextScene;
    [SerializeField] private bool _quitButton;

    private Text _text;
    private Button _button;

    private void Start()
    {
        _text = GetComponent<Text>();

        if (!_active )
        {
            _text.color = new Color(1, 1, 1, 0.5f);
        }
    }

    private void OnClick()
    {
        if (_active)
        {
            if (_quitButton)
            {
                Application.Quit();

            }
            else
            {
                SceneManager.LoadScene(_nextScene);
            }
        }
    }
}
