using UnityEngine;

public class AudioManagerMUSIC : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background_one;
    public AudioClip background_two;
    public AudioClip background_three;


    public bool LevelOne;
    public bool LevelTwo;
    public bool LevelThree;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(LevelOne)
        {
        musicSource.clip = background_one;
        }
        else if(LevelTwo)
        {
        musicSource.clip = background_two;
        }
        else if(LevelThree)
        {
        musicSource.clip = background_three;
        }
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
