using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bossArea;
    [SerializeField]
    Camera mainCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = player.transform.position;
        Vector2 camDockPos = (mousePos + playerPos) / 2;
        Vector3 finalPos = new Vector3(camDockPos.x, camDockPos.y, -10);
        transform.position = finalPos;
    }
}
