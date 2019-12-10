using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Author: Ethan Horrigan
 * Timer Class to initilize Timer and display the Timer UI
 */

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text bulletText;
    public Text levelText;

    private float time = 0;

    private float minutes;
    private float seconds;
    private float fraction;

    private float b;

    void Start()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        levelText.text = door.GetComponent<LevelHandler>().currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        minutes = time / 60;
        seconds = time % 60;
        fraction = (time * 100) % 100;

        if (minutes < 1)
            timerText.text = string.Format("{0:00} : {1:00}", seconds, fraction);
        if (minutes > 1)
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        if (seconds == 0)
            time = 0;
            //end game


        GameObject main = GameObject.FindGameObjectWithTag("MainCamera");
        b = main.GetComponent<BulletHandler>().bullets;
        bulletText.text = b.ToString();
    }
}
