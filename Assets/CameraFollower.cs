using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Adapted from: https://learn.unity.com/tutorial/movement-basics?projectId=5c514956edbc2a002069467c#5c7f8528edbc2a002053b711
 * Camera Follows the player
 */
public class CameraFollower : MonoBehaviour
{

    public GameObject player;
    public GameObject player2;

    private GameObject player_1_state;
    private GameObject player_2_state;


    private Vector3 offsetPlayer1;
    private Vector3 offsetPlayer2;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private bool tran = false;
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position. 
        offsetPlayer1 = transform.position - player.transform.position;
        offsetPlayer2 = transform.position - player2.transform.position;
    }

    void LateUpdate()
    {
        player_1_state = GameObject.FindGameObjectWithTag("Player");
        player_2_state = GameObject.FindGameObjectWithTag("Player2");
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player_1_state.GetComponent<Joystick>().active)
            transform.position = player.transform.position + offsetPlayer1;
        if (player_2_state.GetComponent<Joystick>().active)
        {
            if (!tran) { 
                StartCoroutine(TransitionCamera(player2, offsetPlayer2));
            }
            transform.position = player2.transform.position + offsetPlayer2;
        }
    }

    IEnumerator TransitionCamera(GameObject p, Vector3 os)
    {
        Debug.Log("Called");
        transform.position = Vector3.SmoothDamp(transform.position, p.transform.position + os, ref velocity, smoothTime);
        tran = true;
        yield return new WaitForSeconds(smoothTime);
    }
}
