using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private bool isGrounded = true;
    private int extraJumpsCount = 0;
    private Rigidbody playerRb;

    public float moveSpeed = 15.0f;
    public float jumpForce = 10.0f;
    public Text healthText;

    public void Start()
    {
        Health = 100;
        playerRb = GetComponent<Rigidbody>();
        StartCoroutine(ReduceHealth());
    }
    public void Update()
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
    }

    IEnumerator ReduceHealth()
    {
        while (true) {
            Health--;
            UpdateHealth();
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
        if (obj.CompareTag("Collectable"))
        {
            int award = obj.GetComponent<Collectable>().GetAward();
            Heal(award);
            Destroy(obj);
        }
    }

    private void Heal(int health)
    {
        Health += health;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        healthText.text = $"HP: {Health}";
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
