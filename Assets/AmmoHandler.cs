using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
    GameObject bullets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerHandler.IsPlayer(collision))
        {
            bullets = GameObject.FindGameObjectWithTag("MainCamera");
            bullets.GetComponent<BulletHandler>().bullets += 3;
            Destroy(gameObject);
        }
    }
}