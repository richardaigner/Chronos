using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    private float _timeInSeconds;
    private Text _textField;

    private void Start()
    {
        _textField = GetComponent<Text>();
    }

    private void Update()
    {
        _timeInSeconds += Time.deltaTime;

        string minutes = Mathf.Floor(_timeInSeconds / 60).ToString();
        string seconds = Mathf.Floor(_timeInSeconds % 60).ToString();

        if (Mathf.Floor(_timeInSeconds % 60) < 10)
        {
            seconds = "0" + seconds;
        }

        _textField.text = minutes + ":" + seconds;
    }
}
