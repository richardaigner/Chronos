using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class UIXpProgressBar : MonoBehaviour
{
    // todo rework: konstant bei der aufl�sung 1920x1080 -> sollte man aufl�sung �ndern funktioniert das so nicht

    private float animatedSize = 0;
    private float actualSize = 0;

    private float animatenFactor = 0.99f;
    private float animatenSpeed = 10;

    private void FixedUpdate()
    {
        SmoothProgress();
    }

    public void UpdateBar(int value, int maxValue)
    {
        actualSize = 1860 / maxValue * value;
    }

    private void SmoothProgress()
    {
        animatedSize += (actualSize - animatedSize) * animatenFactor * animatenSpeed * Time.deltaTime;
        float offset = animatedSize / 2 - 930;

        transform.localPosition = new Vector3(offset, -500, 1);
        transform.localScale = new Vector3(animatedSize, 20, 1);
    }
}
