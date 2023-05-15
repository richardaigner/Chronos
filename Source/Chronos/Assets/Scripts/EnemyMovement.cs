using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 200;

    private GameObject playerObject;
    public Animator animator;
    public SpriteRenderer sr;

    private void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector2 oldPosition = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
        Vector2 newPosition = transform.position;

        Vector2 moveDirection = newPosition - oldPosition;

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (moveDirection.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
