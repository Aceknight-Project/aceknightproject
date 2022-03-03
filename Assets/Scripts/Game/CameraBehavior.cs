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
    [SerializeField]
    float minX, maxX, minY, maxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Map1: minX = -10, maxX = 92, minY = -5, maxY = 66
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = player.transform.position;
        Vector2 camDockPos = (mousePos + playerPos) / 2;
        Vector3 finalPos = new Vector3(camDockPos.x, camDockPos.y, -10);
        finalPos.x = Mathf.Clamp(finalPos.x, minX, maxX);
        finalPos.y = Mathf.Clamp(finalPos.y, minY, maxY);
        transform.position = finalPos;
    }
}
