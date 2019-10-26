using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePoints : MonoBehaviour
{

    private bool pressure = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pressure = true;
            Debug.Log("Pressure Plate Triggered");
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pressure = false;
            GetComponent<PolygonCollider2D>().enabled = true;
            Debug.Log("Pressure Plate Exit");
        }
    }
}
