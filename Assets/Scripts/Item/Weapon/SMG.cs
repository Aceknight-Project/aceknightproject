using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : BaseWeapon
{
    public float Gay { get; set; }
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
        FireRate = 0.07f;
        Damage = 26;
        Offset = 0;
        Ranged = true;
        WeaponSprite = Resources.Load("Sprites/Item/Weapons/MP9.png") as Sprite;
        BulletCount = 1;
        BulletSpread = 15f;
    }
}
