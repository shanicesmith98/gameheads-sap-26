using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;


    //public AudioClip lightsOff;
    public AudioClip landing;
    public AudioClip walking;

    public AudioClip laser;

    public AudioClip light;

    public static AudioManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
     void Awake()
    {
        if(instance == null)
        {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

   public void PlaySFX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
   }

}
