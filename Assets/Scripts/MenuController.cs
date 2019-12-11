using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Author: Ethan Horrigan
 * Button functions in the Main Menu
 */
public class MenuController : MonoBehaviour
{

    Animator anim;
    public Image fader;

    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }

    public void OnQuitClick()
    {
        anim.Play("quit");
    }

    public void OnPlayClick()
    {
        anim.Play("play");
        audioSource.Play();
        StartCoroutine(FadeOut(1));
    }

    public void OnContinueClick()
    {
        anim.Play("continue");
        audioSource.Play();
        StartCoroutine(Continute());
    }


    IEnumerator FadeOut(int level)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Intro");
    }

    IEnumerator Continute()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Level_1");
    }
}
