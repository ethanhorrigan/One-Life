using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private float shootSpeed = 10.0f;
    private int collisionCount;
    private int current;
    void Update()
    {
        transform.Translate(Vector2.right * shootSpeed * Time.deltaTime);
        Destroy(gameObject, Constants.DESTROY_DELAY);
    }

    private void Start()
    {
        collisionCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player1 = GameObject.Find("Player_One");
        GameObject player2 = GameObject.Find("Player_Two");

        if (other.tag == "Player")
        {
            player1.GetComponent<Joystick>().active = true;
            player2.GetComponent<Joystick>().active = false;
            player1.GetComponent<SpriteRenderer>().color = Color.green;
            player2.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        if(other.tag == "Player2")
        {
            player1.GetComponent<Joystick>().active = false;
            player2.GetComponent<Joystick>().active = true;
            player2.GetComponent<SpriteRenderer>().color = Color.green;
            player1.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        Destroy(gameObject);
    }

}
