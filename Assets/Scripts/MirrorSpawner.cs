using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    public GameObject Projectile;
    public Transform Mirror;
    public bool Spawn;
  
    void Start()
    {
        
    }

    void Update()
    {
        if(Spawn)
        {
            Spawn = false;
           Instantiate(Projectile, Mirror.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Spawn = true;
        }
    }
}
