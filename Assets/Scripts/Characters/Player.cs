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
    private CharacterController controller;
    private Vector3 velocity;
    private bool isImmortal = false;

    public float gravity = -9.8f;
    public float moveSpeed = 8.0f;
    public float jumpForce = 3.5f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

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
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            extraJumpsCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
                return;
            }
            if(extraJumpsCount < 1)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
                extraJumpsCount++;
            }
        }
        float x = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * x;
        controller.Move(move * moveSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            UpdateHealth(-12.5f);
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
        MP.updateMana(mana);
    }

    public override void UpdateHealth(float value)
    {
        if (isImmortal && value < 0) return;
        Health += value;
        if (Health > maxHealth) Health = maxHealth;
        HP.changeHealth(Health);
    }

    public IEnumerator Immortal()
    {
        if (!isImmortal)
        {
            isImmortal = true;
            yield return new WaitForSecondsRealtime(2);
            isImmortal = false;
        }
    }
}
