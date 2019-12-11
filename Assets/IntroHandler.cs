using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Ethan Horrigan
 * Handles functionality for the intro scenes
 */
public class IntroHandler : MonoBehaviour
{
    GameObject text;
    TypewriterController textScript;
    private Animator animator;
    private int currIntro = 0;

    void Start()
    {
        text = GameObject.Find("Text");
        textScript = text.GetComponent<TypewriterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (textScript.finished == true)
        {
           
            animator.Play("FadeOu");
            switch(SceneManager.GetActiveScene().name) {
                case ("Intro"):
                    currIntro = 1;
                    break;
                case ("Intro_1"):
                    currIntro = 2;
                    break;
                case ("Intro_2"):
                    currIntro = 3;
                    break;
            }
            StartCoroutine(NextIntro(currIntro));
        }
    }

    IEnumerator NextIntro(int next)
    {
        yield return new WaitForSeconds(1);
        if (next == 3)
            SceneManager.LoadScene("Level_1");
        if (next != 3)
        SceneManager.LoadScene("Intro_" + next);
    }
}
