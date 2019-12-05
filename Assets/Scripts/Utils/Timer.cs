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

    private float time = 30;

    private float minutes;
    private float seconds;
    private float fraction;


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        minutes = time / 60;
        seconds = time % 60;
        fraction = (time * 100) % 100;

        if (minutes < 1)
            timerText.text = string.Format("{0:00}", seconds);
        if (minutes > 1)
            timerText.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

        if (seconds == 0)
            time = 0;
            //end game

    }
}
