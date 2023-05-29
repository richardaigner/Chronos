using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _startSize = 0;
    private float _animatedSize;
    private float _currentSize;
    private float _maxSize;

    private float _currentAlpha = 1;
    [SerializeField] private float _alphaOnMaxSize = 1;
    [SerializeField] private float _alphaFadeSpeed = 1;

    [SerializeField] private float _animatenFactor = 0.99f;
    [SerializeField] private float _animatenSpeed = 5;

    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _maxSize = transform.localScale.x;
        _animatedSize = _startSize;
        _currentSize = _startSize;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new UnityEngine.Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _currentAlpha);
    }

    private void Update()
    {
        UpdateSize();
        UpdateAlpha();
    }

    public void UpdateProgress(int value, int maxValue)
    {
        _currentSize = (_maxSize / maxValue) * value;
    }

    private void UpdateSize()
    {
        _animatedSize += (_currentSize - _animatedSize) * _animatenFactor * _animatenSpeed * Time.deltaTime;
        if (_animatedSize > _maxSize)
        {
            _animatedSize = _maxSize;
        }

        float offset = _animatedSize / 2 - _maxSize / 2;

        transform.localPosition = new Vector3(offset, transform.localPosition.y, transform.localPosition.z);
        transform.localScale = new Vector3(_animatedSize, transform.localScale.y, transform.localScale.z);
    }

    private void UpdateAlpha()
    {
        if (_currentSize == _maxSize)
        {
            if (_currentAlpha > _alphaOnMaxSize)
            {
                _currentAlpha -= _alphaFadeSpeed * Time.deltaTime;
                _spriteRenderer.color = new UnityEngine.Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _currentAlpha);
            }
        }
        else
        {
            if (_currentAlpha < 1.0)
            {
                _currentAlpha += _alphaFadeSpeed * Time.deltaTime;
                _spriteRenderer.color = new UnityEngine.Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _currentAlpha);
            }
        }
    }
}
