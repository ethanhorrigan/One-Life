using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletHandler : MonoBehaviour
{
    public int bullets;
    private GameObject main;
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        if(bullets < 0)
            SceneManager.LoadScene("Level_" + 1);
    }
}
