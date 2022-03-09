using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    //Weapon Sprites
    [SerializeField]
    Sprite USPS;
    [SerializeField]
    Sprite MP9;
    [SerializeField]
    Sprite M4A4;
    [SerializeField]
    Sprite AWP;
    [SerializeField]
    Sprite Deagle;
    [SerializeField]
    Sprite FAN;
    //GameObjects
    GameObject Player;
    GameObject ArmRotator;
    GameObject AceknightArm;
    PlayerBehavior playerBehavior;
    GameObject EquippedWeapon;
    BaseWeapon WeaponScript;
    [SerializeField]
    SpriteRenderer EquippedWeaponSprite;
    [SerializeField]
    GameObject PlayerShot;
    bool Atk1OnCD;
    float Atk1CDTimer;
    public int EquippedWeaponIndex { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        EquippedWeaponIndex = 1;
        Player = GameObject.Find("Aceknight");
        ArmRotator = Player.transform.Find("ArmRotator").gameObject;
        EquippedWeapon = ArmRotator.transform.Find("GunHolder").gameObject;
        AceknightArm = ArmRotator.transform.Find("AceknightArm").gameObject;
        playerBehavior = Player.GetComponent<PlayerBehavior>();
        WeaponScript = EquippedWeapon.GetComponent<BaseWeapon>();
        Atk1OnCD = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerBehavior.GetVehicleState())
        {
            //Main Attack
            if (WeaponScript.Automatic)
                if (Input.GetButton("Fire1"))
                {
                    Attack1();
                }
            if (!WeaponScript.Automatic)
                if (Input.GetButtonDown("Fire1"))
                {
                    Attack1();
                }
            if (Atk1OnCD)
            {
                if (Atk1CDTimer > WeaponScript.FireRate)
                {
                    Atk1OnCD = false;
                    Atk1CDTimer = 0f;
                }
                else
                    Atk1CDTimer += Time.deltaTime;
            }
        }
    }
    void FixedUpdate()
    {
        //Aim
        if (!playerBehavior.GetVehicleState())
            Aim();

        //Change Weapon
        switch (EquippedWeaponIndex)
        {
            case 1: 
                {
                    WeaponScript = new Pistol();
                    WeaponScript.SetDefaults();
                    EquippedWeaponSprite.sprite = USPS;
                    break; 
                }
            case 2:
                {
                    WeaponScript = new SMG();
                    WeaponScript.SetDefaults();
                    EquippedWeaponSprite.sprite = MP9;
                    break;
                }
            case 3:
                {
                    WeaponScript = new Rifle();
                    WeaponScript.SetDefaults();
                    EquippedWeaponSprite.sprite = M4A4;
                    break;
                }
            case 4:
                {
                    WeaponScript = new Sniper();
                    WeaponScript.SetDefaults();
                    EquippedWeaponSprite.sprite = AWP;
                    break;
                }
            case 5:
                {
                    WeaponScript = new Deagle();
                    WeaponScript.SetDefaults();
                    EquippedWeaponSprite.sprite = Deagle;
                    break;
                }
            case 6:
                {
                    WeaponScript = new Shotgun();
                    WeaponScript.SetDefaults();
                    EquippedWeaponSprite.sprite = FAN;
                    break;
                }
            default: { break; }
        }
    }
    void Aim()
    {
        if (!playerBehavior.GetVehicleState())
        {
            Vector2 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(ArmRotator.transform.position);
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 90;
            ArmRotator.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            ArmRotator.transform.rotation = Quaternion.Euler(0, 0, ArmRotator.transform.rotation.eulerAngles.z);
        }
    }
    void Attack1()
    {
        if (!Atk1OnCD)
        {
            for (int i = 0; i < WeaponScript.BulletCount; i++)
            {
                Vector3 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(EquippedWeapon.transform.position);
                Atk1OnCD = true;
                GameObject PlayerShotInstance = Instantiate(PlayerShot, EquippedWeapon.transform.position, Quaternion.identity);
                float randomAngle = Random.Range(-WeaponScript.BulletSpread, WeaponScript.BulletSpread);
                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 90 + randomAngle;
                PlayerShotInstance.GetComponent<PlayerProjectile>().Damage = WeaponScript.Damage;
                PlayerShotInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                PlayerShotInstance.GetComponent<Rigidbody2D>().AddForce(WeaponScript.BulletSpeed * (Quaternion.Euler(0, 0, angle) * Vector2.down).normalized);
            }
        }
    }
}
