using UnityEngine;

public class Lights : MonoBehaviour
{
    private bool touchingLight;
    public bool Moves;
    public float Speed = 5f;
   [SerializeField] private bool endPlatform; // If the light reaches the end of the platform, it goes the other way.
    private float savedPosition;

   
    void Start()
    {
        savedPosition = transform.position.x;
    }

    void Update()
    {
        if(Moves)
        {
            if(transform.position.x < savedPosition) //If the light goes back to the place where it started, it goes the other way.
            {
            Speed = Speed * -1;
            }
            if(endPlatform)
            {
            Speed = Speed * -1;
            endPlatform = false;
            }
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D oth)   //If it touches the trigger(which marks the end of the platform), it goes the other way.
    {
        if(oth.CompareTag("EndPlatform"))
        {   
        endPlatform = true;
        }
    }

}
