using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject clone;
    public Transform Mirror;
    public bool AutoSpawn;
    public float FireRate = 3f;
    public float NextSpawn = 0f;
    public bool PlayerSpawn;
    public float secondsAfterSpawn = 2f;  
    public int secondsToDestroy = 3;
    void Start()
    {
        clone = GetComponent<GameObject>();
    }

    void Update()
    {
        if(PlayerSpawn && AutoSpawn) // So both can't be true at the same time
        {
            Debug.LogWarning("PlayerSpawn and AutoSpawn can't be true at the same time.");
        }
        
        //SPAWNS AUTOMATICALLY
        if(AutoSpawn && !PlayerSpawn) //Spawns automatically
        {
            if(Time.time>NextSpawn)
            {
                NextSpawn = Time.time + FireRate;
                Invoke("LaunchProjectile", 0);
            }
            Destroy(clone,secondsToDestroy);
        }
        
        //SPAWNS AFTER PLAYER WALKS PAST (WITH A DELAY!!)
        if(PlayerSpawn && !AutoSpawn) //Spawns once the player touches the mirror
        {
            PlayerSpawn = false;
            Invoke("LaunchProjectile", secondsAfterSpawn);
            Destroy(clone,secondsToDestroy);

        }
    }

    void LaunchProjectile()
    {
        clone = (GameObject)Instantiate(Projectile, Mirror.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col) //Collision for the player so that way it spawns once
    {
        if(col.CompareTag("Player") && !AutoSpawn)
        {
            PlayerSpawn = true;
        }
    }
}
