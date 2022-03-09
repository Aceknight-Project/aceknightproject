using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform Lazer;

    float time = 0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            time = 0f;
        }

        if (time >= 3)
        {
            GameObject.Instantiate (Lazer, transform.position, Quaternion.identity);
            time = 0f;
        }



    }

    public void takeDamage(float damage)
    {
        if (isInvulnerable) return;

        healthPoint -= damage;

        healthBar.setHealth(healthPoint);

        if (healthPoint < 0) Die();
    }

    public void Die()
    {
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
