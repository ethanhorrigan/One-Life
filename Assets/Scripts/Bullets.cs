using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] bullets;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Camera cam;

    void Start()
    {
        Instantiate(bullet, new Vector2(-4f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.Log(ray);
    }
}
