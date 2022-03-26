using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    float Timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explode3");
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 0.2f)
            Destroy(gameObject);
    }
}
