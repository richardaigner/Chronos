using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    private Text _textField;

    [SerializeField] private SpawnSequence _spawnSequence;

    private void Start()
    {
        _textField = GetComponent<Text>();
    }

    private void Update()
    {
        float time = _spawnSequence.GameTime;

        string minutes = Mathf.Floor(time / 60).ToString();
        string seconds = Mathf.Floor(time % 60).ToString();

        if (Mathf.Floor(time % 60) < 10)
        {
            seconds = "0" + seconds;
        }

        _textField.text = minutes + ":" + seconds;
    }
}
