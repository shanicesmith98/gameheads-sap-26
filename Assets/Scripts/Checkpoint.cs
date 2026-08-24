using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerController playerController;
    Vector3 originalScale;
    Collider2D checkpointCollider;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        checkpointCollider = GetComponent<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has reached the checkpoint!");
            playerController.UpdateCheckpoint(transform.position);
            // Disable the checkpoint collider to prevent multiple triggers
            checkpointCollider.enabled = false; 
        }
    }
}
