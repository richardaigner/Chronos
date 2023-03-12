using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 400;

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
