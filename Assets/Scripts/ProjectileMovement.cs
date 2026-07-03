using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float Speed = 3f;
    public bool FlipDirection;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if(FlipDirection)
        {
            Speed = Speed * -1;
            FlipDirection = false;
        }

        transform.Translate(Vector2.right * Speed * Time.deltaTime);

    }

}