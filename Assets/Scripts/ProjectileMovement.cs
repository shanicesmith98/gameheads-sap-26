using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float Speed = 3f;
    public bool FlipDirection;
    public float damageGiven = 5f;
    public PlayerFear PF;

    
    void Start()
    {
        PF = FindFirstObjectByType<PlayerFear>();
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

    void OnCollisionEnter2D(Collision2D oth)
    {
        if(oth.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PF.TakeDamage(damageGiven);
        }
    }

}