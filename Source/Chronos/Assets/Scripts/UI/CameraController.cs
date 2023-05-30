using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 _offset;
    private Vector3 _targetPos;
    private float _lerpSpeed = 8.0f;

    [SerializeField] private Transform _target;

    private void Start()
    {
        if (_target != null)
        {
            _offset = transform.position - _target.position;
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _targetPos = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, _targetPos, _lerpSpeed * Time.deltaTime);
        }
    }
}
