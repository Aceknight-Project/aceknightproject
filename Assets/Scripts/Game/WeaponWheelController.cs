using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    public int WeaponID;
    Animator animator;
    [SerializeField]
    Image selectedWeapon;
    bool selected = false;
    [SerializeField]
    Sprite icon;
    WeaponBehavior weaponBehavior;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Aceknight");
        weaponBehavior = player.GetComponent<WeaponBehavior>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selectedWeapon.sprite = icon;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
    }
    public void Selected()
    {
        weaponBehavior.EquippedWeaponIndex = WeaponID;
        selected = true;
    }
    public void Deselected()
    {
        selected = false;
    }
    public void HoverEnter()
    {
        animator.SetBool("Hover", true);
    }
    public void HoverExit()
    {
        animator.SetBool("Hover", false);
    }
}
