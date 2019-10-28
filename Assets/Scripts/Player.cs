using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] player;
    public bool active;
    public int bullets = Constants.STARTING_BULLETS;

    public Player(bool active, int bullets)
    {
        this.active = active;
        this.bullets = bullets;
    }

    public void SetUpPlayer()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(active);
        }
        active = true;
        bullets = Constants.STARTING_BULLETS;
    }
}
