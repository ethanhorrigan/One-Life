﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Charge Points class to handle functionality of Charge Points
/// When player triggers a charge point it becomes activated, opening a door to pass the current level
/// </summary>
public class ChargePoints : MonoBehaviour
{

    private bool pressure = false;

    /// <summary>
    /// When the player triggers the charge point
    /// </summary>
    /// <param name="collision">Player Collision is passed through when it collides with the Charge Point</param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.tag == "Player" && pressure == false)
       // {
           // pressure = true;
            //Physics2D.IgnoreCollision(collision.collider, GetComponent<PolygonCollider2D>());
            Debug.Log("Pressure Plate Triggered");
            //GetComponent<PolygonCollider2D>().enabled = false;
      //  }
    }
    /// <summary>
    /// When the player exits the charge point
    /// </summary>
    /// <param name="collision">Player Collision is passed through when it exits the Charge Point</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && pressure == true)
        {
            pressure = false;
            //GetComponent<PolygonCollider2D>().enabled = true;
            Debug.Log("Pressure Plate Exit");
        }
    }
}
