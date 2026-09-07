using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;


    //public AudioClip lightsOff;
    public AudioClip laser;

    public AudioClip light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

   public void PlaySFX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
   }
}
