using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private const float maxHealth = 75;
    private const float maxMana = 50;
    private bool isGrounded = true;
    private int extraJumpsCount = 0;
    private Rigidbody playerRb;
    private float mana;
    private HealthSystem HP;
    private ManaScript MP;

    public float moveSpeed = 15.0f;
    public float jumpForce = 10.0f;

    private void Awake()
    {
        HP = GameObject.Find("HealthBar").GetComponent<HealthSystem>();//Ищем наш хп бар
        MP = GameObject.Find("ManaBar").GetComponent<ManaScript>();
    }

    public void Start()
    {
        Health = maxHealth;
        mana = maxMana;
        playerRb = GetComponent<Rigidbody>();
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
            UpdateHealth(-12.5f);
            //HP.changeHealth(-12.5f);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            HP.addNewHealth();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpdateStamina(-6.7f);
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
        mana += value;
        if (mana > maxMana) mana = maxMana;
        Debug.Log(mana);
        MP.updateMana(mana);
    }

    public override void UpdateHealth(float value)
    {
        Health += value;
        if (Health > maxHealth) Health = maxHealth;
        Debug.Log(Health);
        HP.changeHealth(Health);
    }
}
