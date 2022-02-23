using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject crosshair;
    [SerializeField]
    Camera mainCam;
    bool paused = false;
    [SerializeField]
    GameObject UI;
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        pauseMenu = UI.transform.Find("PauseMenu").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!paused)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                paused = true;
                Cursor.visible = true;
            }
            else Resume();
        }
    }
    private void FixedUpdate()
    {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            crosshair.transform.position = mousePos;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        paused = false;
        Cursor.visible = false;
    }
}
