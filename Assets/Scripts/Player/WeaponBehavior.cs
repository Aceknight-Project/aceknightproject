using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetButton("Fire1"))
            {
                Attack1();
            }
            if (Atk1OnCD)
            {
                if (Atk1CDTimer > 0.1f)
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
        if (!playerBehavior.GetVehicleState())
            Aim();
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
            Vector3 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(EquippedWeapon.transform.position);
            Atk1OnCD = true;
            GameObject PlayerShotInstance = Instantiate(PlayerShot, EquippedWeapon.transform.position, Quaternion.identity);
            float randomAngle = Random.Range(-7, 7);
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 90 + randomAngle;
            PlayerShotInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            PlayerShotInstance.GetComponent<Rigidbody2D>().AddForce(700f * (Quaternion.Euler(0,0,angle)*Vector2.down).normalized);
        }
    }
}
