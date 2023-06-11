using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _offset;
    private Vector3 _targetPos;

    private float _lerpSpeed = 8;
    [SerializeField] private Transform _target;

    private float _noTargetMoveSpeedCur = 1;
    private float _noTargetMoveSpeedTarget = 1;
    private float _noTargetMoveSpeedMin = -1;
    [SerializeField] private float _noTargetMoveSpeedMax = 1;
    private float _noTargetDistanceCur = 0;
    [SerializeField] private float _noTargetDistanceTarget = 20;

    private float _screenShakeDuration = 0;
    private float _screenShakeCounter = 0;
    private float _screenShakeLength = 0.1f;
    private float _screenShakeStrength = 100;

    private bool _fadeIn = true;
    private bool _fadeOut = false;
    private float _fadeTimeCounter = 0.5f;
    private float _fadeTimeLength = 0.5f;
    private SpriteRenderer _fadeSpriteRenderer;

    private AudioListener _audioListener;

    private void Start()
    {
        _noTargetMoveSpeedCur = _noTargetMoveSpeedMax;
        _noTargetMoveSpeedTarget = _noTargetMoveSpeedMax;
        _noTargetMoveSpeedMin = -_noTargetMoveSpeedMax;
        _fadeSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _fadeSpriteRenderer.color = new Color(0, 0, 0, 1.0f);

        _audioListener = GetComponent<AudioListener>();
        UpdateSoundSettings();

        if (_target != null)
        {
            _offset = transform.position - _target.position;
        }
    }

    private void UpdateSoundSettings()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            _audioListener.enabled = true;
        }
        else
        {
            _audioListener.enabled = false;
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _targetPos = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, _targetPos, _lerpSpeed * Time.deltaTime);
        }
        else
        {
            _noTargetDistanceCur += _noTargetMoveSpeedCur * Time.deltaTime;
            
            if (_noTargetMoveSpeedTarget > 0 && _noTargetDistanceCur > _noTargetDistanceTarget || _noTargetMoveSpeedTarget < 0 && _noTargetDistanceCur < -_noTargetDistanceTarget)
            {
                _noTargetMoveSpeedTarget *= -1;
            }
            if (_noTargetMoveSpeedCur < _noTargetMoveSpeedTarget || _noTargetMoveSpeedCur > _noTargetMoveSpeedTarget)
            {
                _noTargetMoveSpeedCur += _noTargetMoveSpeedTarget * Time.deltaTime;
            }

            if (_noTargetMoveSpeedCur < _noTargetMoveSpeedMin)
            {
                _noTargetMoveSpeedCur = _noTargetMoveSpeedMin;
            }
            if (_noTargetMoveSpeedCur > _noTargetMoveSpeedMax)
            {
                _noTargetMoveSpeedCur = _noTargetMoveSpeedMax;
            }

            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(_noTargetMoveSpeedCur, -_noTargetMoveSpeedCur), _lerpSpeed * Time.deltaTime);
        }

        UpdateScreenShake();
        UpdateFadeTimer();
    }

    private void UpdateScreenShake()
    {
        if (_screenShakeDuration > 0)
        {
            _screenShakeDuration -= Time.deltaTime;

            _screenShakeCounter -= Time.deltaTime;
            if (_screenShakeCounter <= 0)
            {
                _screenShakeCounter += _screenShakeLength;
                transform.position = Vector3.Lerp(transform.position + new Vector3(Random.Range(-_screenShakeStrength, _screenShakeStrength), Random.Range(-_screenShakeStrength, _screenShakeStrength)), _targetPos, _lerpSpeed * Time.deltaTime);
            }
        }
    }

    public void ActivateFadeOut()
    {
        _fadeIn = false;
        _fadeTimeCounter = 0;
        _fadeOut = true;
    }

    private void UpdateFadeTimer()
    {
        if (Time.deltaTime < 0.1f)
        {
            if (_fadeIn)
            {
                _fadeTimeCounter -= Time.deltaTime;
                _fadeSpriteRenderer.color = new Color(0, 0, 0, _fadeTimeCounter * (1 / _fadeTimeLength));

                if (_fadeTimeCounter < 0)
                {
                    _fadeTimeCounter = 0;
                    _fadeIn = false;
                }
            }
            else if (_fadeOut)
            {
                _fadeTimeCounter += Time.deltaTime;
                _fadeSpriteRenderer.color = new Color(0, 0, 0, _fadeTimeCounter * (1 / _fadeTimeLength));

                if (_fadeTimeCounter > _fadeTimeLength)
                {
                    _fadeTimeCounter = _fadeTimeLength;
                    _fadeOut = false;
                }
            }
        }
    }

    public void StartScreenShake(float duration, float length, float strength)
    {
        _screenShakeDuration = duration;
        _screenShakeCounter = length;
        _screenShakeLength = length;
        _screenShakeStrength = strength;
    }
}
