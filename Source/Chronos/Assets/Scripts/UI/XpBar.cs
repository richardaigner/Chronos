using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField] private Text _xpText;
    [SerializeField] private ProgressBar _progressBar;

    public void SetProgress(int curValue, int maxValue)
    {
        _progressBar.SetProgress(curValue, maxValue);
        _xpText.text = curValue.ToString() + " / " + maxValue.ToString();
    }
}
