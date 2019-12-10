using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float stoppingDistance = 2.0f;

    private GameObject player1;
    private GameObject player2;
    public GameObject enemy;

    private Transform target;
    private Transform target2;
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player1.GetComponent<Joystick>().active)
        {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (player2.GetComponent<Joystick>().active)
        {
                transform.position = Vector2.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "Player2")
            SceneManager.LoadScene("Level_" + 1);
        if (collision.collider.gameObject.tag != "Player" || collision.collider.gameObject.tag != "Player2")
            return;
    }
}
