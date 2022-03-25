using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        SetDefaults();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void SetDefaults()
    {
        FireRate = 1f;
        Damage = 10;
        Offset = 0;
        Ranged = true;
        Silenced = false;
        Automatic = false;
        BulletCount = 10;
        BulletSpread = 17f;
        BulletSpeed = 1500f;
    }
}
