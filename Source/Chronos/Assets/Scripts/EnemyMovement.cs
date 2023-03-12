using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed = 200;
    GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.Find("Player");    
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
    }
}
