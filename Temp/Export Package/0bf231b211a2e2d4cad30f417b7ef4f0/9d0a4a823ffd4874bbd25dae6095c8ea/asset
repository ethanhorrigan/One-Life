using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Ethan Horrigan
 * Generates a Typewriter effect to be used in the intro scenes
 * Adapted From: https://unitycoder.com/blog/2015/12/03/ui-text-typewriter-effect-script/
 */
public class TypewriterController : MonoBehaviour
{
    public string fullText = "";
    private string currentText = "";
    private float delay = 0.4f;
    private AudioSource audioSource;

    public bool finished = false;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine(showText());
        this.GetComponent<Text>().fontSize = 150;
    }

    private void PlaySound()
    {
        audioSource.Play();
    }

    IEnumerator showText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            if(i != 0)
                PlaySound();
            delay = Random.Range(Constants.MIN_DELAY, Constants.MAX_DELAY);
            if (currentText == ".") {
                delay = Constants.MIN_DELAY;
            }

               
            yield return new WaitForSeconds(delay);
        }
        audioSource.Stop();
        finished = true;

    }
}
