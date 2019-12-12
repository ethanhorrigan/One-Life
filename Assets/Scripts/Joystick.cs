﻿using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Author: Ethan Horrigan
 * This class handles the majority of functioanlity throughout the game
 */
public class Joystick : MonoBehaviour
{
    /* Player Variables */
    public Transform player;
    private float speed = 4f;
    public bool active;
    public bool isOnPc;
    public Animator animator;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;

    /* Gun Variables */
    public GameObject bullet;
    public Transform gunPos;

    private Rigidbody2D body;

    /* Movment Variables */
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    float startingScale;

    /* Position Variables */
    private Vector3 target;
    private Vector3 shootPoint;
    private Quaternion originalRotationValue; // declare this as a Quaternion
    float rotationResetSpeed = 1.0f;
    private bool isFlipped = false;

    /*Bullet Handler Variable*/
    GameObject main;
    GameObject ammo;
    int currentLevel;
    /* Audio Variables */
    private AudioSource audioSource;
    public AudioClip aShoot;

    private Vector2 gunStart = new Vector2(0.5f, -0.2f);

    void Start()
    {
        target = gunPos.transform.position;
        /*
         * Set the original rotation, so it can be moved back to original value again
         */
        originalRotationValue = transform.rotation;
        startingScale = player.transform.localScale.x;
        /* get the audio source compoenent*/
        audioSource = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

        /*Get the current level*/
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        currentLevel = door.GetComponent<LevelHandler>().currentLevel;

        /*Initialize bullets*/
        main = GameObject.FindGameObjectWithTag("MainCamera");
    }

    /*
     * IEnumerator method to add transition to Running Animation
     */
    IEnumerator StartRunning()
    {
        animator.SetBool("Running", true);
        yield return new WaitForSeconds(2);
    }

    /* Handles the functionality for player movment on PC */
    private void MovePlayerPC()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is downW
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed

            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!active)
        {
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dead", true);
            animator.SetBool("Alive", false);
        }
        if (active)
        {

            animator.SetBool("Dead", false);
            animator.SetBool("Idle", true);
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "IdleAnimation_1")
            {
                animator.SetBool("Alive", false);
            }
            if (isOnPc)
            {
                animator.SetBool("Idle", true);
                MovePlayerPC();
                FaceMouse();
                shootBullet();
            }
            else
            {
                int i = 0;
                while (i < Input.touchCount)
                {
                    Touch t = Input.GetTouch(i);
                    //Returns touch pos (screen to world)
                    Vector2 touchPos = getTouchPosition(t.position);
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
                        Vector2 direction;
                        //moveCharacter(direction * 1);
                        if (circle.transform.position.x < -11.5)
                        {
                            direction = Vector2.ClampMagnitude(offset, -1.0f);
                            player.transform.rotation = Quaternion.Euler(0, -180, 0);
                            moveCharacter(direction * 1);
                        }

                        else
                        {
                            direction = Vector2.ClampMagnitude(offset, 1.0f);
                            player.transform.rotation = Quaternion.Euler(0, 0, 0);
                            moveCharacter(direction * 1);
                        }
                    }

                    /*
                     * If the finger has been lifted (no touch registered)
                     * Reset to its original position
                     */
                    else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
                    {
                        leftTouch = 99;
                        circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
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
            animator.SetBool("Dead", false);
            player.Translate(direction * speed * Time.deltaTime);
        }
    }

    /* 
     * Handles functionality for shooting 
     */
    void shootBullet()
    {
        if (active)
        {
            if (isOnPc)
            {
                if (Input.GetMouseButtonDown(Constants.LEFT_CLICK))
                {
                    if (main.GetComponent<BulletHandler>().bullets == 0)
                    {
                        SceneManager.LoadScene("Level_" + 1);
                    }
                    if (main.GetComponent<BulletHandler>().bullets > 0)
                    {

                        RotateGun();
                        shootPoint = new Vector3(gunPos.position.x, gunPos.position.y, gunPos.position.z);
                        Instantiate(bullet, shootPoint, gunPos.rotation);
                        audioSource.PlayOneShot(aShoot);

                        main.GetComponent<BulletHandler>().bullets--;
                    }

                }
            }
            else
            {
                if (main.GetComponent<BulletHandler>().bullets == 0)
                {
                    SceneManager.LoadScene("Level_" + 1);
                }
                if (main.GetComponent<BulletHandler>().bullets > 0)
                {
                    RotateGun();
                    shootPoint = new Vector3(gunPos.position.x + 0.5f, gunPos.position.y, gunPos.position.z);
                    Instantiate(bullet, shootPoint, gunPos.rotation);
                    audioSource.PlayOneShot(aShoot);

                    main.GetComponent<BulletHandler>().bullets--;
                }
            }
        }
    }

    /*
     * Rotates gun to where the player wants to shoot (target)
     */
    private void RotateGun()
    {

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        gunPos.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
       
    }

    /* 
     * Face the gun according to the mouse position 
     */
    private void FaceMouse()
    {
        /* Get the mouse position (screen space) */
        Vector3 mousePos = Input.mousePosition;

        /* convert from screen space to world space */
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        /* Create a direction vector (Vector2 in 2D) */
        Vector2 direction = new Vector2(
            mousePos.x - gunPos.transform.position.x,
            mousePos.y - gunPos.transform.position.y
            );

        gunPos.transform.right = direction;

        if (direction.x < Constants.FLIP_OFFSET - 0.5f && !isFlipped)
            FlipLeft();
        else if (direction.x > Constants.FLIP_OFFSET - 0.5f)
            FlipRight();
    }

    /* 
     * Flip the player to Face Left 
     */
    public void FlipLeft()
    {
        if (active)
        {
            isFlipped = true;
            player.transform.rotation = Quaternion.Euler(0, -180, 0);

        }
    }
    /*
     * FLip the Player to Face Right
     */
    public void FlipRight()
    {
        if (active)
        {
            isFlipped = false;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }



}