using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Boss;

    public GameObject HeathBar;

    

     
  
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Aceknight")
        {
           /* GameObject mainCamera = GameObject.Find("Main Camera");
            CameraBehavior behavior = mainCamera.GetComponent<CameraBehavior>();
            behavior.inBossArea = true;*/

            Boss.SetActive(true);
            HeathBar.SetActive(true);
            gameObject.SetActive(false);
           


        }
    }


}
