using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class PlayerInput : MonoBehaviour
{
    public float Speed = 5f;
    public float jumpHeight = 5f;
    private bool isGrounded;
    private bool touchingLight;
    private bool speedBoost = false;
    public PlayerFear PF;



    Rigidbody2D rb;
    private float moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PF = FindFirstObjectByType<PlayerFear>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PF.DarkLevel)
        {
            if(touchingLight)
            {
            PF.TakeDamage(-5 * Time.deltaTime);
            }
            else
            {
            PF.TakeDamage(5 * Time.deltaTime);
            }
        }

  
    }

    private IEnumerator Cooldown(float time)
    {
        speedBoost = true;
        yield return new WaitForSeconds(time);
        speedBoost = false;
    }

    private void FixedUpdate()
    {
        if(!PF.isGameOver)
        {
            if(speedBoost)
            {
            Debug.Log("SPEED BOOST!");
            rb.linearVelocity = new Vector2(moveInput * (Speed * 2f), rb.linearVelocityY);
            StartCoroutine(Cooldown(1f));
            }
            else
            {
            rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocityY);
            }
        }
    }

    public void OnMove(InputValue value)
    {        
        Debug.Log($"MoveInput: {moveInput}");

        moveInput = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded && !PF.isGameOver)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpHeight);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
          if(col.gameObject.CompareTag("Spike"))
        {
            PF.TakeDamage(5);
            isGrounded = true;
        }
        if(col.gameObject.CompareTag("Slope"))
        {
            speedBoost = true;
        }
        if(col.gameObject.CompareTag("Future"))
        {
            PF.GameOver();
        }
    }
    
    void OnTriggerEnter2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is touching light");
            touchingLight = true;
        }
        if(oth.CompareTag("Projectile"))
        {
            PF.TakeDamage(5);
        }
    }
       void OnTriggerExit2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is NOT touching light");
            touchingLight = false;
        }
    }

}
