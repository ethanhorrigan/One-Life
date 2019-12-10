using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Charge Points class to handle functionality of Charge Points
/// When player triggers a charge point it becomes activated, opening a door to pass the current level
/// </summary>
public class ChargePoints : MonoBehaviour
{
    public GameObject cp;
    public bool pressure;

    public GameObject pressurePlate;
    public Sprite _noPressure;
    public Sprite _yesPressure;

    public Sprite _doorClosed;
    public Sprite _doorOpen;

    public AudioClip aPressure;
    private AudioSource audioSource;

    /// <summary>
    /// When the player triggers the charge point
    /// </summary>
    /// <param name="collision">Player Collision is passed through when it collides with the Charge Point</param>
    /// 

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerHandler.IsPlayer(collision))
        {
            GameObject door = GameObject.FindGameObjectWithTag("Door");
            audioSource.PlayOneShot(aPressure);
            collision.GetComponent<SpriteRenderer>().sortingOrder = 2;
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
            door.GetComponent<SpriteRenderer>().sprite = _doorOpen;
            pressurePlate.GetComponent<SpriteRenderer>().sprite = _yesPressure;

            pressure = true;
        }

        else
            Debug.Log("Not a player");
 
    }
    /// <summary>
    /// When the player exits the charge point
    /// </summary>
    /// <param name="collision">Player Collision is passed through when it exits the Charge Point</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            return;
        }
        if (collision.gameObject.tag != "Bullet")
        {
            GameObject door = GameObject.FindGameObjectWithTag("Door");
            audioSource.PlayOneShot(aPressure);
            pressurePlate.GetComponent<SpriteRenderer>().sprite = _noPressure;
            pressure = false;
            door.GetComponent<SpriteRenderer>().sprite = _doorClosed;
        }
    }

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        pressurePlate.GetComponent<SpriteRenderer>().sprite = _noPressure;
    }
}
