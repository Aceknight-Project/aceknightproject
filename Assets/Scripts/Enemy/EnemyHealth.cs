using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    Slider slider;

  

    [SerializeField]
    float currentHealth;
    [SerializeField]
    GameObject DeathAnimation;
    
   
    

    GameObject healthBar;



    // Update is called once per frame
    private void Start()
    {
        healthBar = transform.Find("EnemyHP").gameObject;
        healthBar.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        slider = healthBar.GetComponent<Slider>();
        
        setMaxHealth(currentHealth);
    }
    void Update()
    {
        setHealth(currentHealth);
        

        if(currentHealth <= 0)
        {
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Death");
            Destroy(gameObject);
        }
    }

    public void decreaseHealth(float damage) 
    {
        currentHealth -= damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public void setMaxHealth(float health) { slider.maxValue = health; slider.value = health; }
    void setHealth(float health) { slider.value = health; }
}
