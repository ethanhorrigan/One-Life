﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    private float speed = 5.0f;
    public bool active;
    public bool isOnPc;
    public Animator animator;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;

    public GameObject bullet;
    public Transform gunPos;

    private Rigidbody2D body;


    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    float startingScale;


    private Vector3 target;
    private Vector3 shootPoint;
    private Quaternion originalRotationValue; // declare this as a Quaternion
    float rotationResetSpeed = 1.0f;

    void Start()
    {
        //animator.SetBool("Alive", true);
        target = gunPos.transform.position;

        /*
         * Set the original rotation, so it can be moved back to original value again
         */
        originalRotationValue = transform.rotation;
        startingScale = player.transform.localScale.x;


        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    /* PC Variables */
    private void MovePlayerPC()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is downW

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed

            horizontal *= moveLimiter;
            vertical *= moveLimiter;
            animator.SetBool("Running", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
           // transform.localScale = new Vector2(-startingScale, transform.localScale.y);
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
           // transform.localScale = new Vector2(startingScale, transform.localScale.y);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
            body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    //private void RotateGun()

    void Update()
    {
        if(!active)
        {
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dead", true);
        }
        if (active)
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "IdleAnimation_1")
            {
                animator.SetBool("Alive", false);
            }
            if (isOnPc)
            {
                animator.SetBool("Idle", true);
                MovePlayerPC();
                shootBullet();
            }
            else { 
            int i = 0;
            while (i < Input.touchCount)
            {
                Touch t = Input.GetTouch(i);
                //Returns touch pos (screen to world)
                Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
                /**
                 * If a touch is registered
                 */
                if (t.phase == TouchPhase.Began)
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;

                    /**
                     * If the screen has been tapped twice, shoot.
                     * (Double tap to shoot)
                     */
                    if (Input.GetTouch(i).tapCount == 2)
                    {
                        shootBullet();
                    }
                }
                /*
                 * If touch is still down
                 */
                else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
                {
                    Vector2 offset = touchPos - startingPoint;
                    Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                    moveCharacter(direction * 1);

                    circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

                }

                /*
                 * If the finger has been lifted (no touch registered)
                 * Reset the circle to its original position
                 */
                else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
                {
                    leftTouch = 99;
                    circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
                    Debug.Log(circle.transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);
                }

                ++i;
                Debug.Log("TouchCount:" + Input.touchCount);
            }
        }
        }
    }

    /**
     * Returns the position of the touch
     */
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.transform.position.z));
    }

    void moveCharacter(Vector2 direction)
    {
        if (active)
        {
            player.Translate(direction * speed * Time.deltaTime);
        }
    }

    void shootBullet()
    {
        if (active)
        {
            if (isOnPc)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RotateGun();
                    shootPoint = new Vector3(gunPos.position.x + 0.5f, gunPos.position.y, gunPos.position.z);
                    Instantiate(bullet, shootPoint, gunPos.rotation);
                }
            }
            else
            {
                //RotateGun();
                Instantiate(bullet, gunPos.position, gunPos.rotation);
            }
        }
    }

    private void RotateGun()
    {

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        gunPos.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        Debug.Log(AngleDeg);
    }

    //private void RotateGun()
    //{
    //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector2 direction = new Vector2(
    //       mousePosition.x = gunPos.position.x,
    //       mousePosition.y = gunPos.position.y
    //    );

    //    gunPos.transform.right = direction;
    //}

}