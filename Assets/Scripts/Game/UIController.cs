using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    GameObject crosshair;
    [SerializeField]
    Camera mainCam;
    bool paused = false;
    bool timeSlowed = false;
    [SerializeField]
    GameObject UI;
    GameObject pauseMenu;
    GameObject weaponWheel;
    [SerializeField]
    Slider hpBarFill;
    [SerializeField]
    Slider hpBarOverhealFill;
    WeaponBehavior weaponBehavior;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Aceknight");
        weaponBehavior = player.GetComponent<WeaponBehavior>();
        Cursor.visible = false;
        pauseMenu = UI.transform.Find("PauseMenu").gameObject;
        GameObject playerUI = UI.transform.Find("PlayerUI").gameObject;
        weaponWheel = playerUI.transform.Find("WeaponWheel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!paused)
            {
                Pause();
            }
            else Resume();
        }
        if (Input.GetButtonDown("WeaponSelect"))
        {
            WeaponSelection();
        }
        else if (Input.GetButtonUp("WeaponSelect"))
            Resume();
    }
    private void FixedUpdate()
    {
        //Crosshair
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = mousePos;

        //Player Healthbar
        PlayerBehavior playerScript = player.GetComponent<PlayerBehavior>();
        hpBarFill.value = playerScript.GetHealth();
        if (playerScript.GetHealth() > 100)
            hpBarOverhealFill.value = playerScript.GetHealth() - 100;
        else hpBarOverhealFill.value = 0;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        paused = true;
        Cursor.visible = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        weaponWheel.SetActive(false);
        paused = false;
        Cursor.visible = false;
    }
    public void WeaponSelection()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        weaponWheel.SetActive(true);
    }
}
