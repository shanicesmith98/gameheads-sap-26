using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background_one;
    public AudioClip background_two;

    //public AudioClip lightsOff;
    public AudioClip landing;
    public AudioClip walking;

    private string sceneName;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "LevelOne")
        {
            musicSource.clip = background_one;
        }
        if(sceneName == "LevelTwo")
        {
            musicSource.clip = background_one;
        }
        if(sceneName == "LevelThree")
        {
        musicSource.clip = background_one;
        }
        musicSource.Play();
    }

   public void PlaySFX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
   }

}
