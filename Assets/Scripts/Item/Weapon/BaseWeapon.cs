using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public GameObject Player { get; set;}
    public PlayerBehavior playerBehavior { get; set; }
    //Seconds between each bullets.
    public float FireRate { get; set; }
    public float Damage { get; set; }
    //Offset compared to the arm.
    public float Offset { get; set; }
    public Sprite WeaponSprite { get; set; }
    //Check if weapon is ranged or melee.
    public bool Ranged { get; set; }
    //How many bullets are shot at once.
    public int BulletCount { get; set; }
    //Randomized spread of the bullets.
    public float BulletSpread { get; set; }
    public float BulletSpeed { get; set; }
    void Start()
    {
        Player = GameObject.Find("Aceknight");
        playerBehavior = Player.GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
