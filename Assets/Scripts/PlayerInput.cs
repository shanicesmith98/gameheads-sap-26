using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class PlayerInput : MonoBehaviour
{
    private float moveInput;

    public float Speed = 5f;
    public float jumpHeight = 5f;

    public bool isCrouching = false;


    public bool Spawn = false;

    public float FearMeter_DepletionRate = 5f;
    public float FearMeter_HealingRate = 5f;


    private bool isGrounded;
    private bool touchingLight;
    private bool speedBoost = false;

    PlayerFear PF;
    GameManager GM;
    ManagerScene MS;
    SpriteRenderer SP;
    Rigidbody2D rb;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PF = FindFirstObjectByType<PlayerFear>();
        GM = FindFirstObjectByType<GameManager>();
        MS = FindFirstObjectByType<ManagerScene>();


        SP = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(PF.DarkLevel)
        {
            if(touchingLight)
            {
            PF.TakeDamage(-FearMeter_HealingRate * Time.deltaTime);
            }
            else
            {
            PF.TakeDamage(FearMeter_DepletionRate * Time.deltaTime);
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
        if(!GM.isGameOver)
        {
            if(speedBoost)
            {
            Debug.Log("SPEED BOOST!");
            rb.linearVelocity = new Vector2(moveInput * (Speed * 2f), rb.linearVelocityY);
            }
            else if(isCrouching)
            {
                rb.linearVelocity = new Vector2(moveInput * (Speed*0.5f), rb.linearVelocityY);
            }
            else
            {
            rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocityY);
            anim.SetBool("isRunning",false);
            }
        }
    }

    public void OnMove(InputValue value)
    {        
        Debug.Log($"MoveInput: {moveInput}");
        if(!GM.isGameOver)
        {
        moveInput = value.Get<Vector2>().x;
        }
        else
        {
            moveInput = 0f;
        }

        if(moveInput > 0 )
        {
            Debug.Log("Going Left!!");
            SP.flipX = false;
            anim.SetBool("isWalking",true);


        }
         else if(moveInput < 0)
        {
            SP.flipX = true;
            Debug.Log("Going Right!!");
             anim.SetBool("isWalking",true);

        }
        else if(moveInput == 0)
        {
            anim.SetBool("isWalking",false);
            anim.SetBool("isRunning",false);



            //cue the idle animation woohoo
        }
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded && !GM.isGameOver)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpHeight);
            isGrounded = false;
            anim.SetBool("isJumping",true);

        }
    }

    public void OnCrouch(InputValue value)
    {
        Debug.Log("Crouching");

            if(value.isPressed && MS.sceneName == "LevelTwo" || value.isPressed && MS.sceneName == "LevelThree" )
            {
                isCrouching = true;
             anim.SetBool("isCrouching",true);

            }
            else
            {  
            isCrouching = false;
            anim.SetBool("isCrouching",false);
            }   
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping",false);

        }
          if(col.gameObject.CompareTag("Spike"))
        {
            if(!isCrouching)
            {
            PF.TakeDamage(5);
            }
            isGrounded = true;
        }
        if(col.gameObject.CompareTag("Slope"))
        {
            isGrounded = true;
            speedBoost = true;
            anim.SetBool("isRunning",true);

        }
        if(col.gameObject.CompareTag("Future"))
        {
            GM.GameOver();
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Slope"))
        {
            StartCoroutine(Cooldown(1f));
        }
    }
    
    void OnTriggerEnter2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is touching light");
            touchingLight = true;
            anim.SetBool("isHealing",true);

        }
        if(oth.CompareTag("Projectile"))
        {
            if(!isCrouching)
            {
            PF.TakeDamage(5);
            }
        }
         if(oth.CompareTag("EndOfLevel"))
        {
            GM.LevelComplete.gameObject.SetActive(true);
        }
        if(oth.CompareTag("Mirror"))
        {
            Spawn = true;
        }
    }
       void OnTriggerExit2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is NOT touching light");
            touchingLight = false;
            anim.SetBool("isHealing",false);

        }
    }

}
