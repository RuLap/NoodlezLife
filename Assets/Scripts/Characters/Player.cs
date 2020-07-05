using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private bool isGrounded = true;
    private int extraJumpsCount = 0;
    private Rigidbody playerRb;
    private float stamina;

    public float moveSpeed = 15.0f;
    public float jumpForce = 10.0f;
    public Text healthText;
    public Text staminaText;
    private HealthSystem HP;
    private void Awake()
    {
        HP = GameObject.Find("HealthBar").GetComponent<HealthSystem>();//Ищем наш хп бар
    }

    public void Start()
    {
        Health = 6;
        stamina = 100;
        playerRb = GetComponent<Rigidbody>();
        UpdateHealthUI();
        UpdateStaminaUI();
        //StartCoroutine(ReduceHealth());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRb.velocity = Vector3.up * jumpForce;
                return;
            }
            if(extraJumpsCount < 1)
            {
                playerRb.velocity = Vector3.up * jumpForce;
                extraJumpsCount++;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            HP.changeHealth(-12.5f);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            HP.addNewHealth();
        }
    }

    IEnumerator ReduceHealth()
    {
        while (true) {
            Health--;
            UpdateHealthUI();
            yield return new WaitForSeconds(1);
        }
    }
    protected void Move(Vector3 side)
    {
        transform.Translate(side * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("Ground"))
        {
            isGrounded = true;
            extraJumpsCount = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void UpdateStamina(float value)
    {
        stamina += value;
        UpdateStaminaUI();
    }

    public override void UpdateHealth(float value)
    {
        Health += value;
        HP.changeHealth(value);
    }

    public void UpdateHealthUI()
    {
        healthText.text = $"HP: {Health}";
    }

    private void UpdateStaminaUI()
    {
        staminaText.text = $"Stamina: {stamina}";
    }
}
