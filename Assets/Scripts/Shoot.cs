using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float shootSpeed = 500.0f;
    private Rigidbody2D rb;
    private int bounceCount;
    private string otherPlayer;
  

    public CircleCollider2D circleCollider;
    void Update()
    {
        
        //Destroy(gameObject, Constants.DESTROY_DELAY);
    }

    void Start()
    {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        otherPlayer = "Player";
        bounceCount = 0;

        /*
         * Originally had transform.translate to move the bullet, but this caused issues when 
         * trying to richochet the bullets off walls, opted for rigidbody component instead.
         */
        //transform.Translate(Vector2.right * shootSpeed * Time.deltaTime);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player1 = GameObject.Find("Player_One");
        GameObject player2 = GameObject.Find("Player_Two");

        if (other.tag == "Player" && other.GetComponent<Joystick>().active == false)
        {
            player1.GetComponent<Joystick>().active = true;
            player2.GetComponent<Joystick>().active = false;
            player2.GetComponent<Animator>().SetBool("Dead", true);
            player1.GetComponent<Animator>().SetBool("Dead", false);
            player1.GetComponent<Animator>().SetBool("Alive", true);
            otherPlayer = "Player";
            Destroy(gameObject);
            //animator.SetBool("Alive", true);
        }

        if(other.tag == "Player2" && other.GetComponent<Joystick>().active == false)
        {
            player1.GetComponent<Joystick>().active = false;
            player2.GetComponent<Joystick>().active = true;
            player1.GetComponent<Animator>().SetBool("Dead", true);
            player2.GetComponent<Animator>().SetBool("Dead", false);
            player2.GetComponent<Animator>().SetBool("Alive", true);


            otherPlayer = "Player2";
            Destroy(gameObject);
        }
    }

    private IEnumerator DisableAnimator(string player)
    {
        GameObject findPlayer = GameObject.Find(player);
        findPlayer.GetComponent<Joystick>().enabled = false;
        yield return new WaitForSeconds(2.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        bounceCount++;
        if(collision.otherCollider.tag == "Wall")
        {
            circleCollider.enabled = true;
        }
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with enemy");
            Destroy(enemy);
            Destroy(gameObject);
        }
        /* Destroy the bullet if it collides with anything thats NOT a player*/
        if (bounceCount == 1 && collision.gameObject.tag != otherPlayer)
        {
            Destroy(gameObject, Constants.DESTROY_DELAY);
        }
    }

}
