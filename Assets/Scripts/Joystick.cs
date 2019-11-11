using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    private float speed = 5.0f;
    public bool active;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;

    public GameObject bullet;
    public Transform gunPos;


    private Vector3 target;

    private bool moving = false;
    private Quaternion originalRotationValue; // declare this as a Quaternion
    float rotationResetSpeed = 1.0f;

    void Start()
    {
        target = transform.position;
        originalRotationValue = transform.rotation; // save the initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                Touch t = Input.GetTouch(i);
                //Returns touch pos (screen to world)
                Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
                if (t.phase == TouchPhase.Began)
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                    if(Input.GetTouch(i).tapCount == 2) {
                        shootBullet();
                    }
                }
                else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
                {
                    Vector2 offset = touchPos - startingPoint;
                    Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                    moveCharacter(direction * 1);

                    circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

                    moving = true;

                }

               // Reset Circle
                else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
                {
                    leftTouch = 99;
                    circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
                    moving = false;
                    transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);
                }

                ++i;
                Debug.Log("TouchCount:" + Input.touchCount);
            }
        }
    }
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
        RotatePlayer();
        Instantiate(bullet, gunPos.position, gunPos.rotation); ;
    }

    private void RotatePlayer()
    {

            GetPosition();

            // Get Angle in Radians
            float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            player.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    private void GetPosition()
    {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
    }

}