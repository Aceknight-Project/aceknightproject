using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : BaseWeapon
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
    void SetDefaults()
    {
        FireRate = 0.1f;
        Damage = 33;
        Offset = 0;
        Ranged = true;
        WeaponSprite = Resources.Load("Sprites/Item/Weapons/M4A4.png") as Sprite;
        BulletCount = 1;
        BulletSpread = 5f;
    }
}
