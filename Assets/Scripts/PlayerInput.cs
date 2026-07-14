using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class PlayerInput : MonoBehaviour
{
    public float Speed = 5f;
    public float jumpHeight = 5f;
    private bool isGrounded;
    private bool speedBoost = false;
    public float Speedboost = 1.5f;
    public bool canCrouch = false;
    public bool canRunFaster = false;
    public float addedSpeed = 2f;
    public bool zeroGravity = false;
    public float timesJump = 0.4f;
    private PlayerFear PF;
    private GameManager GM;




    Rigidbody2D rb;
    private float moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = FindFirstObjectByType<GameManager>();
        PF = FindFirstObjectByType<PlayerFear>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private IEnumerator Cooldown(float time)
    {
        speedBoost = true;
        yield return new WaitForSeconds(time);
        speedBoost = false;
    }

    private void FixedUpdate()
    {
        if(!GM.isGameOver)
        {
             if(canRunFaster)
                {
                    if(speedBoost)
                    {
                        Debug.Log("SPEED BOOST!");
                        rb.linearVelocity = new Vector2(moveInput * (Speed + addedSpeed * Speedboost), rb.linearVelocityY);
                        StartCoroutine(Cooldown(1f));
                    }
                    else
                    {
                        rb.linearVelocity = new Vector2(moveInput * (Speed + addedSpeed), rb.linearVelocityY);
                    }
                }
                else
                {
                    if(speedBoost)
                    {
                        Debug.Log("SPEED BOOST!");
                        rb.linearVelocity = new Vector2(moveInput * (Speed * Speedboost), rb.linearVelocityY);
                        StartCoroutine(Cooldown(1f));
                    }
                    else
                    {
                        rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocityY);
                    }
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
        if(value.isPressed && isGrounded && !GM.isGameOver)
        {
             if(zeroGravity)
                {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpHeight * timesJump);
                }
                else
                {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpHeight);
                }
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
            GM.GameOver();
        }
    }
    
    void OnTriggerEnter2D(Collider2D oth)
    {
         if(oth.CompareTag("Projectile"))
        {
            PF.TakeDamage(5);
        }
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is touching light");
            PF.TouchingLight = true;
        }
    }
       void OnTriggerExit2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is NOT touching light");
            PF.TouchingLight = false;
        }
    }

}
