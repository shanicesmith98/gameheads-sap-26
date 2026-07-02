using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    public float jumpHeight;
    public float Gravity;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 velocity;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"ur ass better be moving on god bro: {moveInput}");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping: {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("We are supposed to jump!");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(moveInput.x, 0);
        controller.Move(move * Speed * Time.deltaTime);

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }







    void OnTriggerEnter2D(Collider2D oth)
    {
        if(oth.CompareTag("Projectile"))
        {
            Destroy(oth.gameObject);

            //Increase fear
        }

    }

}
