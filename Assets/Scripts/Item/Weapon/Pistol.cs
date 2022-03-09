using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
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
        FireRate = 0.15f;
        Damage = 20;
        Offset = 0;
        Ranged = true;
        Silenced = true;
        Automatic = false;
        BulletCount = 1;
        BulletSpread = 5f;
        BulletSpeed = 700f;
    }
}
