using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float removeTimer = 0.2f;

    void Start()
    {
        Destroy(this.gameObject, removeTimer);
    }
}
