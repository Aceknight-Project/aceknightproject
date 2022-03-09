using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseWeapon
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
        FireRate = 0.7f;
        Damage = 200;
        Offset = 0;
        Ranged = true;
        Silenced = false;
        Automatic = false;
        BulletCount = 1;
        BulletSpread = 0f;
        BulletSpeed = 1500f;
    }
}
