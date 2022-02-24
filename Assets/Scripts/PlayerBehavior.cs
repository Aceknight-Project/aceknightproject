using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    CharacterController2D controller2D;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    [SerializeField]
    float runSpeed = 40f;
    public float healthPoint;
    float overhealTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;
        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
        OverhealControl();
    }
    void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    public float GetHealth()
    {
        return healthPoint;
    }
    public float TakeDamage(float damage)
    {
        healthPoint -= damage;
        return healthPoint;
    }
    public float Heal(float heal)
    {
        healthPoint += heal;
        if (healthPoint > 130f) healthPoint = 130f;
        return healthPoint;
    }
    void OverhealControl()
    {
        if (healthPoint > 100)
        {
            overhealTimer += Time.deltaTime;
            if (overhealTimer >= 1f)
            {
                healthPoint -= 1f;
                overhealTimer = 0f;
            }
        }
    }
}
