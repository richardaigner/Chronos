using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class XpProgressBar : MonoBehaviour
{
    // todo rework: konstant bei der auflösung 1920x1080 -> sollte man auflösung ändern funktioniert das so nicht

    private float _animatedSize = 0;
    private float _actualSize = 0;

    private float _animatenFactor = 0.99f;
    private float _animatenSpeed = 10;

    private void FixedUpdate()
    {
        SmoothProgress();
    }

    public void UpdateBar(int value, int maxValue)
    {
        _actualSize = 1860 / maxValue * value;
    }

    private void SmoothProgress()
    {
        _animatedSize += (_actualSize - _animatedSize) * _animatenFactor * _animatenSpeed * Time.deltaTime;
        float offset = _animatedSize / 2 - 930;

        transform.localPosition = new Vector3(offset, -500, 1);
        transform.localScale = new Vector3(_animatedSize, 20, 1);
    }
}
