using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroHandler : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
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
