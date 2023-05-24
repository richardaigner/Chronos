using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    private float _timeInSeconds = 30 * 60;
    private Text _textField;

    private void Start()
    {
        _textField = GetComponent<Text>();
    }

    private void Update()
    {
        _timeInSeconds -= Time.deltaTime;
        _textField.text = Mathf.Floor(_timeInSeconds / 60).ToString() + ":" + Mathf.Floor(_timeInSeconds % 60).ToString();
    }
}
