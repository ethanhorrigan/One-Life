using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterController : MonoBehaviour
{
    // Start is called before the first frame update
    //public float delay = 0.3f;
    public string fullText = "";
    private string currentText = "";
    Random rnd = new Random();
    private float delay = 0.4f;
    private AudioSource audioSource;

    private float lowPitch = 2.0f;
    private float highPitch = 2.2f;
    public bool finished = false;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine(showText());
        this.GetComponent<Text>().fontSize = 150;
    }

    private void randomSound()
    {
        //float randomPitch = Random.Range(lowPitch, highPitch);
        //audioSource.pitch = randomPitch;
        audioSource.Play();
    }
    IEnumerator showText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            if(i != 0)
                randomSound();
            delay =Random.Range(0.1f, 0.4f);
            if (currentText == ".") {
                delay = 0.1f;
            }

               
            yield return new WaitForSeconds(delay);
        }
        audioSource.Stop();
        finished = true;

    }
}
