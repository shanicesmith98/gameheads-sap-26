using UnityEngine;

public class Lights : MonoBehaviour
{
    private bool touchingLight;
    public bool Moves;
    public float Speed = 5f;
    public bool endPlatform; // If the light reaches the end of the platform, it goes the other way.
   
    void Start()
    {
        
    }

    void Update()
    {
        if(touchingLight)
        {
            //decrease fear meter
        }
        else
        {
            //increase fear meter
        }

        if(Moves)
        {
            if(endPlatform)
            {
                endPlatform = false;
                Speed = Speed * -1;
            }
            
            transform.Translate(Vector2.right * Speed * Time.deltaTime);

        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player"))
        {
            touchingLight = true;
        }
        else
        {
            touchingLight = false;
        }
    }
}
