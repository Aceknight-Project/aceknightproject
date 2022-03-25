using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    [SerializeField]
    GameObject normalAttack;

    [SerializeField]
    GameObject specialAttack;
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    GameObject MenuBtn;
    [SerializeField]
    GameObject specialAttackIndicator;
    GameObject player;
    GameObject Indicator;
    float timer1 = 0f;
    float timer2 = 0f;
    float timerIndicator = 0f;
    bool timerIndicatorStarted = false;
    
    public bool isInvulnerable = false;
    public float healthPoint;
    public float currentHealth;


    public BossHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 1000000f;
        currentHealth = healthPoint;
        healthBar.setMaxHealth(healthPoint);
        player = GameObject.Find("Aceknight");

    }

    // Update is called once per frame
    void Update()
    {
        timer1 += Time.deltaTime;
        if (timer1 >= 3)
        {
            GameObject.Instantiate(normalAttack, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Flak");
            timer1 = 0f;
        }
        timer2 += Time.deltaTime;
        if (timer2 >= 9)
        {
            timerIndicatorStarted = true;
            Indicator = GameObject.Instantiate(specialAttackIndicator, transform.position + new Vector3(0, 10, 0), Quaternion.identity);

            Quaternion rotation = Quaternion.LookRotation
            (player.transform.position - Indicator.transform.position, Indicator.transform.TransformDirection(Vector3.up));
            Indicator.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            timer2 = 0f;
        }
        if (timerIndicatorStarted)
        {
            timerIndicator += Time.deltaTime;

        }
        if (timerIndicator >= 1.5f)
        {
            GameObject specialAtk = GameObject.Instantiate(specialAttack, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Lightning");
            specialAtk.transform.rotation = Indicator.transform.rotation;

            timerIndicatorStarted = false;
            timerIndicator = 0f;
        }


    }

    public void takeDamage(float damage)
    {
        if (isInvulnerable) return;

        healthPoint -= damage;

        healthBar.setHealth(healthPoint);

        if (healthPoint <= 0) Die();
    }

    public void Die()
    {
        GameObject mainCam = GameObject.Find("Main Camera");
        winScreen.transform.position = mainCam.transform.position;
        MenuBtn.SetActive(true);

        Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Flak projectile = collision.gameObject.GetComponent<Flak>();
            takeDamage(projectile.Damage);
        }
    }
}
