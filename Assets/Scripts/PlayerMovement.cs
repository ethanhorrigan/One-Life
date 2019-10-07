using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float speed = 5.0f;

    public bool active;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
    }

    private void MovePlayer()
    {
        if (active)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is downW

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 0, speed);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, 0, speed);
            }
        }
    }
}
