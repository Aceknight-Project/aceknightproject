using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : BaseWeapon
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
        FireRate = 0.1f;
        Damage = 10;
        Offset = 0;
        Ranged = true;
        Silenced = false;
        Automatic = true;
        BulletCount = 1;
        BulletSpread = 15f;
        BulletSpeed = 700f;
    }
}
