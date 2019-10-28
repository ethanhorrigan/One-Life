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

    private Vector3 target;


    void Start()
    {
        target = transform.position;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        GetMousePos();
        RotateTo();
    }

    void FixedUpdate()
    {
        if (p.active)
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
        if (p.active)
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

    private void GetMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            Debug.Log(target.x);
        }
    }
    private void RotateTo()
    {

        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            Debug.Log(target.x);

            // Get Angle in Radians
            float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
    }
}
