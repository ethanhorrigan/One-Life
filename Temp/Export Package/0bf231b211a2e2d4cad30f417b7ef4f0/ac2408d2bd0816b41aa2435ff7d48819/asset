using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Ethan Horrigan
 * Charge Points class to handle functionality of Charge Points
 * When player triggers a charge point it becomes activated, opening a door to pass the current level
 */
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
