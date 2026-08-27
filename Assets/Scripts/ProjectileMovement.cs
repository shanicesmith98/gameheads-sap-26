using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float Speed = 3f;
    public float damageGiven = 5f;


    PlayerFear PF;
    MirrorSpawner MS;

    
    void Start()
    {
        PF = FindFirstObjectByType<PlayerFear>();
    }
   
    void Update()
    {
       /* if(FlipDirection)
        {
            Speed = Speed * -1;
            FlipDirection = false;
        }*/
        
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }


}