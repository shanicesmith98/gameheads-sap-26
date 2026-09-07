using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource playerSource;

    public AudioClip landing;
    public AudioClip walking;
    public AudioClip crouch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerSource.clip = walking;
    }

    public void StartWalking()
    {
        playerSource.Play();
    }
    public void StopWalking()
    {
        playerSource.Stop();
    }
    public void Landing()
    {
     playerSource.PlayOneShot(landing);
    }
    public void Crouch()
    {
        playerSource.PlayOneShot(crouch);
    }
}
