using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    [SerializeField] private float _removeTimer = 0.2f;

    void Start()
    {
        Destroy(this.gameObject, _removeTimer);
    }
}
