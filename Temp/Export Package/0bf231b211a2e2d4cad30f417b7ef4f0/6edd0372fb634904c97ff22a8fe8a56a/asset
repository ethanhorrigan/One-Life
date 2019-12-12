using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Ethan Horrigan
 * Stores the total bullets a player can use per level
 */
public class BulletHandler : MonoBehaviour
{
    public int bullets;
    private GameObject main;

    void Update()
    {
        if(bullets < 0)
            SceneManager.LoadScene("Level_" + 1);
    }
}
