using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string playScene = "SampleScene";
    public void PlayGame()
    {
        SceneManager.LoadScene(playScene);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
