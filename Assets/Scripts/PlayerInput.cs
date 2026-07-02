using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float Speed = 5f;
    public float jumpHeight = 5f;
    private bool isGrounded;
    private bool touchingLight;
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
            PF.TakeDamage(-5);
            }
            else
            {
            PF.TakeDamage(5);
            }
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocityY);
    }

    public void OnMove(InputValue value)
    {        
        Debug.Log($"ur ass better be moving on god bro: {moveInput}");

        moveInput = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded)
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
    }
    
    void OnTriggerEnter2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is touching light");
            touchingLight = true;
        }
    }
       void OnTriggerExit2D(Collider2D oth)
    {
        if(oth.CompareTag("Light"))
        {
            Debug.Log("Is NOT touching light");
            touchingLight = true;
        }
    }

}
