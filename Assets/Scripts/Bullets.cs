using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject bullet;

    [SerializeField]
    private Transform gunPos;


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(bullet, gunPos.position, gunPos.rotation);
        }
    }

}
