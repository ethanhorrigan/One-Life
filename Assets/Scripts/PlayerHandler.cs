using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject player;
    private int bullets = Constants.STARTING_BULLETS;

    public static int currentPlayer = 0;

    //Private Variables
    private Rigidbody2D body;
    private Vector3 target;
    private float horizontal;
    private float vertical;
    private float moveLimiter = Constants.MOVE_LIMITER;
    private float speed;

    void Start()
    {
        target = transform.position;
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }
    void FixedUpdate()
    {
        //if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        //{
        //    // limit movement speed diagonally, so you move at 70% speed
        //    horizontal *= moveLimiter;
        //    vertical *= moveLimiter;
        //}
        //speed = Constants.MOVE_SPEED;
        //body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void Update()
    {
    }
    //private void MovePlayer()
    //{
    //    horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
    //    vertical = Input.GetAxisRaw("Vertical"); // -1 is downW
    //}

    /// <summary>
    /// Rotates player to the target (mouse position)
    /// </summary>
    private void RotatePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetPosition();

            // Get Angle in Radians
            float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
    }


    /// <summary>
    /// Gets world position of mouse click/tap to vector3 coordinates 
    /// </summary>
    private void GetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
    }


    public static bool IsPlayer(Collider2D coll)
    {
        if (coll.tag == "Player" || coll.tag == "Player2")
            return true;

        return false;
    }
}
