using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerYSort : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sortingOrder = transform.GetSortingOrder();
    }
}
