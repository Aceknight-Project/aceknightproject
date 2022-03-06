using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakController : MonoBehaviour
{
    bool nearInteractable = false;
    bool activated = false;
    GameObject FlakBarrel;
    GameObject BarrelRotator;
    public GameObject FlakShield;
    public GameObject MuzzleFlash;
    GameObject Player;
    GameObject EButton;
    [SerializeField]
    GameObject FlakShot;
    PlayerBehavior playerBehavior;
    bool Atk1OnCD = false;
    bool Atk2OnCD = false;
    float Atk1CDTimer = 0f;
    float Atk2CDTimer = 0f;
    float Atk2Timer = 0f;
    float Atk1FlashTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        BarrelRotator = transform.Find("BarrelRotator").gameObject;
        FlakBarrel = BarrelRotator.transform.Find("FlakBarrel").gameObject;
        MuzzleFlash = FlakBarrel.transform.Find("MuzzleFlash").gameObject;
        EButton = transform.Find("EButton").gameObject;
        Player = GameObject.Find("Aceknight");
        playerBehavior = Player.GetComponent<PlayerBehavior>();

    }
    // Update is called once per frame
    void Update()
    {
        EButtonControl();
        if (nearInteractable)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (!activated)
                {
                    activated = true;
                    playerBehavior.SetVehicleState(activated);
                }
                else
                {
                    activated = false;
                    playerBehavior.SetVehicleState(activated);
                }
            }
        }
        if (activated)
        {
            Player.transform.position = BarrelRotator.transform.position;

            //Attack 1 and CD
            if (Input.GetButton("Fire1"))
            {
                Attack1();
            }
            if (Atk1OnCD)
            {
                if (Atk1FlashTimer > 0.1f)
                {
                    MuzzleFlash.SetActive(false);
                }
                else
                    Atk1FlashTimer += Time.deltaTime;
                if (Atk1CDTimer > 0.5f)
                {
                    Atk1OnCD = false;
                    Atk1CDTimer = 0f;
                    Atk1FlashTimer = 0f;
                }
                else
                    Atk1CDTimer += Time.deltaTime;
            }
            //Attack 2 and CD
            if (Input.GetButtonDown("Fire2"))
            {
                Attack2();
            }
            if (Atk2OnCD)
            {
                if (Atk2Timer > 1f)
                {
                    FlakShield.SetActive(false);
                }
                else
                    Atk2Timer += Time.deltaTime;
                if (Atk2CDTimer > 2.5f)
                {
                    Atk2OnCD = false;
                    Atk2CDTimer = 0f;
                    Atk2Timer = 0f;
                }
                else
                    Atk2CDTimer += Time.deltaTime;
            }
        }
    }
    void FixedUpdate()
    {
        if (activated)
        {
            Aim();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Aceknight")
        {
            nearInteractable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Aceknight")
        {
            nearInteractable = false;
        }
    }
    void EButtonControl()
    {
        if (nearInteractable && !activated)
            EButton.SetActive(true);
        else EButton.SetActive(false);
    }
    void Aim()
    {
        Vector2 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(BarrelRotator.transform.position);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        BarrelRotator.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        BarrelRotator.transform.rotation = Quaternion.Euler(0, 0, BarrelRotator.transform.rotation.eulerAngles.z);
    }
    void Attack1()
    {
        if (!Atk1OnCD)
        {
            Vector3 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(BarrelRotator.transform.position);
            Atk1OnCD = true;
            MuzzleFlash.SetActive(true);
            GameObject FlakShotInstance = Instantiate(FlakShot, BarrelRotator.transform.position, Quaternion.identity);
            FlakShotInstance.transform.rotation = BarrelRotator.transform.rotation;
            FlakShotInstance.GetComponent<Rigidbody2D>().AddForce(700f * (mousePos - BarrelRotator.transform.position).normalized);
        }
    }
    void Attack2()
    {
        if (!Atk2OnCD)
        {
            Atk2OnCD = true;
            FlakShield.SetActive(true);
        }
    }
}
