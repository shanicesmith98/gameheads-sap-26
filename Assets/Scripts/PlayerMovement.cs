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

    // Update is called once per frame
    void Update()
    {
 
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
