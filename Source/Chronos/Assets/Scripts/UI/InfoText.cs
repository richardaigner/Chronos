using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    private bool _active = false;

    private float _fadeCounter = 0;
    private float _fadeLength = 0;
    private float _showCounter = 0;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        if (_active)
        {
            if (_fadeCounter < _fadeLength && _showCounter > 0)
            {
                _fadeCounter += Time.deltaTime;
                _text.color = new Color(1, 1, 1, _fadeCounter);
            }
            else if (_fadeCounter >= _fadeLength && _showCounter > 0)
            {
                _showCounter -= Time.deltaTime;
            }
            else
            {
                _fadeCounter -= Time.deltaTime;
                _text.color = new Color(1, 1, 1, _fadeCounter);

                if (_fadeCounter <= 0)
                {
                    _active = false;
                    _fadeCounter = 0;
                    _showCounter = 0;
                }
            }
        }
    }

    public void ShowTextNow(string text)
    {
        _text.color = new Color(1, 1, 1, 1);
        _text.text = text;
        _active = false;
    }

    public void ShowText(float fadeTime, float showTime, string text)
    {
        _active = true;
        _fadeLength = fadeTime;
        _fadeCounter = 0;
        _showCounter = showTime;
        _text.text = text;
    }

    public void HideText()
    {
        _text.color = new Color(1, 1, 1, 0);
        _active = false;
    }
}
