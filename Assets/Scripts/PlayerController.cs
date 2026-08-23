using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 checkpointPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        checkpointPosition = transform.position;
    }

    void Die()
    {
        Respawn();
    }

    private void Respawn()
    {
        transform.position = checkpointPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetector"))
        {
            Die();
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint reached!");
            UpdateCheckpoint(collision.transform.position);
        }
    }
    public void UpdateCheckpoint(Vector2 position)
    {
        checkpointPosition = position;
    }
}
