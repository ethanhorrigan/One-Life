using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public int currentLevel;

    /// <summary>
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            return;
        GameObject player1 = GameObject.Find("Player_One");
        GameObject player2 = GameObject.Find("Player_Two");
        GameObject pressurePlate = GameObject.Find("PressurePlate");

        if (pressurePlate.GetComponent<ChargePoints>().pressure)
        {
            currentLevel++;
            SceneManager.LoadScene("Level_" + currentLevel);
        }

        else
        {
            Debug.Log("no pressure detected");
        }

    }


}
