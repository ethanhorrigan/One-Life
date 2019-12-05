using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject player;

    public static int currentPlayer = 0;

    //Private Variables
    private Rigidbody2D body;
    private Vector3 target;


    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;


    float speed = 20.0f;

    public GameObject bullet;
    public Transform gunPos;


    void Start()
    {
        target = transform.position;
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

    }
    void FixedUpdate()
    {
    }

    void Update()
    {

        //shootBullet();
    }

    void shootBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RotatePlayer();
            Instantiate(bullet, gunPos.position, gunPos.rotation);
        }
    }


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
