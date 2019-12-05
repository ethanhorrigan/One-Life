using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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


    IEnumerator FadeOut(int level)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Intro");
    }
}
