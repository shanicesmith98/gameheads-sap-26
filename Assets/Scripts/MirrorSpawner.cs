using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject clone;
    public Transform Mirror;
    public bool PlayerSpawn;
    public bool AutoSpawn;
    public float FireRate = 3f;
    public float NextSpawn = 0f;  
    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerSpawn && AutoSpawn) // So both can't be true at the same time
        {
            Debug.LogWarning("both can't be true at the same time...also this computer will explode in 3 seconds");
        }
        if(PlayerSpawn && !AutoSpawn) //Spawns once the player touches the mirror
        {
            PlayerSpawn = false;
        }
        if(AutoSpawn && !PlayerSpawn) //Spawns automatically
        {
            if(Time.time>NextSpawn)
            {
            NextSpawn = Time.time + FireRate;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) //Collision for the player so that way it spawns once
    {
        if(col.CompareTag("Player") && !AutoSpawn)
        {
            PlayerSpawn = true;
        }
    }
}
