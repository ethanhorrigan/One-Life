using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPool : MonoBehaviour
{
    [SerializeField]
    private Bullets[] bullets;

    private int bulletCache = 0;
    private int activeBullet = 0;

    private void Start()
    {
        bulletCache = (bullets.Length);
    }

    void ShootBullet()
    {
        bullets[activeBullet].Shoot();
        activeBullet += 1;

        if (activeBullet > bulletCache - 1)
            activeBullet = 0;
    }
}
