using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float shootSpeed = 10.0f;
    private float destroyDelay = 0.5f;
    void Update()
    {
        //transform.Translate(Vector2.right * shootSpeed * Time.deltaTime);
        Destroy(gameObject, destroyDelay);
    }
}
