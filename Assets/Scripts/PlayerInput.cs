using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float Speed = 5f;
    public float jumpHeight = 5f;
    private bool isGrounded;



    Rigidbody2D rb;
    private float moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
