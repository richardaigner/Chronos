using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Color _normalColor = new Color(1, 1, 1, 0.4f);
    private Color _highlightColor = new Color(1, 1, 1, 0.7f);

    private Image _image;
    private Button _button;
    [SerializeField] private GameObject _clickSoundPrefeb;

    private void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnMouseEnter()
    {
        _image.color = _highlightColor;
    }

    private void OnMouseExit()
    {
        _image.color = _normalColor;
    }

    private void OnClick()
    {
        Instantiate(_clickSoundPrefeb, transform.position, Quaternion.identity);
        _image.color = _normalColor;
    }
}
