using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        GameObject player1 = GameObject.Find("Player_One");
        GameObject player2 = GameObject.Find("Player_Two");
        GameObject pressurePlate = GameObject.Find("PressurePlate");

        if (collision.otherCollider.tag == "Player" && pressurePlate.GetComponent<ChargePoints>().pressure)
        {

        }

        if (collision.otherCollider.tag == "Player2" && pressurePlate.GetComponent<ChargePoints>().pressure)
        {

        }

        else
        {
            Debug.Log("no pressure detected");
        }

    }


}
