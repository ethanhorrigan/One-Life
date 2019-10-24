using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    public int active { get; set; }
    public int bullets { get; set; }

    public PlayerHandler(int active, int bullets)
    {
        this.active = active;
        this.bullets = bullets;
    }
}
