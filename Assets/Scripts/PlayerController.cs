using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 checkpointPosition;
    Rigidbody2D playerRigidbody;
    Vector3 originalScale;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        checkpointPosition = transform.position;
    }

    void Die()
    {
        StartCoroutine(Respawn(0.25f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRigidbody.simulated = false;
        playerRigidbody.linearVelocity = Vector2.zero;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPosition;
        transform.localScale = originalScale;
        playerRigidbody.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetector"))
        {
            Die();
        }
    }
    public void UpdateCheckpoint(Vector2 position)
    {
        checkpointPosition = position;
    }
}
