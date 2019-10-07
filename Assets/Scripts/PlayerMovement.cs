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

    private bool facingRight = true;
    private bool facingUp = false;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();

        //transform.Rotate(Vector2, 0, speed * Time.deltaTime, 0, Space.Self);

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, speed);
            Debug.Log("ROTATE");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,0, speed);
            Debug.Log("ROTATE");
        }
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
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down


            if (horizontal > 0 && !facingRight)
            {
                // ... flip the player.
                Flip(0);
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (horizontal < 0 && facingRight)
            {
                // ... flip the player.
                Flip(0);
            }

            if (vertical > 0 && !facingUp)
            {
                // ... flip the player up
                Flip(1);
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (vertical < 0 && facingRight)
            {
                // ... flip the player down
                Flip(1);
            }
        }
    }

    private void Flip(int direction)
    {
        if (direction == 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        if (direction == 1)
        {
            facingUp = !facingUp;
            transform.Rotate(180f, 0f, 0f);
        }
    }
}
