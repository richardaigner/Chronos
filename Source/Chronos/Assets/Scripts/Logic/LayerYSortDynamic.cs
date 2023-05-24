using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerYSortDynamic : MonoBehaviour
{
    private int baseSortingOrder;
    [SerializeField] private float ySortingOffset;
    [SerializeField] private Transform ySortingOffsetObject;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(ySortingOffsetObject != null )
        {
            ySortingOffset = ySortingOffsetObject.transform.position.y;
        }
    }

    private void Update()
    {
        baseSortingOrder = transform.GetSortingOrder(ySortingOffset);

        spriteRenderer.sortingOrder = baseSortingOrder;
    }
}
