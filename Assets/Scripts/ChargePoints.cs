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

    /// <summary>
    /// When the player triggers the charge point
    /// </summary>
    /// <param name="collision">Player Collision is passed through when it collides with the Charge Point</param>
    /// 

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerHandler.IsPlayer(collision))
        {
            Debug.Log("Pressure Plate Triggered");
            collision.GetComponent<SpriteRenderer>().sortingOrder = 2;
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
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
            Debug.Log(collision.name);
            return;
        }
        if (collision.gameObject.tag != "Bullet")
        {
            pressurePlate.GetComponent<SpriteRenderer>().sprite = _noPressure;
            pressure = false;
            Debug.Log("Pressure Plate Exit");
        }
    }

    private void Start()
    {
        pressurePlate.GetComponent<SpriteRenderer>().sprite = _noPressure;
    }
}
