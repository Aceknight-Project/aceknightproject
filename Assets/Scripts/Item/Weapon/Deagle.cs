using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deagle : BaseWeapon
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
        FireRate = 0.25f;
        Damage = 50;
        Offset = 0;
        Ranged = true;
        Silenced = false;
        Automatic = false;
        BulletCount = 1;
        BulletSpread = 0f;
        BulletSpeed = 1000f;
    }
}
