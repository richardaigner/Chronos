using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMouseOver : MonoBehaviour
{
    private Image _image;

    private Color _normalColor = new Color(1, 1, 1, 0.4f);
    private Color _highlightColor = new Color(1, 1, 1, 0.6f);
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnMouseEnter()
    {
        _image.color = _highlightColor;
    }

    private void OnMouseExit()
    {
        _image.color = _normalColor;
    }
}
